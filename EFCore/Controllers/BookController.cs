namespace EFCore.Api.Controllers;

using EFCore.Domain;
using EFCore.Resources;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]/[action]")]
[ApiController]
public class BookController : ControllerBase
{
  private readonly Repository db;

  public BookController(Repository db)
  {
    this.db = db;
  }

  [HttpPost(Name = "Create")]
  [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> Create(Book resource)
  {
    var BookEntity = new BookEntity
    {
      Title = resource.Title,
      Author = resource.Author,
      Isbn = resource.Isbn,
      Price = resource.Price,
      PriceRange = resource.PriceRange,
    };

    await this.db.Books.AddAsync(BookEntity);
    await this.db.SaveChangesAsync();

    return this.Ok();
  }

  [HttpGet(Name = "GetAll")]
  [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> GetAll()
  {
    //List<BookEntity> bookEntities = await this.db.Books.ToListAsync();

    //var books = bookEntities.Select(bookEntity => new Book
    //{
    //  Id = bookEntity.Id.ToString(),
    //  Title = bookEntity.Title,
    //  Author = bookEntity.Author,
    //  Isbn = bookEntity.Isbn,
    //  Price = bookEntity.Price,
    //  PriceRange = bookEntity.PriceRange,

    //  // Option(1) Get publishers related to book.
    //  //Publishers = this.db.Publishers
    //  //  .Where(publisherEntity => publisherEntity.Id == bookEntity.PublisherId)
    //  //  .Select(publisherEntity => new Publisher
    //  //  {
    //  //    Id = publisherEntity.Id.ToString(),
    //  //    Name = publisherEntity.Name,
    //  //    Location = publisherEntity.Location
    //  //  })
    //  //  .ToList()

    //  // Option(2) Avoid duplicate calls for the same publisher Id.
    //  Publishers = this.db.Entry(bookEntity).References(u=>u.Publisher).Load(),
    //});

    // Option(3) Publishers are performed by one query together with Books. (Eager Loading)
    List<BookEntity> bookEntities = await this.db.Books.Include(u=>u.Publisher).ToListAsync();
    
    var books = bookEntities.Select(bookEntity => new Book
    {
      Id = bookEntity.Id.ToString(),
      Title = bookEntity.Title,
      Author = bookEntity.Author,
      Isbn = bookEntity.Isbn,
      Price = bookEntity.Price,
      PriceRange = bookEntity.PriceRange,
      Publishers = bookEntities.Select(entry =>  new Publisher
      {
        Name = entry.Publisher.Name,
        Location = entry.Publisher.Location,
      }).ToList()
     }).ToList();

    return this.Ok(books);
  }

  [HttpGet(Name = "GetById")]
  [ProducesResponseType(typeof(BookEntity), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> GetById(string? id)
  {
    if (string.IsNullOrEmpty(id))
    {
      return this.BadRequest();
    }

    BookEntity bookEntity = await this.db.Books
      .Include(bookEntity => bookEntity.Author)
      .Include(bookEntity => bookEntity.Publisher)
      .FirstOrDefaultAsync(book => book.Id == Guid.Parse(id));
    
    Book bookResource = new Book
    {
      Id = bookEntity.Id.ToString(),
      Author = bookEntity.Author,
      Isbn = bookEntity.Isbn,
      Price = bookEntity.Price,
      PriceRange = bookEntity.PriceRange,
      Title = bookEntity.Title,

      //Publishers = this.db.Publishers
      //  .Where(publisherEntity => publisherEntity.Id == bookEntity.PublisherId)
      //  .Select(publisherEntity => new Publisher
      //  {
      //    Id = publisherEntity.Id.ToString(),
      //    Name = publisherEntity.Name,
      //    Location = publisherEntity.Location
      //  })
      //  .ToList(),

      // Avoid duplicate calls for the same publisher Id.
      Publishers = new List<Publisher>
      {
        new Publisher
        {
          Id = bookEntity.Publisher.Id.ToString(),
          Name = bookEntity.Publisher.Name,
          Location = bookEntity.Publisher.Location
        }
      }
    };

    return this.Ok(bookResource);
  }

  [HttpPut(Name = "Update")]
  [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status409Conflict)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> Update(Book resource)
  {
    if (string.IsNullOrEmpty(resource.Id))
    {
      return this.BadRequest();
    }

    var BookEntity = new BookEntity
    {
      Id = Guid.Parse(resource.Id),
      Title = resource.Title,
      Author = resource.Author,
      Isbn = resource.Isbn,
      Price = resource.Price,
      PriceRange = resource.PriceRange,
    };

    this.db.Books.Update(BookEntity);
    await this.db.SaveChangesAsync();
    return this.Ok();
  }

  [HttpDelete(Name = "Delete")]
  [ProducesResponseType(typeof(BookEntity), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> Delete(string? id)
  {
    BookEntity BookEntity = new();
    BookEntity = await this.db.Books.FirstOrDefaultAsync(entity => entity.Id == Guid.Parse(id));

    if (BookEntity is null)
    {
      return this.NotFound();
    }

    this.db.Books.Remove(BookEntity);
    await this.db.SaveChangesAsync();

    return this.Ok();
  }
}
