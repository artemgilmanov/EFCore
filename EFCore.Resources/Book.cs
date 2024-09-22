﻿namespace EFCore.Resources;

public class BookEntity
{
  public string Title { get; set; }
  public string Author { get; set; }
  public string Isbn { get; set; }
  public decimal Price { get; set; }
  public string PriceRange { get; set; }
}
