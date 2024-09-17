namespace EFCore.Domain.FluentConfig;

using FluentEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public partial class EntityConfig : IEntityTypeConfiguration<Fluent_SubCategoryEntity>
{
  public void Configure(EntityTypeBuilder<Fluent_SubCategoryEntity> modelBuilder)
  {
    // primary key
    modelBuilder.HasKey(u => u.SubCategory_Id);

    modelBuilder.Property(u => u.SubCategory_Id).ValueGeneratedOnAdd();
    
    // properties
    modelBuilder.Property(u => u.Name)
      .HasMaxLength(50)
      .IsRequired();
  }
}

