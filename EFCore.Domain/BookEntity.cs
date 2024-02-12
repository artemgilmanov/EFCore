using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Books")]
public class BookEntity
{
  [Key]
  public int Id { get; set; }
  public string Title { get; set; }
  public string Author { get; set; }
  [MaxLength(20)]
  [Required]
  public string Isbn { get; set; }
  public decimal Price { get; set; }
  [NotMapped]
  public string PriceRange { get; set; }
}
