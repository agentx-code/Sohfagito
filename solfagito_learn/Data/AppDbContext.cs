using Microsoft.EntityFrameworkCore;
using solfagito_learn.Models;
using solfagito_learn.Models.Products;
using solfagito_learn.Models.Users;

namespace solfagito_learn.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Roles> Role { get; set; }
        public DbSet<Users> User {  get; set; }
        public DbSet<Categorys> Category { get; set; }
        public DbSet<Products> Product { get; set; }
    }
}
