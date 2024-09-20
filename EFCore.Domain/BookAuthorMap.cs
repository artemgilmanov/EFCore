namespace EFCore.Domain;

public class BookAuthorMap
{
  public Guid BookId { get; set; }
  public Guid AuthorId { get; set; }
  public BookEntity Book { get; set; }
  public AuthorEntity Author { get; set; }
}
