﻿namespace EFCore.Domain;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Books")]
public class BookEntity
{
  [Key]
  public int Id { get; set; }
  public string Title { get; set; }
  public string Author { get; set; }
  [MaxLength(20)]
  [Required]
  public string Isbn { get; set; }
  public decimal Price { get; set; }
  [NotMapped]
  public string PriceRange { get; set; }
  
  // Navigation Properties 1:1
  public BookDetailEntity BookDetail { get; set; }

  // Navigation Properties 1:m
  [ForeignKey("Publisher")]
  public int Publisher_Id { get; set; }
  public PublisherEntity Publisher { get; set; }

  // Navigation Properties m:*m
  public List<BookAuthorMap> BookAuthorMap { get; set; }

}
