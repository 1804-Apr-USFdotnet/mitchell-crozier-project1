using Autofac;
using DbFirst;
using Operations;
using RepositoryInterfaces;
using Respositories;
using ServiceInterfaces;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Bootstrapper
    {
        public static IContainer container;

        public static IContainer RegisterTypes()
        {
            var builder = new ContainerBuilder();

            //Shout out to my boi Michael 

            builder.RegisterType<ProjectZeroDbContext>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<LoggingService>().As<ILoggingService>().SingleInstance();

            builder.RegisterType<InOut>().As<IInOut>().SingleInstance();

            builder.RegisterType<RestaurantRepository>().As<IRestaurantRepository>();

            builder.RegisterType<RestaurantService>().As<IRestaurantService>();

            builder.RegisterType<ReviewerRepository>().As<IReviewerRepository>();

            builder.RegisterType<ReviewerService>().As<IReviewService>();

            //builder.RegisterType<Queries>().As<IQueries>();

            builder.RegisterType<Application>().As<IApplication>();


            container = builder.Build();

            return container;

        }
    }
}
