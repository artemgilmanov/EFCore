namespace EFCore.Resources;

using Microsoft.AspNetCore.Mvc.Rendering;

public class Book
{
  public string Id { get; set; }
  public string Title { get; set; }
  public string Author { get; set; }
  public string Isbn { get; set; }
  public decimal Price { get; set; }
  public string PriceRange { get; set; }

  public BookDetail BookDetail { get; set; }
  public IEnumerable<Publisher> Publishers { get; set; }

}
