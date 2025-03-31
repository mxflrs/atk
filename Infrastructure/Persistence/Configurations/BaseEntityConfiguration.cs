using atk_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace atk_api.Infrastructure.Persistence.Configurations;

public class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T>
where T : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.ModifiedAt)
            .HasColumnType("timestamp without time zone")
            .IsRequired(false);

        builder.Property(e => e.CreatedAt)
            .HasColumnType("timestamp without time zone")
            .HasDefaultValueSql("now()")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Id)
            .UseIdentityAlwaysColumn();
    }
}