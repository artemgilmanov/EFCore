﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Genres")]
public class GenreEntity
{
  [Key]
  public int Id { get; set; }
  [Column("GenreName")]
  public string Name { get; set; }
  [Column("GenreDisplay")]
  public int Display { get; set; }
}
