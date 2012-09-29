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
    public DbSet<BlogCategory> BlogCategories { get; set; }
    public DbSet<BlogEntry> BlogEntries { get; set; }
    public DbSet<PageContent> PageContents { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Category>().Ignore(i => i.ClassifierType);

      modelBuilder.Entity<Product>()
        .HasRequired<Category>(p => p.ProductCategory);

      modelBuilder.Entity<BlogEntry>()
        .HasRequired<BlogCategory>(e => e.EntryCategory);
    }
  }
}
