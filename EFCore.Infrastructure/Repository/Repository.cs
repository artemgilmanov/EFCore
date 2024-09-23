namespace EFCore.Infrastructure.Repository;

using Domain;
using Domain.FluentConfig;
using Microsoft.EntityFrameworkCore;

public partial class Repository : DbContext
{
  public Repository(DbContextOptions<Repository> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // Many to Many Relationship between Book and Author 
    modelBuilder.Entity<BookAuthorMap>().HasKey(u => new { u.AuthorId, u.BookId });

    modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityConfig).Assembly);

    // Seed Publishers
    modelBuilder.Entity<PublisherEntity>().HasData(
        new PublisherEntity { Id = Guid.NewGuid(), Name = "Penguin Books", Location = "New York" },
        new PublisherEntity { Id = Guid.NewGuid(), Name = "HarperCollins", Location = "London" }
    );

    // Seed Books with valid Publisher_Id
    modelBuilder.Entity<BookEntity>().HasData(
        new BookEntity
        {
          Id = Guid.NewGuid(),
          Title = "1984",
          Author = "George Orwell",
          Isbn = "978-0451524935",
          Price = 9.99m,
        },
        new BookEntity
        {
          Id = Guid.NewGuid(),
          Title = "Brave New World",
          Author = "Aldous Huxley",
          Isbn = "978-0060850524",
          Price = 9.99m,
        },
        new BookEntity
        {
          Id = Guid.NewGuid(),
          Title = "Fahrenheit 451",
          Author = "Ray Bradbury",
          Isbn = "978-1451673319",
          Price = 9.99m,
        }
    );

    // Seed Categories
    modelBuilder.Entity<CategoryEntity>().HasData(
        new CategoryEntity { Id = Guid.NewGuid(), Name = "cat one" },
        new CategoryEntity { Id = Guid.NewGuid(), Name = "cat two" },
        new CategoryEntity { Id = Guid.NewGuid(), Name = "cat three" }
    );
  }
}

