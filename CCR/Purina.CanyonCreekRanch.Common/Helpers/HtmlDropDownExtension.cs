using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Purina.CanyonCreekRanch.Common.Helpers
{
  public static class HtmlDropDownExtension
  {
    public static MvcHtmlString EnumDropDownList<TEnum>(this HtmlHelper htmlHelper, string name, TEnum selectedValue)
    {
      IEnumerable<TEnum> values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

      IEnumerable<SelectListItem> items =
          from value in values
          select new SelectListItem
          {
            Text = value.ToString(),
            Value = value.ToString(),
            Selected = (value.Equals(selectedValue))
          };

      return htmlHelper.DropDownList(name, items.OrderBy(i => i.Text));
    }

    public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression)
    {
      ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
      IEnumerable<TEnum> values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

      IEnumerable<SelectListItem> items =
          values.Select(value => new SelectListItem
          {
            Text = value.ToString(),
            Value = value.ToString(),
            Selected = value.Equals(metadata.Model)
          });

      return htmlHelper.DropDownListFor(expression, items.OrderBy(i => i.Text));
    }
  }
}
