using Microsoft.EntityFrameworkCore;
using OnlineMenu.Models;
using OnlineMenu.Models.ViewModels;

namespace OnlineMenu.Data
{
    public class OnlineMenuDbContext : DbContext
    {
        public OnlineMenuDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
