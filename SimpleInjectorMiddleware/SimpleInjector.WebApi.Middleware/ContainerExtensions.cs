using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInjector.WebApi.Middleware
{
    public static class ContainerExtensions
    {
        public static object TryGet(this Container container, Type type)
        {
            try
            {
                return container.GetInstance(type);
            }
            catch (ActivationException ex)
            {
                return null;
            }
        }
    }
}
