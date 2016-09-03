using System.Web;
using System.Web.Mvc;

namespace Vidly2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //Making [Authorize] attirubte global.
            //So if a user goes to any page of our web-app while not loged-in
            //he will be redirected to log-in page.
            filters.Add(new AuthorizeAttribute());

            //With this the application wont longer be available on
            //http chanel, only https now.
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
