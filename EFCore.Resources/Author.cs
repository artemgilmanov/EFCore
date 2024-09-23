namespace EFCore.Resources;

public class Author
{
  public BookAuthorMap BookAuthor { get; set; }
  public Book Book { get; set; }

  public IEnumerable<BookAuthorMap> BookAuthorList { get; set; }
  public IEnumerable<Author> AuthorList { get; set; }

}
