using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using System.Linq;
using Moq;
using Todo.Domain.Enums;
using Todo.Domain.Abstract;
using Todo.Domain.Repository;
using Ninject.Web.Common;

namespace Todo.Web.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {

            kernel.Bind<EFDbContext>().ToSelf().InRequestScope();
            kernel.Bind<IDoRepository>().To<EFDoRepository>();
        }
    }
}