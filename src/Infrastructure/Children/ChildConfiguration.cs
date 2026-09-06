using Domain.Children;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Children;

internal sealed class ChildConfiguration : IEntityTypeConfiguration<Child>
{
    public void Configure(EntityTypeBuilder<Child> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasIndex(c => c.UserId);
    }
}
