namespace EFCore.Domain.FluentConfig;

using EFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public partial class EntityConfig : IEntityTypeConfiguration<BookEntity>
{
  public void Configure(EntityTypeBuilder<BookEntity> modelBuilder)
  {
    // primary key
    modelBuilder.HasKey(bookEntity => bookEntity.Id);
    // properties
    modelBuilder.Property(bookEntity => bookEntity.Isbn).HasMaxLength(50).IsRequired();
    modelBuilder.Ignore(bookEntity => bookEntity.PriceRange);
    modelBuilder.Property(bookEntity => bookEntity.Price).HasPrecision(10, 5);
    // relationships
    modelBuilder.HasOne(bookEntity => bookEntity.Publisher).WithMany(publisherEntity => publisherEntity.Books).HasForeignKey(u => u.Id);
  }
}

