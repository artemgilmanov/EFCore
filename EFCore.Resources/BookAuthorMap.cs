namespace EFCore.Resources;

public class BookAuthorMap
{
  public Guid BookId { get; set; }
  public Guid AuthorId { get; set; }
  public Book Book { get; set; }
  public Author Author { get; set; }
}
