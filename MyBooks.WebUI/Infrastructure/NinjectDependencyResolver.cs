using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ninject;
using MyBooks.Domain.Concrete;
using MyBooks.Domain.Abstract;
using MyBooks.Domain.Entities;
using Moq;
using MyBooks.WebUI.Infrastructure;

namespace MyBooks.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        IKernel kernel;

        public NinjectDependencyResolver(IKernel ker)
        {
            kernel = ker;
            AddBindings();

        }

        public object GetService(Type type)
        {
            return kernel.TryGet(type);
        }

        public IEnumerable<object> GetServices(Type type)
        {
            return kernel.GetAll(type);
        }

        public void AddBindings()
        {
           kernel.Bind<IRepository<Author>>().To<EFAuthorRepository>();
           kernel.Bind<IRepository<Book>>().To<EFBookRepository>();
           kernel.Bind<IRepository<Genre>>().To<EFGenreRepository>();
           kernel.Bind<IRepository<Publisher>>().To<EFPublisherRepository>();
           kernel.Bind<IRepository<CommonBook>>().To<EFCommonBookRepository>();
           kernel.Bind<IEntityCollector>().To<EntityCollector>();
            //Mock<IAuthorRepository> mock = new Mock<IAuthorRepository>();
            //mock.Setup(m=>m.Authors).Returns(new List<Author>{new Author{AuthotId=1, Name="fdadfs"}});
            //kernel.Bind<IAuthorRepository>().ToConstant(mock.Object);
        }
    }
}