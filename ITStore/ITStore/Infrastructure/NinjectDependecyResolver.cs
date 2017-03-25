using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITStore.Infrastructure
{
    public class NinjectDependecyResolver : IDependencyResolver
    {
        IKernel kernel;

        public NinjectDependecyResolver(IKernel _kernel)
        {
            kernel = _kernel;
            AddBindings();
        }


        public object GetService(Type _serviceType)
        {
            return kernel.TryGet(_serviceType);
        }

        public IEnumerable<object> GetServices(Type _serviceType)
        {
            return kernel.GetAll(_serviceType);
        }

        private void AddBindings()
        {

        }
    }
}