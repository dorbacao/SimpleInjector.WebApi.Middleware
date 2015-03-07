using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInjector.Integration.WebApi.Extensions
{
    internal static class ContainerExtensions
    {
        internal static object TryGet(this Container container, Type type)
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
