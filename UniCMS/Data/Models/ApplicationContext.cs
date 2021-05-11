using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UniCMS.Data.Models
{
  //Определение контекста данных
  public class ApplicationContext : DbContext
  {
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
    {
      Database.EnsureCreated();
    }
  }
}
