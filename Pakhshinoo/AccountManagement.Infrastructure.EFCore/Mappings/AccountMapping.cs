
using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagement.Infrastructure.EFCore.Mappings
{
    public class AccountMapping : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FullName).HasMaxLength(100);
            builder.Property(x => x.Password).HasMaxLength(200);
            builder.Property(x => x.Mobile).HasMaxLength(50);
            builder.Property(x => x.UserName).HasMaxLength(100);
            builder.Property(x => x.ProfilePhoto).HasMaxLength(100);
        }
    }
}