namespace EFCore.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BookDetailEntity
{
  [Key]
  public int BookDetail_Id { get; set; }
  [Required]
  public int NumberofChapters { get; set; }
  public int NumberOfPages { get; set; }
  public string Weight { get; set; }

  // Navigation Properties 1:1
  [ForeignKey("Book")]
  public int Book_Id { get; set; }
  public BookEntity Book{ get; set; }
}
