using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain;

using System.ComponentModel.DataAnnotations;
public class GenreEntity
{
   public int Id { get; set; }  
   public string Name { get; set; }
   public int Display { get; set; }
}
