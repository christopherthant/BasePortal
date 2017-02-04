using System.Web.Mvc;

namespace Teromac.Web.Controllers
{
    public partial class HomeController : BasePrivateController
    {
        #region Fields

        #endregion

        #region Ctor

        public HomeController()
        { 
        }

        #endregion

        #region Methods

        public ActionResult Index()
        {
            return View();
        }

        #endregion
    }
}
