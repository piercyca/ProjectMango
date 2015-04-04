using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mango.Web.Helpers.Admin
{
    public static class SortableHelper
    {
        public static IHtmlString Controls()
        {
            const string controls = "<div class=\"btn-group sortable-controls\" role=\"group\" aria-label=\"sortable controls\">" +
                                    "<a class=\"btn btn-default btn-sm sortable-move\" href=\"\"><span class=\"glyphicon glyphicon-move\" aria-hidden=\"true\"></span> Move</a>" +
                                    "<button class=\"btn btn-danger btn-sm sortable-delete\" type=\"button\"><span class=\"glyphicon glyphicon-remove\" aria-hidden=\"true\"></span> Delete</button>" +
                                    "</div>" + 
                                    "<div class=\"clearfix\"></div>";
            return MvcHtmlString.Create(controls);
        }
    }
}