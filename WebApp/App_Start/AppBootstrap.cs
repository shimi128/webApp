using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Core.Models;
using Services.Content;
using Umbraco.Core;
using WebTest.Domains;

namespace WebTest.App_Start
{
    public class AppBootstrap: IApplicationEventHandler
    {
       
        public void OnApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
        }

        public void OnApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            Umbraco.Core.Services.ContentService.Publishing += ContentService_Publishing;
        }

        private void ContentService_Publishing(Umbraco.Core.Publishing.IPublishingStrategy sender, Umbraco.Core.Events.PublishEventArgs<Umbraco.Core.Models.IContent> e)
        {
            var contentJsonService = (IContentJsonService)AutofacDependencyResolver.Current.GetService(typeof(IContentJsonService));
            
            foreach (var entity in e.PublishedEntities)
            {
                var content = new ContentModel
                {
                    NodeId = entity.Id,
                    Name = entity.Name,
                    Properties = entity.Properties
                };
                contentJsonService.AddContent(new JsonContentModel
                {
                    Props = Newtonsoft.Json.JsonConvert.SerializeObject(content.Properties),
                    Name = content.Name,
                    NodeId = content.NodeId
                });
            }
        }

        public void OnApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            DependencyRegistrar.RegisterDependencies(new ContainerBuilder());
        }
    }
}