
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.SliderAgg;

namespace ShopManagement.InfraStructure.EFCore.Mapping
{
    public class SlideMapping : IEntityTypeConfiguration<Slide>
    {
        public void Configure(EntityTypeBuilder<Slide> builder)
        {
            builder.ToTable("Slides");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Picture).HasMaxLength(1000);
            builder.Property(x => x.PictureAlt).HasMaxLength(500).IsRequired();
            builder.Property(x => x.PictureTitle).HasMaxLength(500);
            builder.Property(x => x.Heading).HasMaxLength(500);
            builder.Property(x => x.Title).HasMaxLength(500);
            builder.Property(x => x.Text).HasMaxLength(500);
            builder.Property(x => x.BtnText).HasMaxLength(500);

        }
    }
}
