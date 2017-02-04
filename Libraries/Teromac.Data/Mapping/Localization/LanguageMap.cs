using Teromac.Core.Domain.Localization;

namespace Teromac.Data.Mapping.Localization
{
    public partial class LanguageMap : TeromacEntityTypeConfiguration<Language>
    {
        public LanguageMap()
        {
            this.ToTable("Language");
            this.HasKey(l => l.Id);
            this.Property(l => l.Name).IsRequired().HasMaxLength(100);
            this.Property(l => l.LanguageCulture).IsRequired().HasMaxLength(20);
            this.Property(l => l.UniqueSeoCode).HasMaxLength(2);       
        }
    }
}