﻿namespace EFCore.Domain;
public class BookEntity
{
  public Guid Id { get; set; }
  public string Title { get; set; }
  public string Author { get; set; }
  public string Isbn { get; set; }
  public decimal Price { get; set; }
  public string PriceRange { get; set; }
  // Navigation properties
  public BookDetailEntity BookDetail { get; set; }
  public Guid PublisherId { get; set; }
  public PublisherEntity Publisher { get; set; }
  public ICollection<BookAuthorMap> BookAuthorMaps { get; set; }
}
