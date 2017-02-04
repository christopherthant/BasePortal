using System;
using System.Web.Mvc;
using Teromac.Core;
using Teromac.Core.Domain.Users;
using Teromac.Services.Authentication;
using Teromac.Services.Localization;
using Teromac.Services.Users;
using Teromac.Web.Models.User;

namespace Teromac.Web.Controllers
{
    public partial class CommonController : BasePublicController
    {
        #region Fields
        private readonly IWorkContext _workContext;
        private readonly IUserRegistrationService _userRegistrationService;
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;
        private readonly ILocalizationService _localizationService;
        #endregion

        #region Constructors

        public CommonController(IWorkContext workContext, 
                        IUserRegistrationService userRegistrationService,
                        IAuthenticationService authenticationService,
                        IUserService userService,
                        ILocalizationService localizationService)
        {
            this._workContext = workContext;
            this._userRegistrationService = userRegistrationService;
            this._authenticationService = authenticationService;
            this._userService = userService;
            this._localizationService = localizationService;
        }

        #endregion

        #region Utilities

        #endregion

        #region Methods
        public ActionResult AccessDenied(string pageUrl)
        {
            var currentUser = _workContext.CurrentUser;
            //if (currentCustomer == null || currentCustomer.IsGuest())
            //{
            //    _logger.Information(string.Format("Access denied to anonymous request on {0}", pageUrl));
            //    return View();
            //}

            //_logger.Information(string.Format("Access denied to user #{0} '{1}' on {2}", currentCustomer.Email, currentCustomer.Email, pageUrl));


            return View();
        }
        //page not found
        public ActionResult PageNotFound()
        {
            this.Response.StatusCode = 404;
            this.Response.TrySkipIisCustomErrors = true;

            return View();
        }

        #region Login / logout
        public ActionResult Login()
        {
            var model = new LoginModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (model.Username != null)
                {
                    model.Username = model.Username.Trim();
                }

                var loginResult = _userRegistrationService.ValidateUser(model.Username, model.Password);
                switch (loginResult)
                {
                    case UserLoginResults.Successful:
                        {
                            var user = _userService.GetUserByUsername(model.Username);

                            //sign in new user
                            _authenticationService.SignIn(user, model.RememberMe);

                            ////raise event       
                            //_eventPublisher.Publish(new UserLoggedinEvent(user));

                            ////activity log
                            //_userActivityService.InsertActivity("PublicStore.Login", _localizationService.GetResource("ActivityLog.PublicStore.Login"), user);

                            if (String.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
                                return RedirectToRoute("HomePage");

                            return Redirect(returnUrl);
                        }
                    case UserLoginResults.UserNotExist:
                        ModelState.AddModelError("", _localizationService.GetResource("Account.Login.WrongCredentials.UserNotExist"));
                        break;
                    case UserLoginResults.Deleted:
                        ModelState.AddModelError("", _localizationService.GetResource("Account.Login.WrongCredentials.Deleted"));
                        break;
                    case UserLoginResults.NotActive:
                        ModelState.AddModelError("", _localizationService.GetResource("Account.Login.WrongCredentials.NotActive"));
                        break;
                    case UserLoginResults.NotRegistered:
                        ModelState.AddModelError("", _localizationService.GetResource("Account.Login.WrongCredentials.NotRegistered"));
                        break;
                    case UserLoginResults.WrongPassword:
                    default:
                        ModelState.AddModelError("", _localizationService.GetResource("Account.Login.WrongCredentials"));
                        break;
                }
            }

            //If we got this far, something failed, redisplay form
            return View(model);
        }

        public ActionResult Logout()
        {
            ////activity log
            // _userActivityService.InsertActivity("PublicStore.Logout", _localizationService.GetResource("ActivityLog.PublicStore.Logout"));
            //standard logout 
            _authenticationService.SignOut();

            return RedirectToRoute("HomePage");
        }
        #endregion
        #endregion
    }
}
