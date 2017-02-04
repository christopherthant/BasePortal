namespace Teromac.Web.Framework.Mvc
{
    public class DeleteConfirmationModel : BaseTeromacEntityModel
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string WindowId { get; set; }
    }
}