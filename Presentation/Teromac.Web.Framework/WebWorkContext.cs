using System;
using System.Linq;
using System.Web;
using Teromac.Core;
using Teromac.Core.Domain.Users;
using Teromac.Core.Fakes;
using Teromac.Services.Authentication;
using Teromac.Services.Common;
using Teromac.Services.Users;
using Teromac.Services.Helpers;
using Teromac.Core.Domain.Localization;
using Teromac.Services.Localization;

namespace Teromac.Web.Framework
{
    /// <summary>
    /// Work context for web application
    /// </summary>
    public partial class WebWorkContext : IWorkContext
    {
        #region Const

        private const string UserCookieName = "Teromac.user";

        #endregion

        #region Fields

        private readonly HttpContextBase _httpContext;
        private readonly IUserService _userService;
        private readonly ILanguageService _languageService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly IUserAgentHelper _userAgentHelper;

        private Language _cachedLanguage;
        private User _cachedUser;
        private User _originalUserIfImpersonated;

        #endregion

        #region Ctor

        public WebWorkContext(HttpContextBase httpContext,
            IUserService userService,
            ILanguageService languageService,
            IAuthenticationService authenticationService,
            IGenericAttributeService genericAttributeService,
            IUserAgentHelper userAgentHelper)
        {
            this._httpContext = httpContext;
            this._userService = userService;
            this._languageService = languageService;
            this._authenticationService = authenticationService;
            this._genericAttributeService = genericAttributeService;
            this._userAgentHelper = userAgentHelper;
        }

        #endregion

        #region Utilities

        protected virtual HttpCookie GetUserCookie()
        {
            if (_httpContext == null || _httpContext.Request == null)
                return null;

            return _httpContext.Request.Cookies[UserCookieName];
        }

        protected virtual void SetUserCookie(Guid userGuid)
        {
            if (_httpContext != null && _httpContext.Response != null)
            {
                var cookie = new HttpCookie(UserCookieName);
                cookie.HttpOnly = true;
                cookie.Value = userGuid.ToString();
                if (userGuid == Guid.Empty)
                {
                    cookie.Expires = DateTime.Now.AddMonths(-1);
                }
                else
                {
                    int cookieExpires = 24*365; //TODO make configurable
                    cookie.Expires = DateTime.Now.AddHours(cookieExpires);
                }

                _httpContext.Response.Cookies.Remove(UserCookieName);
                _httpContext.Response.Cookies.Add(cookie);
            }
        }

        protected virtual Language GetLanguageFromBrowserSettings()
        {
            if (_httpContext == null ||
                _httpContext.Request == null ||
                _httpContext.Request.UserLanguages == null)
                return null;

            var userLanguage = _httpContext.Request.UserLanguages.FirstOrDefault();
            if (String.IsNullOrEmpty(userLanguage))
                return null;

            var language = _languageService
                .GetAllLanguages()
                .FirstOrDefault(l => userLanguage.Equals(l.LanguageCulture, StringComparison.InvariantCultureIgnoreCase));
            if (language != null && language.Published)
            {
                return language;
            }

            return null;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the current user
        /// </summary>
        public virtual User CurrentUser
        {
            get
            {
                if (_cachedUser != null)
                    return _cachedUser;

                User user = null;
                if (_httpContext == null || _httpContext is FakeHttpContext)
                {
                    //check whether request is made by a background task
                    //in this case return built-in user record for background task
                    user = _userService.GetUserBySystemName(SystemUserNames.BackgroundTask);
                }

                //check whether request is made by a search engine
                //in this case return built-in user record for search engines 
                //or comment the following two lines of code in order to disable this functionality
                if (user == null || user.Deleted || !user.Active)
                {
                    if (_userAgentHelper.IsSearchEngine())
                        user = _userService.GetUserBySystemName(SystemUserNames.SearchEngine);
                }

                //registered user
                if (user == null || user.Deleted || !user.Active)
                {
                    user = _authenticationService.GetAuthenticatedUser();
                }

                //impersonate user if required (currently used for 'phone order' support)
                if (user != null && !user.Deleted && user.Active)
                {
                    var impersonatedUserId = user.GetAttribute<int?>(SystemUserAttributeNames.ImpersonatedUserId);
                    if (impersonatedUserId.HasValue && impersonatedUserId.Value > 0)
                    {
                        var impersonatedUser = _userService.GetUserById(impersonatedUserId.Value);
                        if (impersonatedUser != null && !impersonatedUser.Deleted && impersonatedUser.Active)
                        {
                            //set impersonated user
                            _originalUserIfImpersonated = user;
                            user = impersonatedUser;
                        }
                    }
                }

                ////load guest user
                //if (user == null || user.Deleted || !user.Active)
                //{
                //    var userCookie = GetUserCookie();
                //    if (userCookie != null && !String.IsNullOrEmpty(userCookie.Value))
                //    {
                //        Guid userGuid;
                //        if (Guid.TryParse(userCookie.Value, out userGuid))
                //        {
                //            var userByCookie = _userService.GetUserByGuid(userGuid);
                //            if (userByCookie != null &&
                //                //this user (from cookie) should not be registered
                //                !userByCookie.IsRegistered())
                //                user = userByCookie;
                //        }
                //    }
                //}

                //validation
                if (user != null && !user.Deleted && user.Active)
                {
                    SetUserCookie(user.UserGuid);
                    _cachedUser = user;
                }

                return _cachedUser;
            }
            set
            {
                SetUserCookie(value.UserGuid);
                _cachedUser = value;
            }
        }

        /// <summary>
        /// Gets or sets the original user (in case the current one is impersonated)
        /// </summary>
        public virtual User OriginalUserIfImpersonated
        {
            get
            {
                return _originalUserIfImpersonated;
            }
        }

        /// <summary>
        /// Get or set current user working language
        /// </summary>
        public virtual Language WorkingLanguage
        {
            get
            {
                if (_cachedLanguage != null)
                    return _cachedLanguage;

                Language detectedLanguage = null;
                //if (_localizationSettings.SeoFriendlyUrlsForLanguagesEnabled)
                //{
                //    //get language from URL
                //    detectedLanguage = GetLanguageFromUrl();
                //}
                if (detectedLanguage == null)
                {
                    //get language from browser settings
                    //but we do it only once
                    if (this.CurrentUser != null && !this.CurrentUser.GetAttribute<bool>(SystemUserAttributeNames.LanguageAutomaticallyDetected,
                        _genericAttributeService))
                    {
                        detectedLanguage = GetLanguageFromBrowserSettings();
                        if (detectedLanguage != null)
                        {
                            _genericAttributeService.SaveAttribute(this.CurrentUser, SystemUserAttributeNames.LanguageAutomaticallyDetected,
                                 true);
                        }
                    }
                }
                if (detectedLanguage != null && this.CurrentUser != null)
                {
                    //the language is detected. now we need to save it
                    if (this.CurrentUser.GetAttribute<int>(SystemUserAttributeNames.LanguageId,
                        _genericAttributeService) != detectedLanguage.Id)
                    {
                        _genericAttributeService.SaveAttribute(this.CurrentUser, SystemUserAttributeNames.LanguageId,
                            detectedLanguage.Id);
                    }
                }

                var allLanguages = _languageService.GetAllLanguages();
                var languageId = 0;
                if (this.CurrentUser != null)
                {
                    //find current customer language
                    languageId = this.CurrentUser.GetAttribute<int>(SystemUserAttributeNames.LanguageId,
                        _genericAttributeService);
                }
                var language = allLanguages.FirstOrDefault(x => x.Id == languageId);
                if (language == null)
                {
                    //it not found, then let's load the default currency for the current language (if specified)
                    //languageId = _storeContext.CurrentStore.DefaultLanguageId;
                    language = allLanguages.FirstOrDefault(x => x.Id == languageId);
                }
                if (language == null)
                {
                    //it not specified, then return the first (filtered by current store) found one
                    language = allLanguages.FirstOrDefault();
                }

                //cache
                _cachedLanguage = language;
                return _cachedLanguage;
            }
            set
            {
                var languageId = value != null ? value.Id : 0;
                _genericAttributeService.SaveAttribute(this.CurrentUser,
                    SystemUserAttributeNames.LanguageId,
                    languageId);

                //reset cache
                _cachedLanguage = null;
            }
        }

        /// <summary>
        /// Get or set value indicating whether we're in admin area
        /// </summary>
        public virtual bool IsAdmin { get; set; }

        #endregion
    }
}
