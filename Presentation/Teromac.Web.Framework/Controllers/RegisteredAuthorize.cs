using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Teromac.Core.Infrastructure;
using Teromac.Services.Security;

namespace Teromac.Web.Framework.Controllers
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited=true, AllowMultiple=true)]
    public class RegisteredAuthorize : FilterAttribute, IAuthorizationFilter
    {
        private readonly bool _dontValidate;


        public RegisteredAuthorize()
            : this(false)
        {
        }

        public RegisteredAuthorize(bool dontValidate)
        {
            this._dontValidate = dontValidate;
        }

        private void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }

        private IEnumerable<RegisteredAuthorize> GetRegisteredAuthorizeAttributes(ActionDescriptor descriptor)
        {
            return descriptor.GetCustomAttributes(typeof(RegisteredAuthorize), true)
                .Concat(descriptor.ControllerDescriptor.GetCustomAttributes(typeof(RegisteredAuthorize), true))
                .OfType<RegisteredAuthorize>();
        }

        private bool IsRegisteredPageRequested(AuthorizationContext filterContext)
        {
            var adminAttributes = GetRegisteredAuthorizeAttributes(filterContext.ActionDescriptor);
            if (adminAttributes != null && adminAttributes.Any())
                return true;
            return false;
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (_dontValidate)
                return;

            if (filterContext == null)
                throw new ArgumentNullException("filterContext");

            if (OutputCacheAttribute.IsChildActionCacheActive(filterContext))
                throw new InvalidOperationException("You cannot use [RegisteredAuthorize] attribute when a child action cache is active");

            if (IsRegisteredPageRequested(filterContext))
            {
                if (!this.HasRegisteredPageAccess(filterContext))
                    this.HandleUnauthorizedRequest(filterContext);
            }
        }

        public virtual bool HasRegisteredPageAccess(AuthorizationContext filterContext)
        {
            var permissionService = EngineContext.Current.Resolve<IPermissionService>();
            bool result = permissionService.Authorize(StandardPermissionProvider.AccessAdminPanel);
            return result;
        }
    }
}
