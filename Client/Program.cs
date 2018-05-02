using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = Bootstrapper.RegisterTypes();
            var application = container.Resolve<IApplication>();
            application.Run();
        }
    }
}
