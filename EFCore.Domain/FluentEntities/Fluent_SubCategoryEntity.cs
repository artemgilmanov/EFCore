using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain.FluentEntities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Fluent_SubCategoryEntity
{
  public int SubCategory_Id { get; set; }

  public string Name { get; set; }
}
