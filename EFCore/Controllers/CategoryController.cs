namespace EFCore.Api.Controllers;

using EFCore.Domain;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]/[action]")]
[ApiController]
public class CategoryController : ControllerBase
{
  private readonly ApplicationDbContext db;

  public CategoryController(ApplicationDbContext db)
  {
    this.db = db;
  }

  [HttpPost(Name = "Create")]
  [ProducesResponseType(typeof(CategoryEntity), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]

  public async Task<IActionResult> Create(CategoryEntity obj)
  {
    await this.db.Categories.AddAsync(obj);
    await this.db.SaveChangesAsync();
    return this.Ok();
  }

  [HttpGet(Name = "GetAll")]
  [ProducesResponseType(typeof(List<CategoryEntity>), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> GetAll()
  {
    List<CategoryEntity> result = await this.db.Categories.ToListAsync();
    return this.Ok(result);
  }

  [HttpGet(Name = "GetById")]
  [ProducesResponseType(typeof(CategoryEntity), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> GetById(string? id)
  {
    if (string.IsNullOrEmpty(id))
    {
      return this.BadRequest();
    }

    CategoryEntity obj = new();
    obj = await this.db.Categories.FirstOrDefaultAsync(entity => entity.Id == Guid.Parse(id));

    return obj == null ? this.NotFound() : this.Ok(obj);
  }

  [HttpPut(Name = "Update")]
  [ProducesResponseType(typeof(CategoryEntity), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status409Conflict)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> Update(CategoryEntity obj)
  {
    this.db.Categories.Update(obj);
    await this.db.SaveChangesAsync();
    return this.Ok();
  }

  [HttpDelete(Name = "Delete")]
  [ProducesResponseType(typeof(CategoryEntity), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> Delete(string? id)
  {
    CategoryEntity obj = new();
    obj = await this.db.Categories.FirstOrDefaultAsync(entity => entity.Id == Guid.Parse(id));

    if (obj is null)
    {
      return this.NotFound();
    }

    this.db.Categories.Remove(obj);
    await this.db.SaveChangesAsync();

    return this.Ok();
  }
}
