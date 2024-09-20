namespace EFCore.Domain.FluentConfig;

using EFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public partial class EntityConfig : IEntityTypeConfiguration<AuthorEntity>
{
  public void Configure(EntityTypeBuilder<AuthorEntity> modelBuilder)
  {
    // primary key
    modelBuilder.HasKey(authorEntity => authorEntity.Id);
    // properties
    modelBuilder.Property(authorEntity => authorEntity.FirstName).HasMaxLength(50).IsRequired();
    modelBuilder.Property(authorEntity => authorEntity.LastName).IsRequired();
    modelBuilder.Property(authorEntity => authorEntity.BirthDate).IsRequired();
    modelBuilder.Ignore(authorEntity => authorEntity.FullName);
  }
}

