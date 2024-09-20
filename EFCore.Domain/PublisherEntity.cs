namespace EFCore.Domain;
public class PublisherEntity
{
  public Guid Id { get; set; }
  public string Name { get; set; }
  public string Location { get; set; }
  // Navigation properties
  public ICollection<BookEntity> Books { get; set; }
}
