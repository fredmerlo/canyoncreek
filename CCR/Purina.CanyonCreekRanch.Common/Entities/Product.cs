using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Purina.CanyonCreekRanch.Common.Entities
{
  public class Product
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Protein { get; set; }
    public string Fat { get; set; }
    public string Vitamins { get; set; }
    public string Ingredients { get; set; }
    public string Nutrition { get; set; }

    public virtual Category ProductCategory { get; set; }
    public virtual Feed FeedingTable { get; set; }
    public virtual Guarantee GuaranteeTable { get; set; }
  }
}
