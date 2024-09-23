namespace EFCore.Domain;

public class AuthorEntity
{
  public Guid Id { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public DateTime BirthDate { get; set; }
  public string FullName
  {
    get
    {
      return $"{this.FirstName} {this.LastName}";
    }
  }
  // Navigation Properties
  public ICollection<BookAuthorMap> BookAuthorMaps { get; set; }
}
