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

  [HttpGet(Name = "GetAll")]
  [ProducesResponseType(typeof(List<Fluent_SubCategoryEntity>), StatusCodes.Status200OK)]
  public async Task<IActionResult> GetAll()
  {
    List<Fluent_SubCategoryEntity> result = await this.db.Fluent_SubCategories.ToListAsync();
    return this.Ok(result);
  }

  [HttpGet(Name = "GetById")]
  [ProducesResponseType(typeof(List<Fluent_SubCategoryEntity>), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public async Task<IActionResult> GetById(int? id)
  {
    if (id is null or 0)
    {
      return this.BadRequest();
    }

    Fluent_SubCategoryEntity obj = new();
    obj = await this.db.Fluent_SubCategories.FirstOrDefaultAsync(entity => entity.Publisher_Id == id);

    return obj == null ? this.NotFound() : this.Ok(obj);
  }

  [HttpPost(Name = "Update")]
  [ValidateAntiForgeryToken]
  [ProducesResponseType(StatusCodes.Status200OK)]
  public async Task<IActionResult> Update(Fluent_SubCategoryEntity obj)
  {
    if (!this.ModelState.IsValid)
    {
      return this.Ok();
    }

    if (obj.Publisher_Id == 0)
    {
      await this.db.Fluent_SubCategories.AddAsync(obj);
    }
    else
    {
      this.db.Fluent_SubCategories.Update(obj);
    }

    await this.db.SaveChangesAsync();
    return this.Ok();
  }

  [HttpPost(Name = "Delete")]
  [ValidateAntiForgeryToken]
  [ProducesResponseType(StatusCodes.Status200OK)]
  public async Task<IActionResult> Delete(int id)
  {
    Fluent_SubCategoryEntity obj = new();
    obj = await this.db.Fluent_SubCategories.FirstOrDefaultAsync(entity => entity.Publisher_Id == id);

    if (obj == null)
    {
      return this.NotFound();
    }

    this.db.Fluent_SubCategories.Remove(obj);
    await this.db.SaveChangesAsync();

    return this.Ok();
  }
}
