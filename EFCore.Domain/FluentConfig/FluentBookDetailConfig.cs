namespace EFCore.Domain.FluentConfig;

using FluentEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public partial class EntityConfig : IEntityTypeConfiguration<Fluent_BookDetailEntity>
{
  public void Configure(EntityTypeBuilder<Fluent_BookDetailEntity> modelBuilder)
  {
    // primary key
    modelBuilder.HasKey(u => u.BookDetail_Id);

    // properties
    modelBuilder.Property(u => u.NumberofChapters)
      .IsRequired();

    // relationships
    modelBuilder.HasOne(u => u.Book)
      .WithOne(u => u.BookDetail)
      .HasForeignKey<Fluent_BookDetailEntity>(u => u.Book_Id);
  }
}

