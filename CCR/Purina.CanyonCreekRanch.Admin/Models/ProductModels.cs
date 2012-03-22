using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Purina.CanyonCreekRanch.Common.Entities;

namespace Purina.CanyonCreekRanch.Admin.Models
{
  public class ProductModel : Product
  {
    public IEnumerable<Category> Categories 
    {
      get
      {
        IEnumerable<Category> list = null;
        using (var db = new CCRDb())
        {
          list = db.Categories.ToList<Category>();
        }
        return list;
      }
    }
  }
}