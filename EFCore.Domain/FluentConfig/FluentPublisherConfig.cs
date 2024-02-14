namespace EFCore.Domain.FluentConfig;

using FluentEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public partial class EntityConfig : IEntityTypeConfiguration<Fluent_PublisherEntity>
{
  public void Configure(EntityTypeBuilder<Fluent_PublisherEntity> modelBuilder)
  {
    // primary key
    modelBuilder.HasKey(u => u.Publisher_Id);
    
    // properties
    modelBuilder.Property(u => u.Name)
      .IsRequired();
  }
}

