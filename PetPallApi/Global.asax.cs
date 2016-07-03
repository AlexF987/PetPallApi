using FluentValidation.WebApi;
using PetPallApi.Models;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace PetPallApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            container.Register<IOwnerRepository, OwnerRepository>(Lifestyle.Scoped);
            container.Register<IPetRepository, PetRepository>(Lifestyle.Scoped);


            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

            FluentValidationModelValidatorProvider.Configure(GlobalConfiguration.Configuration);
        }
    }
}
