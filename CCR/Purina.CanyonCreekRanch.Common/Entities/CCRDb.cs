using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace Purina.CanyonCreekRanch.Common.Entities
{
  public class CCRDb : DbContext
  {
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Feed> Feeds { get; set; }
    public DbSet<Guarantee> Guarantees { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Product>().HasRequired<Category>(p => p.ProductCategory);
    }
  }
}
