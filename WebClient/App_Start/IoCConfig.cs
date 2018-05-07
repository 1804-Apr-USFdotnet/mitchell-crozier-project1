using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using DbFirst;
using RepositoryInterfaces;
using Respositories;
using ServiceInterfaces;
using Services;
using WebClient.Models;

namespace WebClient.App_Start
{
    public class IoCConfig
    {
        //public static IContainer container;

        public static void RegisterTypes()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile(new Maps()); });
            var mapper = mapperConfiguration.CreateMapper();

            //Automapper
            builder.RegisterInstance(mapper).As<IMapper>();

            //Shout out to my boi Michael 
            builder.RegisterType<ProjectZeroDbContext>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<LoggingService>().As<ILoggingService>().SingleInstance();

            builder.RegisterType<RestaurantRepository>().As<IRestaurantRepository>();

            builder.RegisterType<RestaurantService>().As<IRestaurantService>();

            builder.RegisterType<ReviewerRepository>().As<IReviewerRepository>();

            builder.RegisterType<ReviewerService>().As<IReviewService>();


            //builder.RegisterType<Queries>().As<IQueries>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));



        }
    }
}