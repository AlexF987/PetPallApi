[assembly: WebActivator.PostApplicationStartMethod(typeof(PetPallApi.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace PetPallApi.App_Start
{
    using System.Web.Http;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using Models;

    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Register<IOwnerRepository, OwnerRepository>(Lifestyle.Scoped);
            container.Register<IPetRepository, PetRepository>(Lifestyle.Scoped);
            container.Register<IDbContextFactory, DBContextFactory>(Lifestyle.Singleton);

            container.Verify();
            
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
     
        private static void InitializeContainer(Container container)
        {           
            // For instance:
            // container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);
        }
    }
}