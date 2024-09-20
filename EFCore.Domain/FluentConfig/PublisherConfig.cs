namespace EFCore.Domain.FluentConfig;

using EFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public partial class EntityConfig : IEntityTypeConfiguration<PublisherEntity>
{
  public void Configure(EntityTypeBuilder<PublisherEntity> modelBuilder)
  {
    // primary key
    modelBuilder.HasKey(bookEntity => bookEntity.Id);
    // properties
    modelBuilder.Property(publisherEntity => publisherEntity.Name).IsRequired();
  }
}

