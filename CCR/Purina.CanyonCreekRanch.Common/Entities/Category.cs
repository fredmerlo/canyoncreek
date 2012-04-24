using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Purina.CanyonCreekRanch.Common.Entities
{
  public class Category
  {
    public enum Classifier { Cat = 1, Dog, Snack, Other }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public string FriendlyUrl { get; set; }

    [Display(Name = "Type")]
    public Classifier ClassifierType 
    {
      get { return (Classifier)Type; }
      set { Type = (int) value; }
    }

    public int Type { get; set; }
  }
}
