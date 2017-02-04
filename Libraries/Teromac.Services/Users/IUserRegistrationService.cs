using Teromac.Core.Domain.Users;

namespace Teromac.Services.Users
{
    /// <summary>
    /// User registration interface
    /// </summary>
    public partial interface IUserRegistrationService
    {
        /// <summary>
        /// Validate user
        /// </summary>
        /// <param name="usernameOrEmail">Username or email</param>
        /// <param name="password">Password</param>
        /// <returns>Result</returns>
        UserLoginResults ValidateUser(string usernameOrEmail, string password);

        /// <summary>
        /// Register user
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>Result</returns>
        UserRegistrationResult RegisterUser(UserRegistrationRequest request);

        /// <summary>
        /// Change password
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>Result</returns>
        ChangePasswordResult ChangePassword(ChangePasswordRequest request);

        /// <summary>
        /// Sets a user email
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="newEmail">New email</param>
        void SetEmail(User user, string newEmail);

        /// <summary>
        /// Sets a user username
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="newUsername">New Username</param>
        void SetUsername(User user, string newUsername);
    }
}