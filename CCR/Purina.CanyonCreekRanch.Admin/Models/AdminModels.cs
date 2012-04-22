using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using Purina.CanyonCreekRanch.Common.Entities;

namespace Purina.CanyonCreekRanch.Admin.Models
{
  public class ProductModel
  {
    public ProductModel() { }

    public ProductModel(Product product)
    {
      if (product != null)
      {
        Description = product.Description;
        Id = product.Id;
        ResourcePath = product.ResourcePath;
        ResourcePrefix = product.ResourcePrefix;
        FeedTable = product.FeedTable;
        GuaranteeTable = product.GuaranteeTable;
        Ingredients = product.Ingredients;
        Nutrition = product.Nutrition;
        ProductCategory = product.ProductCategory;
        Title = product.Title;
        Subtitle = product.SubTitle;
      }
    }

    [Required]
    public string Description { get; set; }
    public int Id { get; set; }
    public string ResourcePath { get; set; }
    public string ResourcePrefix { get; set; }
    public string FeedTable { get; set; }
    public string GuaranteeTable { get; set; }
    public string Ingredients { get; set; }
    public string Nutrition { get; set; }
    [Required]
    public string Title { get; set; }
    public string Subtitle { get; set; }

    [Display(Name = "Category")]
    public Category ProductCategory { get; set; }

    public IEnumerable<Category> Categories { get; set; }

    public Product GetEntity()
    {
      return GetEntity(this);
    }

    public Product GetEntity(ProductModel product)
    {
      Product entity = null;
      if (product != null)
      {
        entity = new Product();
        entity.Description = product.Description;
        entity.Id = product.Id;
        entity.FeedTable = product.FeedTable;
        entity.GuaranteeTable = product.GuaranteeTable;
        entity.Ingredients = product.Ingredients;
        entity.Nutrition = product.Nutrition;
        entity.ProductCategory = product.ProductCategory;
        entity.ResourcePath = product.ResourcePath;
        entity.ResourcePrefix = product.ResourcePrefix;
        entity.SubTitle = product.Subtitle;
        entity.Title = product.Title;
      }

      return entity;
    }

    public void MapEntity(Product entity)
    {
      if (entity != null)
      {
        entity.Description = Description;
        entity.Id = Id;
        entity.FeedTable = FeedTable;
        entity.GuaranteeTable = GuaranteeTable;
        entity.Ingredients = Ingredients;
        entity.Nutrition = Nutrition;
        entity.ProductCategory = ProductCategory;
        entity.ResourcePath = ResourcePath;
        entity.ResourcePrefix = ResourcePrefix;
        entity.SubTitle = Subtitle;
        entity.Title = Title;
      }
    }
  }
}