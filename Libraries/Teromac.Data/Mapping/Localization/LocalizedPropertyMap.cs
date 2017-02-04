using Teromac.Core.Domain.Localization;

namespace Teromac.Data.Mapping.Localization
{
    public partial class LocalizedPropertyMap : TeromacEntityTypeConfiguration<LocalizedProperty>
    {
        public LocalizedPropertyMap()
        {
            this.ToTable("LocalizedProperty");
            this.HasKey(lp => lp.Id);

            this.Property(lp => lp.LocaleKeyGroup).IsRequired().HasMaxLength(400);
            this.Property(lp => lp.LocaleKey).IsRequired().HasMaxLength(400);
            this.Property(lp => lp.LocaleValue).IsRequired();
            
            this.HasRequired(lp => lp.Language)
                .WithMany()
                .HasForeignKey(lp => lp.LanguageId);
        }
    }
}