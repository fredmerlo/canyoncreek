using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using Purina.CanyonCreekRanch.Common.Entities;

namespace Purina.CanyonCreekRanch.Admin.Models
{
  public class FeedModel
  {
    public FeedModel() { }

    public FeedModel(Feed feed)
    {
      Amount = feed.Amount;
      Id = feed.Id;
      FeedProduct = feed.Product;
      Weight = feed.Weight;

    }

    public int Id { get; set; }
    [Required]
    public string Weight { get; set; }
    [Required]
    public string Amount { get; set; }

    [Display(Name="Product")]
    [Required]
    public Product FeedProduct { get; set; }
    public IEnumerable<Product> Products { get; set; }

    public Feed GetEntity()
    {
      return GetEntity(this);
    }

    public Feed GetEntity(FeedModel feed)
    {
      Feed entity = null;
      if (feed != null)
      {
        entity = new Feed();
        entity.Amount = feed.Amount;
        entity.Id = feed.Id;
        entity.Product = feed.FeedProduct;
        entity.Weight = feed.Weight;
      }

      return entity;
    }

    public void MapEntity(Feed entity)
    {
      if (entity != null)
      {
        entity.Amount = Amount;
        entity.Id = Id;
        entity.Product = FeedProduct;
        entity.Weight = Weight;
      }
    }
  }
}