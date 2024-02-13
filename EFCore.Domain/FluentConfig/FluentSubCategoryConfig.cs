namespace EFCore.Domain.FluentConfig;

using FluentEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public partial class EntityConfig : IEntityTypeConfiguration<Fluent_SubCategoryEntity>
{
  public void Configure(EntityTypeBuilder<Fluent_SubCategoryEntity> modelBuilder)
  {
    // primary key
    modelBuilder.HasKey(u => u.Publisher_Id);
    
    // properties
    modelBuilder.Property(u => u.Name)
      .HasMaxLength(50)
      .IsRequired();
  }
}

