using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LiveSportNotification.Models
{
    public class Match
    {
        public long Id { get; set; }
        public long Team1Id { get; set; }
        public long Team2Id { get; set; }
        public long Team1Goals { get; set; }
        public long Team2Goals { get; set; }
        public string? Date { get; set; }

        // Navigation properties
        public virtual Team Team1 { get; set; }
        public virtual Team Team2 { get; set; }
    }
    public class ConfigurationTeam : IEntityTypeConfiguration<Team>
    {
        public virtual void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(100);
            builder.Property(t => t.Logo).HasMaxLength(500);

            builder.HasMany(t => t.HomeMatches)
                .WithOne(m => m.Team1)  // Use the Team1 navigation property in Match class
                .HasForeignKey(m => m.Team1Id)
                .IsRequired();

            builder.HasMany(t => t.AwayMatches)
                .WithOne(m => m.Team2)  // Use the Team2 navigation property in Match class
                .HasForeignKey(m => m.Team2Id)
                .IsRequired();
        }
    }
}
