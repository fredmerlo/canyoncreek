using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using Purina.CanyonCreekRanch.Common.Entities;

namespace Purina.CanyonCreekRanch.Admin.Models
{
  public class GuaranteeModel
  {
    public GuaranteeModel() { }

    public GuaranteeModel(Guarantee guarantee)
    {
      Analysis = guarantee.Analysis;
      Description = guarantee.Description;
      Id = guarantee.Id;
      Percent = guarantee.Percent;
      GuarnateeProduct = guarantee.Product;
    }

    public int Id { get; set; }
    public string Analysis { get; set; }
    public string Description { get; set; }
    public string Percent { get; set; }
    public Product GuarnateeProduct { get; set; }
    public IEnumerable<Product> Products { get; set; }

    public Guarantee GetEntity()
    {
      return GetEntity(this);
    }

    public Guarantee GetEntity(GuaranteeModel guarantee)
    {
      Guarantee entity = null;
      if (guarantee != null)
      {
        entity = new Guarantee();
        entity.Analysis = guarantee.Analysis;
        entity.Description = guarantee.Description;
        entity.Id = guarantee.Id;
        entity.Percent = guarantee.Percent;
        entity.Product = guarantee.GuarnateeProduct;
      }

      return entity;
    }
  }
}