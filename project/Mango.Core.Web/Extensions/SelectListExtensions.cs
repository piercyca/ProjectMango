using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Mango.Core.Entity;

namespace Mango.Core.Web.Extensions
{
    /// <summary>
    /// Helper that generates select lists items
    /// </summary>
    public static class SelectListExtensions
    {
        /// <summary>
        /// ProductCategory select list items
        /// </summary>
        /// <param name="productCategory"></param>
        /// <param name="selectedId"></param>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> ToSelectListItems(
            this IEnumerable<ProductCategory> productCategory, int selectedId)
        {
            return
                productCategory.OrderBy(pc => pc.Name)
                    .Select(pc =>
                        new SelectListItem
                        {
                            Selected = (pc.ProductCategoryId == selectedId),
                            Text = pc.Name,
                            Value = pc.ProductCategoryId.ToString()
                        });
        }
    }
}
