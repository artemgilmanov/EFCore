namespace EFCore.Domain;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("SubCategories")]
public class SubCategoryEntity
{
  [Key]
  public int Publisher_Id { get; set; }
  [Required]
  [MaxLength(50)]
  public string Name { get; set; }
}
