using System;
using System.Linq;
using Teromac.Core;
using Teromac.Core.Domain.Users;
using Teromac.Services.Security;

namespace Teromac.Services.Users
{
    /// <summary>
    /// User registration service
    /// </summary>
    public partial class UserRegistrationService : IUserRegistrationService
    {
        #region Fields

        private readonly IUserService _userService;
        private readonly IEncryptionService _encryptionService;
        private readonly UserSettings _userSettings;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="userService">User service</param>
        /// <param name="encryptionService">Encryption service</param>
        /// <param name="userSettings">User settings</param>
        public UserRegistrationService(IUserService userService, 
            IEncryptionService encryptionService, 
            UserSettings userSettings)
        {
            this._userService = userService;
            this._encryptionService = encryptionService;
            this._userSettings = userSettings;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Validate user
        /// </summary>
        /// <param name="usernameOrEmail">Username or email</param>
        /// <param name="password">Password</param>
        /// <returns>Result</returns>
        public virtual UserLoginResults ValidateUser(string usernameOrEmail, string password)
        {
            var user = _userService.GetUserByUsername(usernameOrEmail);

            if (user == null)
                return UserLoginResults.UserNotExist;
            if (user.Deleted)
                return UserLoginResults.Deleted;
            if (!user.Active)
                return UserLoginResults.NotActive;
            //only registered can login
            if (!user.IsRegistered())
                return UserLoginResults.NotRegistered;

            string pwd = _encryptionService.CreatePasswordHash(password, user.PasswordSalt);


            bool isValid = pwd == user.Password;
            if (!isValid)
                return UserLoginResults.WrongPassword;

            //save last login date
            user.LastLoginDateUtc = DateTime.UtcNow;
            _userService.UpdateUser(user);
            return UserLoginResults.Successful;
        }

        /// <summary>
        /// Register user
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>Result</returns>
        public virtual UserRegistrationResult RegisterUser(UserRegistrationRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            if (request.User == null)
                throw new ArgumentException("Can't load current user");

            var result = new UserRegistrationResult();
            //if (request.User.IsSearchEngineAccount())
            //{
            //    result.AddError("Search engine can't be registered");
            //    return result;
            //}
            //if (request.User.IsBackgroundTaskAccount())
            //{
            //    result.AddError("Background task account can't be registered");
            //    return result;
            //}
            //if (request.User.IsRegistered())
            //{
            //    result.AddError("Current user is already registered");
            //    return result;
            //}
            //if (String.IsNullOrEmpty(request.Email))
            //{
            //    result.AddError(_localizationService.GetResource("Account.Register.Errors.EmailIsNotProvided"));
            //    return result;
            //}
            //if (!CommonHelper.IsValidEmail(request.Email))
            //{
            //    result.AddError(_localizationService.GetResource("Common.WrongEmail"));
            //    return result;
            //}
            //if (String.IsNullOrWhiteSpace(request.Password))
            //{
            //    result.AddError(_localizationService.GetResource("Account.Register.Errors.PasswordIsNotProvided"));
            //    return result;
            //}

            //if (String.IsNullOrEmpty(request.Username))
            //{
            //    result.AddError(_localizationService.GetResource("Account.Register.Errors.UsernameIsNotProvided"));
            //    return result;
            //}


            ////validate unique user
            //if (_userService.GetUserByEmail(request.Email) != null)
            //{
            //    result.AddError(_localizationService.GetResource("Account.Register.Errors.EmailAlreadyExists"));
            //    return result;
            //}
            //if (_userSettings.UsernamesEnabled)
            //{
            //    if (_userService.GetUserByUsername(request.Username) != null)
            //    {
            //        result.AddError(_localizationService.GetResource("Account.Register.Errors.UsernameAlreadyExists"));
            //        return result;
            //    }
            //}

            //at this point request is valid
            request.User.Username = request.Username;
            request.User.Email = request.Email;
            string saltKey = _encryptionService.CreateSaltKey(5);
            request.User.PasswordSalt = saltKey;
            request.User.Password = _encryptionService.CreatePasswordHash(request.Password, saltKey);


            request.User.Active = request.IsApproved;
            
            //add to 'Registered' role
            var registeredRole = _userService.GetUserRoleBySystemName(SystemUserRoleNames.Registered);
            if (registeredRole == null)
                throw new TeromacException("'Registered' role could not be loaded");
            request.User.UserRoles.Add(registeredRole);
            
            _userService.UpdateUser(request.User);
            return result;
        }
        
        /// <summary>
        /// Change password
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>Result</returns>
        public virtual ChangePasswordResult ChangePassword(ChangePasswordRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            var result = new ChangePasswordResult();
            //if (String.IsNullOrWhiteSpace(request.Email))
            //{
            //    result.AddError(_localizationService.GetResource("Account.ChangePassword.Errors.EmailIsNotProvided"));
            //    return result;
            //}
            //if (String.IsNullOrWhiteSpace(request.NewPassword))
            //{
            //    result.AddError(_localizationService.GetResource("Account.ChangePassword.Errors.PasswordIsNotProvided"));
            //    return result;
            //}

            var user = _userService.GetUserByEmail(request.Email);
            //if (user == null)
            //{
            //    result.AddError(_localizationService.GetResource("Account.ChangePassword.Errors.EmailNotFound"));
            //    return result;
            //}


            var requestIsValid = false;
            if (request.ValidateRequest)
            {
                //password
                string oldPwd = _encryptionService.CreatePasswordHash(request.OldPassword, user.PasswordSalt);


                bool oldPasswordIsValid = oldPwd == user.Password;
                //if (!oldPasswordIsValid)
                //    result.AddError(_localizationService.GetResource("Account.ChangePassword.Errors.OldPasswordDoesntMatch"));

                if (oldPasswordIsValid)
                    requestIsValid = true;
            }
            else
                requestIsValid = true;


            //at this point request is valid
            if (requestIsValid)
            {
                string saltKey = _encryptionService.CreateSaltKey(5);
                user.PasswordSalt = saltKey;
                user.Password = _encryptionService.CreatePasswordHash(request.NewPassword, saltKey);
                _userService.UpdateUser(user);
            }

            return result;
        }

        /// <summary>
        /// Sets a user email
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="newEmail">New email</param>
        public virtual void SetEmail(User user, string newEmail)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            if (newEmail == null)
                throw new TeromacException("Email cannot be null");

            newEmail = newEmail.Trim();
            string oldEmail = user.Email;

            //if (!CommonHelper.IsValidEmail(newEmail))
            //    throw new TeromacException(_localizationService.GetResource("Account.EmailUsernameErrors.NewEmailIsNotValid"));

            //if (newEmail.Length > 100)
            //    throw new TeromacException(_localizationService.GetResource("Account.EmailUsernameErrors.EmailTooLong"));

            //var user2 = _userService.GetUserByEmail(newEmail);
            //if (user2 != null && user.Id != user2.Id)
            //    throw new TeromacException(_localizationService.GetResource("Account.EmailUsernameErrors.EmailAlreadyExists"));

            user.Email = newEmail;
            _userService.UpdateUser(user);
        }

        /// <summary>
        /// Sets a user username
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="newUsername">New Username</param>
        public virtual void SetUsername(User user, string newUsername)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            newUsername = newUsername.Trim();

            //if (newUsername.Length > 100)
            //    throw new TeromacException(_localizationService.GetResource("Account.EmailUsernameErrors.UsernameTooLong"));

            //var user2 = _userService.GetUserByUsername(newUsername);
            //if (user2 != null && user.Id != user2.Id)
            //    throw new TeromacException(_localizationService.GetResource("Account.EmailUsernameErrors.UsernameAlreadyExists"));

            user.Username = newUsername;
            _userService.UpdateUser(user);
        }

        #endregion
    }
}