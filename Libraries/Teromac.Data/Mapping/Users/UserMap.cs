using Teromac.Core.Domain.Users;

namespace Teromac.Data.Mapping.Users
{
    public partial class UserMap : TeromacEntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.ToTable("User");
            this.HasKey(c => c.Id);
            this.Property(u => u.Username).HasMaxLength(1000);
            this.Property(u => u.Email).HasMaxLength(1000);
            this.Property(u => u.SystemName).HasMaxLength(400);

            this.HasMany(c => c.UserRoles)
                .WithMany()
                .Map(u =>
                {
                    u.MapLeftKey("UserId");
                    u.MapRightKey("UserRoleId");
                    u.ToTable("UserUserRole");
                });
        }
    }
}