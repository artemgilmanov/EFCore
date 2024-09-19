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
```c#
migrationBuilder.Sql("INSERT INTO SubCategories VALUES ('Cat 1')");
```
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

### Explicit Loading
```c#
List<SomeEntity> objList = _db.Books.ToList();

foreach(var obj in objList)
{
 // least effecient
 // obj.Publisher = _db.Publisher.Find(obj.Publisher_Id);

 // more efficient
 _db.Entry(obj).Reference(u=>u.Publisher).Load();
}
```
# Eager Loading

for example there are three books related to a publisher. If there are ten publishers, the query will be executed ten times plus one to retrieve all the books. This condition calls n+1 execution. That is not the most efficient way to access the database. The most efficient would be to use a single call, using inner join, to retrieve all data.
```c#
using Microsoft.EntityFramework;

List<SomeEntity> objList = _db.Books.Include(u => u.Publisher).ToList();
```
# IQueryable vs IEnumerable


IQueryable interface inherits from IEnumerable.
Anything you do with IEnumerable can be done with IQueriable
```c#
IEnumerable<Books> BookLust = _db.Books;
var FilteredBook = BookList.Where(b => b.Price > 50).ToList();
```
Query returns all the records:
```sql
SELECT [b].[BookId], [b].[Category_Id], [b].[bookISBN], [b].[Prise], [b].[Publisher_Id], [b].[Title]
FROM [books] AS [b]
```
Filter is applied in memory.

```c#
IQueryable<Books> BookList = _db.Books;
var fileredBook = BookList.Where(b => b.Proce > 50).ToList();
```
Query (Returns filtered records):
```sql
SELECT [b].[BookId], [b].[Category_Id], [b].[bookISBN], [b].[Prise], [b].[Publisher_Id], [b].[Title]
FROM [b].[Price] > 500.0E0
```
Filter is applied in database.

# Multi-Level Explicit Loading

How to retrieve all authors associated to a book?
```c#
List<Book> objList = _db.Books.ToList();
foreach(var obj in objList)
{
 _db.Entry(obj).Reference(u => u.Publisher).Load();
 _db.Entry(obj).Collection(u => u.BookAuthorMap).Load();
 foreach(var bookAuth in obj.BookAuthorMap)
  {
   _db.Entry(bookAuth).Reference(u => u.Author).Load();
  }
}
return objList;
```
