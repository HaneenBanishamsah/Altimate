using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;

namespace DataCenter
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Food> Foods { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Menu> Menus { get; set; }
    }
}
