using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Authors")]
public class AuthorEntity
{
  [Key] 
  public int Author_Id { get; set; }
  [Required] 
  [MaxLength(50)] 
  public string FirstName { get; set; }
  [Required] 
  public int LastName { get; set; }
  [Required]
  public DateTime BirthDate { get; set; }
  [NotMapped] 
  public string FullName 
  {
    get
    {
      return $"{this.FirstName} {this.LastName}";
    }
  }
}
