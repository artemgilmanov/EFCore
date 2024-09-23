namespace EFCore.Domain.FluentConfig;

using EFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public partial class EntityConfig : IEntityTypeConfiguration<BookDetailEntity>
{
  public void Configure(EntityTypeBuilder<BookDetailEntity> modelBuilder)
  {
    // primary key
    modelBuilder.HasKey(bookEntity => bookEntity.Id);
    // properties
    modelBuilder.Property(bookEntity => bookEntity.NumberofChapters).IsRequired();
    // relationships
    modelBuilder.HasOne(bookEntity => bookEntity.Book).WithOne(bookEntity => bookEntity.BookDetail).HasForeignKey<BookDetailEntity>(bookDetailEntity => bookDetailEntity.Id);
  }
}

