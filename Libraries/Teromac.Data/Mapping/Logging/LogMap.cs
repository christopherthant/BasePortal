using Teromac.Core.Domain.Logging;

namespace Teromac.Data.Mapping.Logging
{
    public partial class LogMap : TeromacEntityTypeConfiguration<Log>
    {
        public LogMap()
        {
            this.ToTable("Log");
            this.HasKey(l => l.Id);
            this.Property(l => l.ShortMessage).IsRequired();
            this.Property(l => l.IpAddress).HasMaxLength(200);

            this.Ignore(l => l.LogLevel);

            this.HasOptional(l => l.User)
                .WithMany()
                .HasForeignKey(l => l.UserId)
            .WillCascadeOnDelete(true);

        }
    }
}