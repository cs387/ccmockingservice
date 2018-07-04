using ccmockingservice.DAL;
using System.Web.Http;


namespace ccmockingservice
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //System.Data.Entity.Database.SetInitializer(new DatabaseInitializer());

        }
    }
}
