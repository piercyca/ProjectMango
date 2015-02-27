using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Mango.Core.Entities;

namespace Mango.Core.Web.Extensions
{
    public static class SelectListExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectListItems(
            this IEnumerable<ProductCategory> metrics, int selectedId)
        {
            return

                metrics.OrderBy(metric => metric.Name)
                    .Select(metric =>
                        new SelectListItem
                        {
                            Selected = (metric.ProductCategoryId == selectedId),
                            Text = metric.Name,
                            Value = metric.ProductCategoryId.ToString()
                        });
        }
    }
}
