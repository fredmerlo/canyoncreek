using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Purina.CanyonCreekRanch.Common.Entities
{
  public class Category
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public string FriendlyUrl { get; set; }
  }
}
