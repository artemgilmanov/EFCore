namespace EFCore.Domain;

using System.ComponentModel.DataAnnotations.Schema;

public class BookAuthorMap
{
  [ForeignKey("Book")]
  public int Book_Id { get; set; }
  [ForeignKey("Author")]
  public int Author_Id { get; set; }
  public BookEntity Book { get; set; }
  public AuthorEntity Author { get; set; }

}
