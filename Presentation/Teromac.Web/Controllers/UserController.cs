using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Teromac.Core;
using Teromac.Core.Domain.Users;
using Teromac.Core.Domain.Security;
using Teromac.Services.Authentication;
using Teromac.Services.Common;
using Teromac.Services.Users;
using Teromac.Services.Directory;
using Teromac.Services.Events;
using Teromac.Services.Helpers;
using Teromac.Services.Security;
using Teromac.Web.Framework.Controllers;
using Teromac.Web.Models.User;

namespace Teromac.Web.Controllers
{
    public partial class UserController : BasePrivateController
    {
        #region Fields
        private readonly IAuthenticationService _authenticationService;
        private readonly IDateTimeHelper _dateTimeHelper;
        private readonly IWorkContext _workContext;
        private readonly IUserService _userService;
        private readonly IUserRegistrationService _userRegistrationService;
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly UserSettings _userSettings;
        private readonly ICountryService _countryService;
        private readonly IStateProvinceService _stateProvinceService;
        private readonly IWebHelper _webHelper;
        private readonly IEventPublisher _eventPublisher;
        private readonly SecuritySettings _securitySettings;
        private readonly IPermissionService _permissionService;

        #endregion

        #region Ctor

        public UserController(IAuthenticationService authenticationService,
            IDateTimeHelper dateTimeHelper,
            IWorkContext workContext,
            IUserService userService,
            IUserRegistrationService userRegistrationService,
            IGenericAttributeService genericAttributeService,
            UserSettings userSettings,
            ICountryService countryService,
            IStateProvinceService stateProvinceService,
            IWebHelper webHelper,
            IEventPublisher eventPublisher,
            SecuritySettings securitySettings,
            IPermissionService permissionService)
        {
            this._authenticationService = authenticationService;
            this._dateTimeHelper = dateTimeHelper;
            this._workContext = workContext;
            this._userService = userService;
            this._userRegistrationService = userRegistrationService;
            this._genericAttributeService = genericAttributeService;
            this._userSettings = userSettings;
            this._countryService = countryService;
            this._stateProvinceService = stateProvinceService;
            this._webHelper = webHelper;
            this._eventPublisher = eventPublisher;
            this._permissionService = permissionService;
        }

        #endregion

        #region Utilities
        [NonAction]
        protected virtual void PrepareUserModel(UserModel model, User user, bool excludeProperties)
        {
            if (user != null)
            {
                model.Id = user.Id;
                if (!excludeProperties)
                {
                    model.Email = user.Email;
                    model.Username = user.Username;
                    //model.Active = user.Active;

                    //form fields
                    model.FirstName = user.GetAttribute<string>(SystemUserAttributeNames.FirstName);
                    model.LastName = user.GetAttribute<string>(SystemUserAttributeNames.LastName);
                    model.Phone = user.GetAttribute<string>(SystemUserAttributeNames.Phone);
                }
            }

            ////user roles
            //var allRoles = _userService.GetAllUserRoles(true);
            //var adminRole = allRoles.FirstOrDefault(c => c.SystemName == SystemUserRoleNames.Registered);
            ////precheck Registered Role as a default role while creating a new user through admin
            //if (user == null && adminRole != null)
            //{
            //    model.SelectedUserRoleIds.Add(adminRole.Id);
            //}
            //foreach (var role in allRoles)
            //{
            //    model.AvailableUserRoles.Add(new SelectListItem
            //    {
            //        Text = role.Name,
            //        Value = role.Id.ToString(),
            //        Selected = model.SelectedUserRoleIds.Contains(role.Id)
            //    });
            //}
        }

        [NonAction]
        protected virtual string ValidateUserRoles(IList<UserRole> userRoles)
        {
            if (userRoles == null)
                throw new ArgumentNullException("userRoles");

            //ensure a customer is not added to both 'Guests' and 'Registered' customer roles
            //ensure that a customer is in at least one required role ('Guests' and 'Registered')
            bool isInRegisteredRole = userRoles.FirstOrDefault(cr => cr.SystemName == SystemUserRoleNames.Registered) != null;
            //if (isInRegisteredRole)
            //    return "The customer cannot be in both 'Guests' and 'Registered' customer roles";
            //if (!isInGuestsRole && !isInRegisteredRole)
            //    return "Add the customer to 'Guests' or 'Registered' customer role";

            //no errors
            return "";
        }
        #endregion

        public ActionResult Create()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageUsers))
                return AccessDeniedView();

            var model = new UserModel();
            PrepareUserModel(model, null, false);
            //default value
            //model.Active = true;
            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        [FormValueRequired("save", "save-continue")]
        [ValidateInput(false)]
        public ActionResult Create(UserModel model, bool continueEditing, FormCollection form)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageUsers))
                return AccessDeniedView();

            var cust2 = _userService.GetUserByUsername(model.Username);
            if (cust2 != null)
                ModelState.AddModelError("", "Username is already registered");


            //validate user roles
            var allUserRoles = _userService.GetAllUserRoles(true);
            var newUserRoles = new List<UserRole>();
            foreach (var userRole in allUserRoles)
                if (model.SelectedUserRoleIds.Contains(userRole.Id))
                    newUserRoles.Add(userRole);
            var userRolesError = ValidateUserRoles(newUserRoles);
            if (!String.IsNullOrEmpty(userRolesError))
            {
                ModelState.AddModelError("", userRolesError);
                ErrorNotification(userRolesError, false);
            }

            // Ensure that valid email address is entered if Registered role is checked to avoid registered users with empty email address
            if (newUserRoles.Any() && newUserRoles.FirstOrDefault(c => c.SystemName == SystemUserRoleNames.Registered) != null && !CommonHelper.IsValidEmail(model.Email))
            {
                ModelState.AddModelError("", "Valid Email is required for user to be in 'Registered' role");
                ErrorNotification("Valid Email is required for user to be in 'Registered' role", false);
            }

            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserGuid = Guid.NewGuid(),
                    Email = model.Email,
                    Username = model.Username,
                    Active = model.Active,
                    CreatedOnUtc = DateTime.UtcNow,
                    LastActivityDateUtc = DateTime.UtcNow,
                };
                _userService.InsertUser(user);

                ////custom user attributes
                //var userAttributes = ParseCustomUserAttributes(user, form);
                //_genericAttributeService.SaveAttribute(user, SystemUserAttributeNames.CustomUserAttributes, userAttributes);
            
                //password
                if (!String.IsNullOrWhiteSpace(model.Password))
                {
                    var changePassRequest = new ChangePasswordRequest(model.Email, false, model.Password);
                    var changePassResult = _userRegistrationService.ChangePassword(changePassRequest);
                    if (!changePassResult.Success)
                    {
                        foreach (var changePassError in changePassResult.Errors)
                            ErrorNotification(changePassError);
                    }
                }

                //user roles
                foreach (var userRole in newUserRoles)
                {
                    //ensure that the current user cannot add to "Administrators" system role if he's not an admin himself
                    if (userRole.SystemName == SystemUserRoleNames.Administrators &&
                        !_workContext.CurrentUser.IsAdmin())
                        continue;

                    user.UserRoles.Add(userRole);
                }
                _userService.UpdateUser(user);

                ////activity log
                //_userActivityService.InsertActivity("AddNewUser", _localizationService.GetResource("ActivityLog.AddNewUser"), user.Id);

                //SuccessNotification(_localizationService.GetResource("Admin.Users.Users.Added"));

                //if (continueEditing)
                //{
                //    //selected tab
                //    SaveSelectedTabName();

                //    return RedirectToAction("Edit", new { id = user.Id });
                //}
                return RedirectToAction("List");
            }

            //If we got this far, something failed, redisplay form
            PrepareUserModel(model, null, true);
            return View(model);
        }

    }
}
