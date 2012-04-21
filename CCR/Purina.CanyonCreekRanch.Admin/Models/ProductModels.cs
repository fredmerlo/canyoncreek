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
        Id = product.Id;
        Image1 = product.Image1;
        Image2 = product.Image2;
        Image3 = product.Image3;
        Ingredients = product.Ingredients;
        Nutrition = product.Nutrition;
        ProductCategory = product.ProductCategory;
        Title = product.Title;
        Subtitle = product.SubTitle;
      }
    }

    [Required()]
    public string Description { get; set; }
    public int Id { get; set; }
    public string Image1 { get; set; }
    public string Image2 { get; set; }
    public string Image3 { get; set; }
    public string Ingredients { get; set; }
    public string Nutrition { get; set; }
    [Required()]
    public string Title { get; set; }
    public string Subtitle { get; set; }

    public List<FeedModel> FeedTable { get; set; }
    public List<GuaranteeModel> GuaranteeTable { get; set; }
    
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
        entity.Id = product.Id;
        entity.Image1 = product.Image1;
        entity.Image2 = product.Image2;
        entity.Image3 = product.Image3;
        entity.Ingredients = product.Ingredients;
        entity.Nutrition = product.Nutrition;
        entity.ProductCategory = product.ProductCategory;
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
        entity.Image1 = Image1;
        entity.Image2 = Image2;
        entity.Image3 = Image3;
        entity.Ingredients = Ingredients;
        entity.Nutrition = Nutrition;
        entity.ProductCategory = ProductCategory;
        entity.SubTitle = Subtitle;
        entity.Title = Title;
      }
    }
  }
}