namespace EFCore.Domain.FluentConfig;

using FluentEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public partial class EntityConfig : IEntityTypeConfiguration<Fluent_BookAuthorMap>
{
  public void Configure(EntityTypeBuilder<Fluent_BookAuthorMap> modelBuilder)
  {
    // primary key
    modelBuilder.HasKey(ba => new { ba.Book_Id, ba.Author_Id });
    
    // relationships
    modelBuilder.HasOne(ba => ba.Book)
      .WithMany(b => b.BookAuthorMaps)
      .HasForeignKey(ba => ba.Book_Id);
    modelBuilder.HasOne(ba => ba.Author)
      .WithMany(a => a.BookAuthorMaps)
      .HasForeignKey(ba => ba.Author_Id);
  }
}

