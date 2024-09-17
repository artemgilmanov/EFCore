# EFCore

### Model
```c#
public class BookEntity
{
  public int Id { get; set; }
  public string Title { get; set; }
  public string Author { get; set; }
  public string Isbn { get; set; }
  public decimal Price { get; set; }
  public string PriceRange { get; set; }
}
```
### Migrations

### DataAnnotations
```c#
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
}
```
### Relations
```c#
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
  
  // Navigation Property 1:1
  public BookDetailEntity BookDetail { get; set; }

  // Navigation Properties 1:m
  [ForeignKey("Publisher")]
  public int Publisher_Id { get; set; }
  public PublisherEntity Publisher { get; set; }
}
```
### FluentApi
