
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.CompanyProductAgg;

namespace ShopManagement.InfraStructure.EFCore.Mapping
{
    public class CompanyProductMapping : IEntityTypeConfiguration<CompanyProduct>
    {
        public void Configure(EntityTypeBuilder<CompanyProduct> builder)
        {
            builder.ToTable("CompanyProducts");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Product).WithMany(x => x.CompanyProducts).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Company).WithMany(x => x.CompanyProducts).HasForeignKey(x => x.CompanyId);
        }
    }
}
