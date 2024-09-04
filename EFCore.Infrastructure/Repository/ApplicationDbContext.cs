namespace EFCore.Infrastructure.Repository;

using Domain;
using Microsoft.EntityFrameworkCore;


public class ApplicationDbContext : DbContext
{
  public DbSet<BookEntity> Books { get; set; }
  public DbSet<GenreEntity> Genres { get; set; }
  public DbSet<AuthorEntity> Authors { get; set; }
  public DbSet<PublisherEntity> Publishers { get; set; }
  public DbSet<SubCategoryEntity> SubCategories { get; set; }
  public DbSet<BookDetailEntity> BookDetails { get; set; }


  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EFCore;TrustServerCertificate=True;Trusted_Connection=True;");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<BookEntity>().Property(u => u.Price).HasPrecision(10,5);

    // Many to Many Relationship between Book and Author 
    modelBuilder.Entity<BookAuthorMap>().HasKey(ba => new { ba.Book_Id, ba.Author_Id });

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
  }
}
