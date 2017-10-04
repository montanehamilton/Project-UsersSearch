using Microsoft.EntityFrameworkCore;

namespace UsersSearch.Users
{
    public class UsersSearchDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Avatar> Avatars { get; set; }
        public DbSet<Interest> Interests { get; set; }

        public UsersSearchDbContext(DbContextOptions<UsersSearchDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
