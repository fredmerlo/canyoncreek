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
        Id = category.Id;
        Name = category.Name;
      }
    }

    public int Id { get; set; }
    public string Name { get; set; }

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
        entity.Id = category.Id;
        entity.Name = category.Name;
      }

      return entity;
    }
  }
}