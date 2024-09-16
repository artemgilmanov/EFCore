namespace EFCore.Infrastructure.Repository;

using System.Net.Mime;
using Domain;
using Domain.FluentConfig;
using Domain.FluentEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
  /*
  public DbSet<BookEntity> Books { get; set; }
  public DbSet<GenreEntity> Genres { get; set; }
  public DbSet<AuthorEntity> Authors { get; set; }
  public DbSet<PublisherEntity> Publishers { get; set; }
  public DbSet<SubCategoryEntity> SubCategories { get; set; }
  public DbSet<BookDetailEntity> BookDetails { get; set; }
  */

  public DbSet<Fluent_BookEntity> Fluent_Books { get; set; }
  public DbSet<Fluent_GenreEntity> Fluent_Genres { get; set; }
  public DbSet<Fluent_AuthorEntity> Fluent_Authors { get; set; }
  public DbSet<Fluent_PublisherEntity> Fluent_Publishers { get; set; }
  public DbSet<Fluent_SubCategoryEntity> Fluent_SubCategories { get; set; }
  public DbSet<Fluent_BookDetailEntity> Fluent_BookDetails { get; set; }

  /*
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EFCore;TrustServerCertificate=True;Trusted_Connection=True")
      .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
  }
  */

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
     // Many to Many Relationship between Book and Author 
    modelBuilder.Entity<Fluent_BookAuthorMap>().HasKey(u => new { u.Author_Id, u.Book_Id });

    modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityConfig).Assembly);

    /*
    modelBuilder.Entity<BookEntity>().HasData(
      new BookEntity
      {
        Id = 1,
        Title = "1984",
        Author = "George Orwell",
        Isbn = "978-0451524935",
        Price = 9.99m
      },
      new BookEntity
      {
        Id = 2,
        Title = "Brave New World",
        Author = "Aldous Huxley",
        Isbn = "978-0060850524",
        Price = 9.99m
      },
      new BookEntity
      {
        Id = 3,
        Title = "Fahrenheit 451",
        Author = "Ray Bradbury",
        Isbn = "978-1451673319",
        Price = 9.99m
      }
    );
    */

    // Seed Publishers
    modelBuilder.Entity<Fluent_PublisherEntity>().HasData(
      new Fluent_PublisherEntity { Publisher_Id = 1, Name = "Penguin Books", Location = "New York" },
      new Fluent_PublisherEntity { Publisher_Id = 2, Name = "HarperCollins", Location = "London" }
    );

    // Seed Books with valid Publisher_Id
    modelBuilder.Entity<Fluent_BookEntity>().HasData(
      new Fluent_BookEntity { Id = 1, Title = "1984", Author = "George Orwell", Isbn = "978-0451524935", Price = 9.99m, Publisher_Id = 1 },
      new Fluent_BookEntity { Id = 2, Title = "Brave New World", Author = "Aldous Huxley", Isbn = "978-0060850524", Price = 9.99m, Publisher_Id = 2 },
      new Fluent_BookEntity { Id = 3, Title = "Fahrenheit 451", Author = "Ray Bradbury", Isbn = "978-1451673319", Price = 9.99m, Publisher_Id = 1 }
    );
  }
}
