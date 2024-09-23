namespace EFCore.Domain;

public class BookDetailEntity
{
  public Guid Id { get; set; }
  public int NumberofChapters { get; set; }
  public int NumberOfPages { get; set; }
  public string Weight { get; set; }
  // Navigation properties
  public BookEntity Book { get; set; }
  public Guid BookId { get; set; }
}
