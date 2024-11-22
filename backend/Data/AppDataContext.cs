namespace backend.Data
{
    using backend.Models;
    using Microsoft.EntityFrameworkCore;
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<TalentProfile> TalentProfiles { get; set; }
        public DbSet<StartupProfile> StartupProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TalentProfile -> User (One-to-One)
            modelBuilder.Entity<TalentProfile>()
                .HasOne(tp => tp.User)
                .WithMany()// Navigation from TalentProfile to Use
                .HasForeignKey(tp=>tp.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Foreign Key in TalentProfile

            // StartupProfile -> User (One-to-One)
            modelBuilder.Entity<StartupProfile>()
                .HasOne(sp => sp.User) // Navigation from StartupProfile to User
                .WithOne() // Navigation from User to StartupProfile
                .HasForeignKey<StartupProfile>(sp => sp.UserId).OnDelete(DeleteBehavior.Cascade); // Foreign Key in StartupProfile
        }

    }
}
