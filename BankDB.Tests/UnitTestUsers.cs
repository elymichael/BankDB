namespace BankDB.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Web.Http.Results;
    using BankDB.Models;
    using BankDB.Controllers;

    [TestClass]
    public class UnitTestUsers
    {
        [TestMethod]
        public void TestMethodGetList()
        {

            var context = new TestBankDBContext();
            context.Users.Add(new User { Id = 1, Name = "Michael Núñez", Email = "elymichael@gmail.com", Password = "12345678", CreatedOn = DateTime.Now });
            context.Users.Add(new User { Id = 2, Name = "Ramón Calmona", Email = "ramoncalmona@gmail.com", Password = "12345678", CreatedOn = DateTime.Now });
            context.Users.Add(new User { Id = 3, Name = "Santos Peralta", Email = "santosperalta@gmail.com", Password = "12345678", CreatedOn = DateTime.Now });

            var controller = new UsersController(context);
            var result = controller.GetUsers() as TestUserDbSet;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Local.Count);
        }

        [TestMethod]
        public void TestMethodGet()
        {
            var context = new TestBankDBContext();
            context.Users.Add(GetSingleItem());

            var controller = new UsersController(context);
            var result = controller.GetUser(1) as OkNegotiatedContentResult<User>;

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Content.Id);
        }

        [TestMethod]
        public void TestMethodGetSave()
        {
            var controller = new UsersController(new TestBankDBContext());

            var item = GetSingleItem();

            var result =
                controller.PostUser(item) as CreatedAtRouteNegotiatedContentResult<User>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.Id);
            Assert.AreEqual(result.Content.Name, item.Name);
        }

        [TestMethod]
        public void TestMethodDelete()
        {
            var context = new TestBankDBContext();
            var item = GetSingleItem();
            context.Users.Add(item);

            var controller = new UsersController(context);
            var result = controller.DeleteUser(1) as OkNegotiatedContentResult<User>;

            Assert.IsNotNull(result);
            Assert.AreEqual(item.Id, result.Content.Id);
        }

        User GetSingleItem()
        {
            return new User()
            {
                Id = 1, Name = "Michael Núñez", Email = "elymichael@gmail.com", Password = "12345678", CreatedOn = DateTime.Now
            };
        }
    }
}
