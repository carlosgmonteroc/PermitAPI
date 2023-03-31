using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Permit.Domain.Entities;

namespace Permit.Persistence.Configurations
{
    internal class PermitTypeConfiguration : IEntityTypeConfiguration<PermitType>
    {
        public void Configure(EntityTypeBuilder<PermitType> builder)
        {
            builder.ToTable("PermitType");

            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Description)
                .HasColumnName("Description")
                .IsRequired();

            builder.Property(p => p.CreatedAt)
                .HasColumnName("CreatedAt")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.LastUpdatedAt)
                .HasColumnName("LastUpdatedAt")
                .IsRequired()
                .ValueGeneratedOnUpdate();

            builder.HasMany(p => p.Permits)
                .WithOne(p => p.PermitType)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
