using Teromac.Core.Domain.Security;

namespace Teromac.Data.Mapping.Security
{
    public partial class PermissionRecordMap : TeromacEntityTypeConfiguration<PermissionRecord>
    {
        public PermissionRecordMap()
        {
            this.ToTable("PermissionRecord");
            this.HasKey(pr => pr.Id);
            this.Property(pr => pr.Name).IsRequired();
            this.Property(pr => pr.SystemName).IsRequired().HasMaxLength(255);
            this.Property(pr => pr.Category).IsRequired().HasMaxLength(255);

            this.HasMany(pr => pr.UserRoles)
                .WithMany(cr => cr.PermissionRecords)
                .Map(p =>
                {
                    p.MapLeftKey("PermissionRecordId");
                    p.MapRightKey("UserRoleId");
                    p.ToTable("PermissionRecordUserRole");
                });
        }
    }
}