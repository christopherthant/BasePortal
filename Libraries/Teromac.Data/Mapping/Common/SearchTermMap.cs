using Teromac.Core.Domain.Common;

namespace Teromac.Data.Mapping.Common
{
    public partial class SearchTermMap : TeromacEntityTypeConfiguration<SearchTerm>
    {
        public SearchTermMap()
        {
            this.ToTable("SearchTerm");
            this.HasKey(st => st.Id);
        }
    }
}
