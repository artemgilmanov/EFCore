namespace EFCore.Domain.FluentEntities;

public class Fluent_BookDetailEntity
{
  public int BookDetail_Id { get; set; }
  public int NumberofChapters { get; set; }
  public int NumberOfPages { get; set; }
  public string Weight { get; set; }

  // Navigation properties
  public Fluent_BookEntity Book { get; set; }
  public int Book_Id { get; set; }
}
