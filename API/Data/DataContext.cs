using Microsoft.EntityFrameworkCore;
using API.Entities;
using API.Models;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Sitter> Sitters { get; set; }
    }
}