using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniCMS.Data.Models
{
  public class Category
  {
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public List<Product> Products { get; set; }
  }
}
