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
    public string ResourcePath { get; set; }
    public string ResourcePrefix { get; set; }
    public string FeedTable { get; set; }
    public string GuaranteeTable { get; set; }
    public string Ingredients { get; set; }
    public string Nutrition { get; set; }
    public string FriendlyUrl { get; set; }
    public bool Active { get; set; }

    public virtual Category ProductCategory { get; set; }
  }
}
