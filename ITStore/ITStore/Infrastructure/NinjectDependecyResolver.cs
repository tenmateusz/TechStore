using ITStore.Domain.Abstract;
using ITStore.Domain.Entities;
using Moq;
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
            Mock<IPostRespository> mock = new Mock<IPostRespository>();

            mock.Setup(m => m.Posts).Returns(new List<Post>
            {
                new Post() {Author = "Mateusz",HelpfulAnswer = false,Points = 12,PostDate = DateTime.Now.Date,
                            Tags = new List<string>(){ ".net","programowanie" },Text = "Test1  \n test ",Topic = "Test1 - Topic"},

                new Post() {Author = "Łukasz",HelpfulAnswer = false,Points = 12,PostDate = DateTime.Now.Date,
                            Tags = new List<string>(){ "Asp","różne","java" },Text = @"
                            jest tekstem stosowanym jako przykładowy wypełniacz w przemyśle poligraficznym. 
                            Został po raz pierwszy użyty w XV w. przez nieznanego drukarza do wypełnienia tekstem próbnej książki.Pięć
                            wieków później zaczął być używany przemyśle elektronicznym, pozostając praktycznie niezmienionym. 
                            Spopularyzował się w latach 60.XX w.wraz z publikacją arkuszy Letrasetu, zawierających fragmenty Lorem Ipsum, 
                            a ostatnio z zawierającym różne wersje Lorem Ipsum oprogramowaniem przeznaczonym do realizacji 
                            druków na komputerach osobistych, jak Aldus PageMaker",Topic = "Test2 - Topic"},

                new Post() {Author = "Adrian",HelpfulAnswer = false,Points = 4,PostDate = DateTime.Now.Date,
                            Tags = new List<string>(){ "Ksiazki","programowanie w j2ee" },Text = "Test3 = \n test 123",Topic = "Test3 - Topic"},

                new Post() {Author = "Mateusz",HelpfulAnswer = false,Points = 13,PostDate = DateTime.Now.Date,
                            Tags = new List<string>(){ ".net" },Text = "Test4  \n test ",Topic = "Test4 - Topic"},

                new Post() {Author = "Anna",HelpfulAnswer = false,Points = 23,PostDate = DateTime.Now.Date,
                            Tags = new List<string>(){ "php" },Text = "Test5  \n test ",Topic = "Test 5- Topic"},
                });


            kernel.Bind<IPostRespository>().ToConstant(mock.Object);
        }
    }
}