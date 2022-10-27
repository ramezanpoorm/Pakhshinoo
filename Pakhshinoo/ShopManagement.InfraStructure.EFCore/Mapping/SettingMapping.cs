
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.SettingAgg;

namespace ShopManagement.InfraStructure.EFCore.Mapping
{
    public class SettingMapping : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.ToTable("Settings");
            builder.HasKey(x => x.Id);                       
        }
    }
}
