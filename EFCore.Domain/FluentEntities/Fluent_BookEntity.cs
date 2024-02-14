namespace EFCore.Domain.FluentEntities;

public class Fluent_BookEntity
{
 public int Id { get; set; }
  public string Title { get; set; }
  public string Author { get; set; }
  
  public string Isbn { get; set; }
  public decimal Price { get; set; }
  
  public string PriceRange { get; set; }

  // Navigation properties
  public Fluent_BookDetailEntity BookDetail { get; set; }

  public int Publisher_Id { get; set; }
  public Fluent_PublisherEntity Publisher { get; set; }

  public ICollection<Fluent_BookAuthorMap> BookAuthorMaps { get; set; }
}
