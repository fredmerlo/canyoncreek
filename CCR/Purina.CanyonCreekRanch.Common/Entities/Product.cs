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
    public string SubTitle { get; set; }
    public string Description { get; set; }
    public string Image1 { get; set; }
    public string Image2 { get; set; }
    public string Image3 { get; set; }
    public string Ingredients { get; set; }
    public string Nutrition { get; set; }

    public virtual Category ProductCategory { get; set; }
    public virtual ICollection<Feed> FeedingTable { get; set; }
    public virtual ICollection<Guarantee> GuaranteeTable { get; set; }
  }
}
