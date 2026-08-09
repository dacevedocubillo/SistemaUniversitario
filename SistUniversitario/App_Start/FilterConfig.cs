using System.Web;
using System.Web.Mvc;
using SistUniversitario.Filters;

namespace SistUniversitario
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new SessionAuthorizeAttribute());
        }
    }
}
