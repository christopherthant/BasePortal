using Teromac.Core.Domain.Users;

namespace Teromac.Data.Mapping.Users
{
    public partial class UserRoleMap : TeromacEntityTypeConfiguration<UserRole>
    {
        public UserRoleMap()
        {
            this.ToTable("UserRole");
            this.HasKey(cr => cr.Id);
            this.Property(cr => cr.Name).IsRequired().HasMaxLength(255);
            this.Property(cr => cr.SystemName).HasMaxLength(255);
        }
    }
}