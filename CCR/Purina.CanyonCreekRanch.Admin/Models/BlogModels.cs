﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using Purina.CanyonCreekRanch.Common.Entities;

namespace Purina.CanyonCreekRanch.Admin.Models
{
  public class BlogCategoryModel
  {
    public BlogCategoryModel() { }

    public BlogCategoryModel(BlogCategory category)
    {
      if (category != null)
      {
        Id = category.Id;
        Name = category.Name;
      }
    }

    public int Id { get; set; }
    public string Name { get; set; }

    public BlogCategory GetEntity()
    {
      return GetEntity(this);
    }

    public BlogCategory GetEntity(BlogCategoryModel category)
    {
      BlogCategory entity = null;
      if (category != null)
      {
        entity = new BlogCategory();
        entity.Id = category.Id;
        entity.Name = category.Name;
      }

      return entity;
    }
  }

  public class BlogEntryModel
  {
    public BlogEntryModel() { }

    public BlogEntryModel(BlogEntry entry)
    {
      if (entry != null)
      {
        Active = entry.Active;
        Author = entry.Author;
        Content = entry.Content;
        Created = entry.Created;
        EntryCategory = entry.EntryCategory;
        Id = entry.Id;
        Title = entry.Title;

      }
    }

    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Content { get; set; }
    public DateTime Created { get; set; }
    public bool Active { get; set; }
    [Required]
    public string Author { get; set; }

    [Display(Name="Category")]
    public BlogCategory EntryCategory { get; set; }

    public IEnumerable<BlogCategory> Categories { get; set; }

    public BlogEntry GetEntity()
    {
      return GetEntity(this);
    }

    public BlogEntry GetEntity(BlogEntryModel entry)
    {
      BlogEntry entity = null;
      if (entry != null)
      {
        entity = new BlogEntry();
        entity.Active = entry.Active;
        entity.Author = entry.Author;
        entity.Content = entry.Content;
        entity.Created = entry.Created;
        entity.EntryCategory = entry.EntryCategory;
        entity.Id = entry.Id;
        entity.Title = entry.Title;
      }

      return entity;
    }

    public void MapEntity(BlogEntry entity)
    {
      if (entity != null)
      {
        entity.Active = Active;
        entity.Author = Author;
        entity.Content = Content;
        entity.Created = Created;
        entity.EntryCategory = EntryCategory;
        entity.Id = Id;
        entity.Title = Title;
      }
    }
  }
}