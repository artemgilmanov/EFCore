namespace EFCore.Domain.FluentEntities;

using System.ComponentModel.DataAnnotations.Schema;

public class Fluent_BookAuthorMap
{
  public int Book_Id { get; set; }
  public int Author_Id { get; set; }
  public Fluent_BookEntity Book { get; set; }
  public Fluent_AuthorEntity Author { get; set; }

}
