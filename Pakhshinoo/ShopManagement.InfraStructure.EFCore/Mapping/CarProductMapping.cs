
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.CarProductAgg;

namespace ShopManagement.InfraStructure.EFCore.Mapping
{
    public class CarProductMapping : IEntityTypeConfiguration<CarProduct>
    {
        public void Configure(EntityTypeBuilder<CarProduct> builder)
        {
            builder.ToTable("CarProducts");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Product).WithMany(x => x.CarProducts).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Car).WithMany(x => x.CarProducts).HasForeignKey(x => x.CarId);
        }
    }
}
