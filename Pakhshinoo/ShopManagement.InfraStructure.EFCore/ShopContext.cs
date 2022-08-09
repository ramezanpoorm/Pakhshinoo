using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.BrandAgg;
using ShopManagement.Domain.CarAgg;
using ShopManagement.Domain.CarProductAgg;
using ShopManagement.Domain.CompanyAgg;
using ShopManagement.Domain.CompanyProductAgg;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Domain.SliderAgg;
using ShopManagement.InfraStructure.EFCore.Mapping;

namespace ShopManagement.InfraStructure.EFCore
{
    public class ShopContext:DbContext
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyProduct> CompanyProducts { get; set; }
        public DbSet<CarProduct> CarProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public ShopContext(DbContextOptions<ShopContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ProductCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
