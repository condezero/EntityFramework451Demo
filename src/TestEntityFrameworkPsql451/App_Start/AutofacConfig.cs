using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using TestEntityFrameworkPsql451.Domain;
using TestEntityFrameworkPsql451.Infrastructure;
using TestEntityFrameworkPsql451.Models;

namespace TestEntityFrameworkPsql451.App_Start
{
    public static class AutofacConfig
    {
        internal static IContainer Register()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //builder.Register(p => {
            //    var demoContext = new RoutingContext();
            //    return new HubComponentRepository(demoContext);
            //}).As<IRepository<HubComponent>>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance();

            

            var container = builder.Build();

            
            return container;

        }
    }
}