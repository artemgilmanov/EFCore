namespace EFCore.Domain.FluentConfig;

using EFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public partial class EntityConfig : IEntityTypeConfiguration<BookAuthorMap>
{
  public void Configure(EntityTypeBuilder<BookAuthorMap> modelBuilder)
  {
    // primary key
    modelBuilder.HasKey(bookAuthorMap => new { bookAuthorMap.BookId, bookAuthorMap.AuthorId });
    // relationships
    modelBuilder.HasOne(bookAuthorMap => bookAuthorMap.Book).WithMany(bookEntity => bookEntity.BookAuthorMaps).HasForeignKey(bookAuthorMap => bookAuthorMap.BookId);
    modelBuilder.HasOne(bookAuthorMap => bookAuthorMap.Author).WithMany(authorEntity => authorEntity.BookAuthorMaps).HasForeignKey(bookAuthorMap => bookAuthorMap.AuthorId);
  }
}

