
using AccountManagement.Domain.ProfileAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagement.Infrastructure.EFCore.Mappings
{
    public class ProfileMapping : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.ToTable("Profiles");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CompanyName).HasMaxLength(100);
            builder.Property(x => x.Email).HasMaxLength(200);
            builder.Property(x => x.PostalCode).HasMaxLength(50);
            builder.Property(x => x.PictureCoworker).HasMaxLength(100);
        }
    }
}
