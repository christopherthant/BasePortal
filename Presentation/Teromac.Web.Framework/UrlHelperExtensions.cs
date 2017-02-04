using System.Web.Mvc;

namespace Teromac.Web.Framework
{
    public static class UrlHelperExtensions
    {
        public static string LogOn(this UrlHelper urlHelper, string returnUrl)
        {
            if (!string.IsNullOrEmpty(returnUrl))
                return urlHelper.Action("Login", "User", new { ReturnUrl = returnUrl });
            return urlHelper.Action("Login", "User");
        }

        public static string LogOff(this UrlHelper urlHelper, string returnUrl)
        {
            if (!string.IsNullOrEmpty(returnUrl))
                return urlHelper.Action("Logout", "User", new { ReturnUrl = returnUrl });
            return urlHelper.Action("Logout", "User");
        }
    }
}
