﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain;

using System.ComponentModel.DataAnnotations;
public class BookEntity
{
  public int Id { get; set; }
  public string Title { get; set; }
  public string Author { get; set; }
  public string Isbn { get; set; }
  public decimal Price { get; set; }
}
