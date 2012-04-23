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
        Active = product.Active;
        Description = product.Description;
        Id = product.Id;
        ResourcePath = product.ResourcePath;
        ResourcePrefix = product.ResourcePrefix;
        FeedTable = product.FeedTable;
        FriendlyUrl = product.FriendlyUrl;
        GuaranteeTable = product.GuaranteeTable;
        Ingredients = product.Ingredients;
        Nutrition = product.Nutrition;
        ProductCategory = product.ProductCategory;
        Title = product.Title;
        Subtitle = product.SubTitle;
      }
    }

    public bool Active { get; set; }
    [AllowHtml]
    [Required]
    public string Description { get; set; }
    public int Id { get; set; }
    public string ResourcePath { get; set; }
    public string ResourcePrefix { get; set; }
    [AllowHtml]
    [Required]
    public string FeedTable { get; set; }
    [Required]
    public string FriendlyUrl { get; set; }
    [Required]
    [AllowHtml]
    public string GuaranteeTable { get; set; }
    [AllowHtml]
    [Required]
    public string Ingredients { get; set; }
    [AllowHtml]
    [Required]
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
        entity.Active = Active;
        entity.Description = product.Description;
        entity.Id = product.Id;
        entity.FeedTable = product.FeedTable;
        entity.FriendlyUrl = FriendlyUrl;
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
        entity.Active = Active;
        entity.Description = Description;
        entity.Id = Id;
        entity.FeedTable = FeedTable;
        entity.FriendlyUrl = FriendlyUrl;
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