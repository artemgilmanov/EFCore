namespace EFCore.Api.Controllers;

using Domain.FluentEntities;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]/[action]")]
[ApiController]
public class SubCategoryController : ControllerBase
{
  private readonly ApplicationDbContext db;

  public SubCategoryController(ApplicationDbContext db)
  {
    this.db = db;
  }

  [HttpPost(Name = "Create")]
  [ProducesResponseType(typeof(Fluent_SubCategoryEntity), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]

  public async Task<IActionResult> Create(Fluent_SubCategoryEntity obj)
  {
    await this.db.Fluent_SubCategories.AddAsync(obj);
    await this.db.SaveChangesAsync();
    return this.Ok();
  }

  [HttpGet(Name = "GetAll")]
  [ProducesResponseType(typeof(List<Fluent_SubCategoryEntity>), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> GetAll()
  {
    List<Fluent_SubCategoryEntity> result = await this.db.Fluent_SubCategories.ToListAsync();
    return this.Ok(result);
  }

  [HttpGet(Name = "GetById")]
  [ProducesResponseType(typeof(Fluent_SubCategoryEntity), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> GetById(int? id)
  {
    if (id is null or 0)
    {
      return this.BadRequest();
    }

    Fluent_SubCategoryEntity obj = new();
    obj = await this.db.Fluent_SubCategories.FirstOrDefaultAsync(entity => entity.SubCategory_Id == id);

    return obj == null ? this.NotFound() : this.Ok(obj);
  }

  [HttpPut(Name = "Update")]
  [ProducesResponseType(typeof(Fluent_SubCategoryEntity), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status409Conflict)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> Update(Fluent_SubCategoryEntity obj)
  {
    this.db.Fluent_SubCategories.Update(obj);
    await this.db.SaveChangesAsync();
    return this.Ok();
  }

  [HttpDelete(Name = "Delete")]
  [ProducesResponseType(typeof(Fluent_SubCategoryEntity), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> Delete(int id)
  {
    Fluent_SubCategoryEntity obj = new();
    obj = await this.db.Fluent_SubCategories.FirstOrDefaultAsync(entity => entity.SubCategory_Id == id);

    if (obj is null)
    {
      return this.NotFound();
    }

    this.db.Fluent_SubCategories.Remove(obj);
    await this.db.SaveChangesAsync();

    return this.Ok();
  }
}
