using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Purina.CanyonCreekRanch.Common.Entities
{
  public class BlogEntry
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime Created { get; set; }
    public bool Active { get; set; }
    public string Author { get; set; }

    public virtual BlogCategory EntryCategory { get; set; }
  }
}
