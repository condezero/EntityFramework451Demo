using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http.Dependencies;
using System.Web.Http;
using TestEntityFrameworkPsql451.App_Start;
using Autofac.Integration.WebApi;

[assembly: OwinStartup(typeof(TestEntityFrameworkPsql451.Startup))]

namespace TestEntityFrameworkPsql451
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var httpConfiguration = new HttpConfiguration();
            WebApiConfig.Register(httpConfiguration);
            var container = AutofacConfig.Register();
            
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            app.UseWebApi(httpConfiguration);
            

        }
    }
}
