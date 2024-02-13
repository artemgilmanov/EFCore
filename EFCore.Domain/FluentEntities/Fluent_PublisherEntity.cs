namespace EFCore.Domain.FluentEntities;

public class Fluent_PublisherEntity
{
  public int Publisher_Id { get; set; }
  public string Name { get; set; }
  public string Location { get; set; }

  // Navigation properties
  public ICollection<Fluent_BookEntity> Books { get; set; }
}
