namespace EFCore.Resources;

public class Author
{
  public string Id { get; set; }
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
}
