using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Core;
using Data;
using Services.Content;
using Umbraco.Web;

namespace WebTest.App_Start
{
    public class DependencyRegistrar
    {
        public static void RegisterDependencies(ContainerBuilder builder)
        {
            //register all controllers found in this assembly
            builder.RegisterControllers(typeof(DependencyRegistrar).Assembly);

            //register umbraco webapi controllers used by the admin site
            builder.RegisterApiControllers(typeof(UmbracoApplication).Assembly);

            //register dependencies
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<ContentJsonService>().As<IContentJsonService>().InstancePerLifetimeScope();

            //dbContext
            builder.RegisterType<AppDbContext>().AsImplementedInterfaces().InstancePerLifetimeScope();
            // builder.RegisterType<AppDbContext>().As<DbContext>().InstancePerLifetimeScope();
            // builder.Register<IDbContext>(c => new AppDbContext()).InstancePerLifetimeScope();
            //builder.RegisterType<Lecoati.LeBlender.Extension.Controllers.LeBlenderEditorManagerTreeController>();
            builder.RegisterApiControllers(typeof(Lecoati.LeBlender.Extension.Controllers.LeBlenderController).Assembly);
            builder.RegisterControllers(typeof(Lecoati.LeBlender.Extension.Controllers.LeBlenderController).Assembly);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}