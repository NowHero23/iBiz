using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebShopProject.Models;

namespace WebShopProject.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => { entity.HasIndex(e => e.Email).IsUnique();
                entity.HasIndex(e => e.Login).IsUnique();
            });

            //base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        
        public DbSet<Location> Locations { get; set; } //temp
        public DbSet<Manufacture> Manufactures { get; set; }

        public DbSet<ProdectItem> ProdectItems { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        public DbSet<ProductSubCategory> ProductSubCategories { get; set; }
        public DbSet<Review> Reviews { get; set; }
       
        
    }
}
