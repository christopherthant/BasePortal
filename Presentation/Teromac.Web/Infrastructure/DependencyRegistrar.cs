using Autofac;
using Autofac.Core;
using Teromac.Core.Caching;
using Teromac.Core.Configuration;
using Teromac.Core.Infrastructure;
using Teromac.Core.Infrastructure.DependencyManagement;
using Teromac.Web.Controllers;

namespace Teromac.Web.Infrastructure
{
    /// <summary>
    /// Dependency registrar
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, TeromacConfig config)
        {

        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order
        {
            get { return 2; }
        }
    }
}
