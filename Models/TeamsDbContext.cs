using Microsoft.EntityFrameworkCore;

namespace kolokwium_2_poprawa_ko_s22454.Models
{
    public class TeamsDbContext : DbContext
    {
        public DbSet<File> Files { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Membership> Memberships { get; set; }

        public TeamsDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<File>(e =>
            {
                e.HasKey(e => new {e.FileID, e.TeamID});
                e.Property(e => e.FileName).HasMaxLength(100).IsRequired();
                e.Property(e => e.FileExtension).HasMaxLength(4).IsRequired();
                e.Property(e => e.FileSize).IsRequired();
                
                e.ToTable("File");
            });
            
            modelBuilder.Entity<Team>(e =>
            {
                e.HasKey(e => e.TeamID);
                e.Property(e => e.OrganizationID).IsRequired();
                e.Property(e => e.TeamsName).HasMaxLength(50).IsRequired();
                e.Property(e => e.TeamDescription).HasMaxLength(500).IsRequired();
                
                e.ToTable("Team");
            });
            
            modelBuilder.Entity<Organization>(e =>
            {
                e.HasKey(e => e.OrganizationID);
                e.Property(e => e.OrganizationName).HasMaxLength(100).IsRequired();
                e.Property(e => e.OrganizationDomain).HasMaxLength(50).IsRequired();
                
                e.ToTable("Organization");
            });
            
            modelBuilder.Entity<Member>(e =>
            {
                e.HasKey(e => e.MemberID);
                e.Property(e => e.OrganizationID).IsRequired();
                e.Property(e => e.MemberName).HasMaxLength(20).IsRequired();
                e.Property(e => e.MemberSurname).HasMaxLength(50).IsRequired();
                e.Property(e => e.MemberNickName).HasMaxLength(50);
                
                e.ToTable("Member");
            });
            
            modelBuilder.Entity<Membership>(e =>
            {
                e.HasKey(e => new {e.MemberID, e.TeamID});
                e.Property(e => e.MembershipDate).IsRequired();

                e.HasOne(e => e.Member)
                    .WithMany(e => e.Memberships)
                    .HasForeignKey(e => e.MemberID)
                    .OnDelete(DeleteBehavior.NoAction);

                e.HasOne(e => e.Team)
                    .WithMany(e => e.Memberships)
                    .HasForeignKey(e => e.TeamID)
                    .OnDelete(DeleteBehavior.NoAction);

                e.ToTable("Membership");
            });
        }
    }
}