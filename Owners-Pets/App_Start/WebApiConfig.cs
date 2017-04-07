using System.Web.Http;
using Owners_Pets.Helpers;

namespace Owners_Pets
{


    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            

            // Web API routes
            config.MapHttpAttributeRoutes();

            //Convert to JSON format
            config.Formatters.Add(new BrowserJsonFormatter());

            //Enable CORS in the project
            config.EnableCors();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
