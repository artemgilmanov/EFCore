using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Publishers")]
public class PublisherEntity
{
  [Key]

  public int Publisher_Id { get; set; }
  [Required]
  public string Name { get; set; }
  public string Location { get; set; }
}
