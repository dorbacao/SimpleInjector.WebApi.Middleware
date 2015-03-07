using Microsoft.Owin.Cors;
using Owin;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using SimpleInjector.WebApi.Extensions;
namespace SimpleInjectorMiddleware
{
    public class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            if (app == null) throw new ArgumentNullException("app");

            var webLifeStyle = new WebApiRequestLifestyle();
            var container = new Container();

            container.RegisterSingle<IAppBuilder>(app);
            container.Register<IInterface, IConcrete>(webLifeStyle);

            container.Verify();

            // CORS
            //app.UseCors(CorsOptions.AllowAll);

            // Web API
            var httpConfig = new HttpConfiguration();

            httpConfig.MapHttpAttributeRoutes();

            app.UseSimpleInjector(container, httpConfig);

            httpConfig.EnsureInitialized();

            app.UseWebApi(httpConfig);

#if DEBUG

            app.UseErrorPage();
            app.UseWelcomePage("/");

#endif

        }

    }

}
