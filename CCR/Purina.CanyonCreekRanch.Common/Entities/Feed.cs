using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Purina.CanyonCreekRanch.Common.Entities
{
  public class Feed
  {
    public int Id { get; set; }
    public string Weight { get; set; }
    public string Amount { get; set; }

    public virtual Product Product { get; set; }
  }
}
