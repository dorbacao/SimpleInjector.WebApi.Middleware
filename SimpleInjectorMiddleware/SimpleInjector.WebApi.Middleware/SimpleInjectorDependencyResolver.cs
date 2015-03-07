using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;

namespace SimpleInjector.WebApi.Middleware
{
    /// <summary>
    ///     Container de Injeção de Dependência do WebApi implementado
    ///     usando o SimpleInject.
    /// </summary>
    public class SimpleInjectorDependencyResolver
        : IDependencyResolver
    {
        private readonly Container _container;

        #region ' Constructor '

        public SimpleInjectorDependencyResolver(Container kernel)
        {
            if (kernel == null)
                throw new ArgumentNullException("kernel");

            _container = kernel;
        }

        #endregion

        #region ' IDependencyResolver '

        public System.Web.Http.Dependencies.IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            return _container.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _container.GetAllInstances(serviceType);
            }
            catch (ActivationException)
            {
                return new List<object>();
            }
        }

        public void Dispose()
        {
            // When BeginScope returns 'this', the Dispose method must be a no-op.
        }

        #endregion
    }
}
