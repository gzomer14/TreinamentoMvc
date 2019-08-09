using System.Web;
using System.Web.Mvc;
using NW.CursoMvc.Infra.CrossCutting.MvcFilters;

namespace NW.CursoMvc.UI.Site
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalErrorHandler());
        }
    }
}
