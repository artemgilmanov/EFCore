namespace EFCore.Domain.FluentConfig;

using FluentEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public partial class EntityConfig : IEntityTypeConfiguration<Fluent_AuthorEntity>
{
  public void Configure(EntityTypeBuilder<Fluent_AuthorEntity> modelBuilder)
  {
    // primary key
    modelBuilder.HasKey(u => u.Author_Id);
   
    // properties
    modelBuilder.Property(u => u.FirstName)
      .HasMaxLength(50)
      .IsRequired();
    modelBuilder.Property(u => u.LastName)
      .IsRequired();
    modelBuilder.Property(u => u.BirthDate)
      .IsRequired();
    modelBuilder.Ignore(u => u.FullName);
  }
}

