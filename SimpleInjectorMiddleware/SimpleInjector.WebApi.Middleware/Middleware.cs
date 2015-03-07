using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Owin;
using SimpleInjector;
using SimpleInjector.Advanced;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection.Emit;
using SimpleInjector.Extensions.ExecutionContextScoping;

namespace SimpleInjector.Integration.WebApi.Extensions
{
    public static class Middleware
    {       
        public static void UseSimpleInjector(this IAppBuilder app, Container container, HttpConfiguration configuration)
        {
            configuration.DependencyResolver = new SimpleInjectorDependencyResolver(container);

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
