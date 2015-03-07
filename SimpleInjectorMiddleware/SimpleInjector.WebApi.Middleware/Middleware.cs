using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SimpleInjector.WebApi.Middleware
{
    public static class Middleware
    {
       
        public static void UseSimpleInjector(this IAppBuilder app, Container container, HttpConfiguration configuration)
        {
            configuration.DependencyResolver = new SimpleInjectDependencyResolver(container);

            // Create an OWIN middleware to create an execution context scope
            app.Use(async (context, next) =>
            {
                using (var scope = container.BeginExecutionContextScope())
                {
                    await next.Invoke();
                }
            });
        }
    }
}
