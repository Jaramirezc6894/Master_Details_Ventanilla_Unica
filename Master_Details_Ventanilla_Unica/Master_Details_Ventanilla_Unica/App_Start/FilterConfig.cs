using System.Web;
using System.Web.Mvc;

namespace Master_Details_Ventanilla_Unica
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
