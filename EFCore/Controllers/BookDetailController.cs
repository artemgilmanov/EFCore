namespace EFCore.Api.Controllers;

using EFCore.Domain;
using EFCore.Resources;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.IdentityModel.Tokens;

[Route("api/[controller]/[action]")]
[ApiController]
public class BookDetailController : ControllerBase
{
  private readonly Repository db;

  public BookDetailController(Repository db)
  {
    this.db = db;
  }

  [HttpGet(Name = "GetById")]
  [ProducesResponseType(typeof(BookEntity), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> GetById(string id)
  {
    if (string.IsNullOrEmpty(id))
    {
      return this.BadRequest();
    }
    
    BookEntity bookEntity = await this.db.Books.FirstOrDefaultAsync(u => u.Id == Guid.Parse(id));

    if (bookEntity is null)
    {
      return this.NotFound();
    }

    // Explicit loading
    //bookEntity.BookDetail = await this.db.BookDetails.FirstOrDefaultAsync(u => u.BookId == Guid.Parse(resource.Id));
    bookEntity.BookDetail = await this.db.BookDetails.Include(u => u.Book).FirstOrDefaultAsync(u => u.BookId == Guid.Parse(id));

    var bookDetailResource = new BookDetail
    {
      NumberOfPages = bookEntity.BookDetail.NumberOfPages,
      NumberofChapters = bookEntity.BookDetail.NumberofChapters,
      Weight = bookEntity.BookDetail.Weight,
    };

    return this.Ok(bookDetailResource);
  }

  [HttpPost(Name = "Create")]
  [ProducesResponseType(typeof(BookDetail), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]

  public async Task<IActionResult> Create(BookDetail resource)
  {
    if (resource.Id is null)
    {
      return this.BadRequest();
    }
    
    var bookEntity = new BookEntity
    {
      BookDetail = new BookDetailEntity
      {
        NumberOfPages = resource.NumberOfPages,
        NumberofChapters = resource.NumberofChapters,
        Weight = resource.Weight,
        BookId = Guid.Parse(resource.Id),
      }
    };

    await this.db.Books.AddAsync(bookEntity);
    await this.db.SaveChangesAsync();

    return this.Ok();
  }

  [HttpPut(Name = "Update")]
  [ProducesResponseType(typeof(BookDetail), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status409Conflict)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> Update(BookDetail resource)
  {
    if (string.IsNullOrEmpty(resource.Id))
    {
      return this.BadRequest();
    }

    var bookDetail = new BookDetailEntity
    {
      NumberOfPages = resource.NumberOfPages,
      NumberofChapters = resource.NumberofChapters,
      Weight = resource.Weight,
      BookId = Guid.Parse(resource.Id),
    };

    this.db.BookDetails.Update(bookDetail);
    await this.db.SaveChangesAsync();

    return this.Ok();
  }
}
