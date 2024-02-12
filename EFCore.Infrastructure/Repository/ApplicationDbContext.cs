using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Infrastructure.Repository;

using System.Diagnostics.Metrics;
using Domain;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

using static System.Runtime.InteropServices.JavaScript.JSType;

public class ApplicationDbContext : DbContext
{
  public DbSet<BookEntity> Books { get; set; }
  public DbSet<GenreEntity> Genres { get; set; }
  public DbSet<AuthorEntity> Authors { get; set; }
  public DbSet<PublisherEntity> Publishers { get; set; }
  public DbSet<SubCategoryEntity> SubCategories { get; set; }


  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EFCore;TrustServerCertificate=True;Trusted_Connection=True;");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<BookEntity>().Property(u => u.Price).HasPrecision(10,5);

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
