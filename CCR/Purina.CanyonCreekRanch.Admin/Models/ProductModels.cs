using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        Fat = product.Fat;
        Id = product.Id;
        Ingredients = product.Ingredients;
        Nutrition = product.Nutrition;
        ProductCategory = product.ProductCategory;
        Protein = product.Protein;
        Title = product.Title;
        Vitamins = product.Vitamins;
      }
    }

    [Required()]
    public string Description { get; set; }
    public string Fat { get; set; }
    public int Id { get; set; }
    public string Ingredients { get; set; }
    public string Nutrition { get; set; }
    public string Protein { get; set; }
    [Required()]
    public string Title { get; set; }
    public string Vitamins { get; set; }
    
    [Display(Name="Category")]
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
        entity.Fat = product.Fat;
        entity.Id = product.Id;
        entity.Ingredients = product.Ingredients;
        entity.Nutrition = product.Nutrition;
        entity.ProductCategory = product.ProductCategory;
        entity.Protein = product.Protein;
        entity.Title = product.Title;
        entity.Vitamins = product.Vitamins;
      }

      return entity;
    }
  }
}