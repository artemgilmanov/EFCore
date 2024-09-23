namespace EFCore.Api.Controllers;

using EFCore.Domain;
using EFCore.Resources;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]/[action]")]
[ApiController]
public class CategoryController : ControllerBase
{
  private readonly Repository db;

  public CategoryController(Repository db)
  {
    this.db = db;
  }

  [HttpPost(Name = "Create")]
  [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]

  public async Task<IActionResult> Create(Category resource)
  {
    var categoryEntity = new CategoryEntity { Name = resource.Name, };

    await this.db.Categories.AddAsync(categoryEntity);
    await this.db.SaveChangesAsync();

    return this.Ok();
  }

  [HttpGet(Name = "GetAll")]
  [ProducesResponseType(typeof(List<Category>), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> GetAll()
  {
    List<CategoryEntity> categoryEntities = await this.db.Categories.ToListAsync();
    var caregories = categoryEntities.Select(categoryEntity => new Category
    {
      Name = categoryEntity.Name, Id = categoryEntity.Id.ToString(),
    });
    return this.Ok(caregories);
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
  [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status409Conflict)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> Update( Category resource)
  {
    var categoryEntity = new CategoryEntity { Id = Guid.Parse(resource.Id), Name = resource.Name, };

    this.db.Categories.Update(categoryEntity);
    await this.db.SaveChangesAsync();
    return this.Ok();
  }

  [HttpDelete(Name = "Delete")]
  [ProducesResponseType(typeof(CategoryEntity), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> Delete(string? id)
  {
    CategoryEntity categoryEntity = new();
    categoryEntity = await this.db.Categories.FirstOrDefaultAsync(entity => entity.Id == Guid.Parse(id));

    if (categoryEntity is null)
    {
      return this.NotFound();
    }

    this.db.Categories.Remove(categoryEntity);
    await this.db.SaveChangesAsync();

    return this.Ok();
  }
}
