using System.Web.Mvc;

namespace Teromac.Web.Controllers
{
    public partial class PurchasingController : BasePrivateController
    {
        // GET: Purchasing
        public ActionResult Index()
        {
            return View();
        }
    }
}