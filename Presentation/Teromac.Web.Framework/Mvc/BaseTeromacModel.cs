using System.Collections.Generic;
using System.Web.Mvc;

namespace Teromac.Web.Framework.Mvc
{
    /// <summary>
    /// Base nopCommerce model
    /// </summary>
    [ModelBinder(typeof(TeromacModelBinder))]
    public partial class BaseTeromacModel
    {
        public BaseTeromacModel()
        {
            this.CustomProperties = new Dictionary<string, object>();
            PostInitialize();
        }

        public virtual void BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
        }

        /// <summary>
        /// Developers can override this method in custom partial classes
        /// in order to add some custom initialization code to constructors
        /// </summary>
        protected virtual void PostInitialize()
        {
            
        }

        /// <summary>
        /// Use this property to store any custom value for your models. 
        /// </summary>
        public Dictionary<string, object> CustomProperties { get; set; }
    }

    /// <summary>
    /// Base nopCommerce entity model
    /// </summary>
    public partial class BaseTeromacEntityModel : BaseTeromacModel
    {
        public virtual int Id { get; set; }
    }
}
