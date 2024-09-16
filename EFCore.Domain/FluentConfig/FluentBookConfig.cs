namespace EFCore.Domain.FluentConfig;

using FluentEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public partial class EntityConfig : IEntityTypeConfiguration<Fluent_BookEntity>
{
  public void Configure(EntityTypeBuilder<Fluent_BookEntity> modelBuilder)
  {
    // primary key
    modelBuilder.HasKey(u => u.Id);

    // properties
    modelBuilder
      .Property(u => u.Isbn)
      .HasMaxLength(50)
      .IsRequired();
    modelBuilder.Ignore(u => u.PriceRange);
    modelBuilder
      .Property(u => u.Price)
      .HasPrecision(10, 5);

    // relationships
    modelBuilder
      .HasOne(u => u.Publisher)
      .WithMany(u => u.Books)
      .HasForeignKey(u => u.Publisher_Id);
  }
}

