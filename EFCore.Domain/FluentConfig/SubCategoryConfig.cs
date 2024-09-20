namespace EFCore.Domain.FluentConfig;

using EFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public partial class EntityConfig : IEntityTypeConfiguration<CategoryEntity>
{
  public void Configure(EntityTypeBuilder<CategoryEntity> modelBuilder)
  {
    // primary key
    modelBuilder.HasKey(bookEntity => bookEntity.Id);
    // properties
    modelBuilder.Property(u => u.Name).HasMaxLength(50).IsRequired();
  }
}

