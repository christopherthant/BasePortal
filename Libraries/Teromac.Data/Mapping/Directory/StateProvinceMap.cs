using Teromac.Core.Domain.Directory;

namespace Teromac.Data.Mapping.Directory
{
    public partial class StateProvinceMap : TeromacEntityTypeConfiguration<StateProvince>
    {
        public StateProvinceMap()
        {
            this.ToTable("StateProvince");
            this.HasKey(sp => sp.Id);
            this.Property(sp => sp.Name).IsRequired().HasMaxLength(100);
            this.Property(sp => sp.Abbreviation).HasMaxLength(100);


            this.HasRequired(sp => sp.Country)
                .WithMany(c => c.StateProvinces)
                .HasForeignKey(sp => sp.CountryId);
        }
    }
}