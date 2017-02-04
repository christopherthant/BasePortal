using System.Web.Mvc;
using System.Web.Routing;
using Teromac.Core.Infrastructure;
using Teromac.Web.Framework;
using Teromac.Web.Framework.Controllers;
using Teromac.Web.Framework.Security;

namespace Teromac.Web.Controllers
{
    public abstract partial class BasePublicController : BaseController
    {
        protected virtual ActionResult InvokeHttp404()
        {
            // Call target Controller and pass the routeData.
            IController errorController = EngineContext.Current.Resolve<CommonController>();

            var routeData = new RouteData();
            routeData.Values.Add("controller", "Common");
            routeData.Values.Add("action", "PageNotFound");

            errorController.Execute(new RequestContext(this.HttpContext, routeData));

            return new EmptyResult();
        }

    }
}
