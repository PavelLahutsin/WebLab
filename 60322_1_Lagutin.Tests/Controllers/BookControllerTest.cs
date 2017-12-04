using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using _60322_1_Lagutin.Controllers;
using _60322_1_Lagutin.DAL.Entities;
using _60322_1_Lagutin.DAL.Interfaces;
using _60322_1_Lagutin.Models;

namespace _60322_1_Lagutin.Tests.Controllers
{
    [TestClass]
    public class BookControllerTest
    {
        [TestMethod]
        public void PagingTest()
        {

            // Arrange
            // Макет репозитория
            var mock = new Mock<IRepository<Book>>();
            mock.Setup(r => r.GetAll())
                .Returns(new List<Book> {
                    new Book { Id=1 },
                    new Book { Id= 2 },
                    new Book { Id=3 },
                    new Book { Id=4 },
                    new Book { Id=5 }
                });
            // Создание объекта контроллера
            var controller = new BookController(mock.Object);
            // Act
            // Макеты для получения HttpContext HttpRequest
            var request = new Mock<HttpRequestBase>();
            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(h => h.Request).Returns(request.Object);
            // Создание контекста контроллера
            controller.ControllerContext = new ControllerContext {HttpContext = httpContext.Object};


            // Вызов метода List
            var view = controller.List(null, 2) as ViewResult;
            // Assert
            Assert.IsNotNull(view, "Представление не получено");
            Assert.IsNotNull(view.Model, "Модель не получена");
            if (view.Model is PageListViewModel<Book> model)
            {
                Assert.AreEqual(2, model.Count);
                Assert.AreEqual(4, model[0].Id);
                Assert.AreEqual(5, model[1].Id);
            }

            var valueCollection =
                new NameValueCollection {{"X-Requested-With", "XMLHttpRequest"}, {"Accept", "application/json"}};
            // другой вариант: valueCollection.Add("Accept", "HTML");
            request.Setup(r => r.Headers).Returns(valueCollection);
        }

        [TestMethod]
        public void GenreTest()
        {

            // Arrange
            // Макет репозитория
            var mock = new Mock<IRepository<Book>>();
            mock.Setup(r => r.GetAll())
                .Returns(new List<Book> {
                    new Book { Id=1, Genre = "Русская классика"},
                    new Book { Id= 2, Genre = "Детективы"},
                    new Book { Id=3, Genre = "Классика"},
                    new Book { Id=4, Genre = "Фентези" },
                    new Book { Id=5, Genre = "Роман"}
                });
            // Создание объекта контроллера
            var controller = new BookController(mock.Object);
            // Act
            // Макеты для получения HttpContext HttpRequest
            var request = new Mock<HttpRequestBase>();
            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(h => h.Request).Returns(request.Object);
            // Создание контекста контроллера
            controller.ControllerContext = new ControllerContext { HttpContext = httpContext.Object };


            // Вызов метода List
            var view = controller.List("Детективы", 2) as ViewResult;
            // Assert
            Assert.IsNotNull(view, "Представление не получено");
            Assert.IsNotNull(view.Model, "Модель не получена");
            if (view.Model is PageListViewModel<Book> model)
            {
                Assert.AreEqual(0, model.Count);
                //Assert.AreEqual(4, model[0].Id);
                //Assert.AreEqual(5, model[1].Id);
            }

            var valueCollection =
                new NameValueCollection { { "X-Requested-With", "XMLHttpRequest" }, { "Accept", "application/json" } };
            // другой вариант: valueCollection.Add("Accept", "HTML");
            request.Setup(r => r.Headers).Returns(valueCollection);
        }
    }
}
