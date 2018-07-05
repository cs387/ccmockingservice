using ccmockingservice.DAL;
using Swashbuckle.Application;
using System.Web.Http;


namespace ccmockingservice
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
           
        }
    }
}
