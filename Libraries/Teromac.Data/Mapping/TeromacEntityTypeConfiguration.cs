using System.Data.Entity.ModelConfiguration;

namespace Teromac.Data.Mapping
{
    public abstract class TeromacEntityTypeConfiguration<T> : EntityTypeConfiguration<T> where T : class
    {
        protected TeromacEntityTypeConfiguration()
        {
            PostInitialize();
        }

        /// <summary>
        /// Developers can override this method in custom partial classes
        /// in order to add some custom initialization code to constructors
        /// </summary>
        protected virtual void PostInitialize()
        {
            
        }
    }
}