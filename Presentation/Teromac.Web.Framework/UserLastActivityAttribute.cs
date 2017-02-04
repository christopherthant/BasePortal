using System;
using System.Web.Mvc;
using Teromac.Core;
using Teromac.Core.Data;
using Teromac.Core.Infrastructure;
using Teromac.Services.Users;

namespace Teromac.Web.Framework
{
    public class UserLastActivityAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!DataSettingsHelper.DatabaseIsInstalled())
                return;

            if (filterContext == null || filterContext.HttpContext == null || filterContext.HttpContext.Request == null)
                return;

            //don't apply filter to child methods
            if (filterContext.IsChildAction)
                return;

            //only GET requests
            if (!String.Equals(filterContext.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
                return;

            var workContext = EngineContext.Current.Resolve<IWorkContext>();
            var User = workContext.CurrentUser;

            //update last activity date
            if (User != null && User.LastActivityDateUtc.AddMinutes(1.0) < DateTime.UtcNow)
            {
                var UserService = EngineContext.Current.Resolve<IUserService>();
                User.LastActivityDateUtc = DateTime.UtcNow;
                UserService.UpdateUser(User);
            }
        }
    }
}
