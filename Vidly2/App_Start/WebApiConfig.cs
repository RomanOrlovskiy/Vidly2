using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Vidly2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            /*
             Pascal notation - first leter of each word(property) is uppercase
             Camel notation - first leter is lower case.
             Json file uses Pascal notation, but JavaScript uses camel one.
             Here is how to fix it:
             */
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Formatting.Indented;

            //Now when you check with Postman, you will recieve a banch
            //of customers with lower-case first letter properties.


            config.MapHttpAttributeRoutes();

            //Here we dont have action routes as in usual routing pattern.
            //like : routeTemplate: "/controller/action/{id}",
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
