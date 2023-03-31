using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Permit.Domain.Entities;

namespace Permit.Persistence.Configurations
{
    internal class PermitConfiguration : IEntityTypeConfiguration<Domain.Entities.Permit>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Permit> builder)
        {
            builder.ToTable("Permit");

            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.FirstName)
                .HasColumnName("FirstName")
                .IsRequired();

            builder.Property(p => p.LastName)
                .HasColumnName("LastName")
                .IsRequired();

            builder.Property(p => p.CreatedAt)
                .HasColumnName("CreatedAt")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.LastUpdatedAt)
                .HasColumnName("LastUpdatedAt")
                .IsRequired()
                .ValueGeneratedOnUpdate();

            builder.HasOne(p => p.PermitType)
                .WithMany(p => p.Permits)
                .HasForeignKey(p => p.PermitTypeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
