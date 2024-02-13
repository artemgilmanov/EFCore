namespace EFCore.Domain.FluentEntities;

public class Fluent_AuthorEntity
{
  public int Author_Id { get; set; }

  public string FirstName { get; set; }

  public int LastName { get; set; }

  public DateTime BirthDate { get; set; }

  public string FullName 
  {
    get
    {
      return $"{this.FirstName} {this.LastName}";
    }
  }

  // Navigation Properties
  public ICollection<Fluent_BookAuthorMap> BookAuthorMaps { get; set; }


}
