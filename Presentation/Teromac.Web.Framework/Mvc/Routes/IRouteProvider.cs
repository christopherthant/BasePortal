using System.Web.Routing;

namespace Teromac.Web.Framework.Mvc.Routes
{
    public interface IRouteProvider
    {
        void RegisterRoutes(RouteCollection routes);

        int Priority { get; }
    }
}
