using Autofac;
using Teromac.Core.Caching;
using Teromac.Core.Configuration;
using Teromac.Core.Infrastructure;
using Teromac.Core.Infrastructure.DependencyManagement;
namespace Teromac.Services.Tests
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
            //cache managers
           builder.RegisterType<TeromacNullCache>().As<ICacheManager>().Named<ICacheManager>("nop_cache_static").SingleInstance();

        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order
        {
            get { return 0; }
        }
    }

}
