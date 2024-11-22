namespace backend.Data
{
    using backend.Models;
    using Microsoft.EntityFrameworkCore;
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

    }
}
