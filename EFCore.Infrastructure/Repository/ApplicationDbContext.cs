﻿namespace EFCore.Infrastructure.Repository;

using Domain;
using Domain.FluentConfig;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
  public DbSet<BookEntity> Books { get; set; }
  public DbSet<GenreEntity> Genres { get; set; }
  public DbSet<AuthorEntity> Authors { get; set; }
  public DbSet<PublisherEntity> Publishers { get; set; }
  public DbSet<CategoryEntity> Categories { get; set; }
  public DbSet<BookDetailEntity> BookDetails { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // Many to Many Relationship between Book and Author 
    modelBuilder.Entity<BookAuthorMap>().HasKey(u => new { u.AuthorId, u.BookId });

    modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityConfig).Assembly);

    // Seed Publishers
    modelBuilder.Entity<PublisherEntity>().HasData(
      new PublisherEntity { Name = "Penguin Books", Location = "New York" },
      new PublisherEntity { Name = "HarperCollins", Location = "London" }
    );

    // Seed Books with valid Publisher_Id
    modelBuilder.Entity<BookEntity>().HasData(
      new BookEntity { Title = "1984", Author = "George Orwell", Isbn = "978-0451524935", Price = 9.99m },
      new BookEntity { Title = "Brave New World", Author = "Aldous Huxley", Isbn = "978-0060850524", Price = 9.99m },
      new BookEntity { Title = "Fahrenheit 451", Author = "Ray Bradbury", Isbn = "978-1451673319", Price = 9.99m }
    );
  }
}
