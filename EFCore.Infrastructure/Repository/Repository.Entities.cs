namespace EFCore.Infrastructure.Repository;

using Domain;
using Microsoft.EntityFrameworkCore;

public partial class Repository
{
  public DbSet<BookEntity> Books { get; set; }
  public DbSet<GenreEntity> Genres { get; set; }
  public DbSet<AuthorEntity> Authors { get; set; }
  public DbSet<PublisherEntity> Publishers { get; set; }
  public DbSet<CategoryEntity> Categories { get; set; }
  public DbSet<BookDetailEntity> BookDetails { get; set; }
  public DbSet<BookAuthorMap> BookAuthorMaps { get; set; }
}
