using System.Web;
using System.Web.Mvc;

namespace real_MVC_fluent_nhibernate_try
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
