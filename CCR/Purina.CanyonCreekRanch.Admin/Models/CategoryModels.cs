using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Purina.CanyonCreekRanch.Common.Entities;

namespace Purina.CanyonCreekRanch.Admin.Models
{
  public class CategoryModel
  {
    public CategoryModel() { }

    public CategoryModel(Category category)
    {
      if (category != null)
      {
        FriendlyUrl = category.FriendlyUrl;
        Id = category.Id;
        Name = category.Name;
        Subtitle = category.Subtitle;
        Title = category.Title;
      }
    }

    public string FriendlyUrl { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Subtitle { get; set; }
    public string Title { get; set; }

    List<ProductModel> Products { get; set; }

    public Category GetEntity()
    {
      return GetEntity(this);
    }

    public Category GetEntity(CategoryModel category)
    {
      Category entity = null;
      if (category != null)
      {
        entity = new Category();
        entity.FriendlyUrl = category.FriendlyUrl;
        entity.Id = category.Id;
        entity.Name = category.Name;
        entity.Subtitle = category.Subtitle;
        entity.Title = category.Title;
      }

      return entity;
    }
  }
}