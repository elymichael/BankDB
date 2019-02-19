namespace BankDB.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Web.Http.Results;
    using BankDB.Models;
    using BankDB.Controllers;

    [TestClass]
    public class UnitTestBanks
    {
        [TestMethod]
        public void TestMethodGetList()
        {

            var context = new TestBankDBContext();
            context.Banks.Add(new Bank { Id = 1, Name = "BPD", Street = "Av. Maximo Gomez", ZipCode = "784578", UserId = 1, CreatedOn = DateTime.Now });
            context.Banks.Add(new Bank { Id = 2, Name = "BHD", Street = "Av. Winston Churchill", ZipCode = "457845", UserId = 1, CreatedOn = DateTime.Now });
            context.Banks.Add(new Bank { Id = 3, Name = "Banreservas", Street = "Av. Winston Churchill", ZipCode = "356564", UserId = 1, CreatedOn = DateTime.Now });

            var controller = new BanksController(context);
            var result = controller.GetBanks() as TestBankDbSet;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Local.Count);
        }

        [TestMethod]
        public void TestMethodGet()
        {
            var context = new TestBankDBContext();
            context.Banks.Add(GetSingleItem());

            var controller = new BanksController(context);
            var result = controller.GetBank(1) as OkNegotiatedContentResult<Bank>;

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Content.Id);
        }

        [TestMethod]
        public void TestMethodGetSave()
        {
            var controller = new BanksController(new TestBankDBContext());

            var item = GetSingleItem();

            var result =
                controller.PostBank(item) as CreatedAtRouteNegotiatedContentResult<Bank>;

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
            context.Banks.Add(item);

            var controller = new BanksController(context);
            var result = controller.DeleteBank(1) as OkNegotiatedContentResult<Bank>;

            Assert.IsNotNull(result);
            Assert.AreEqual(item.Id, result.Content.Id);
        }

        Bank GetSingleItem()
        {
            return new Bank()
            {
               Id = 1, Name = "BPD", Street = "Av. Maximo Gomez", ZipCode = "784578", UserId = 1, CreatedOn = DateTime.Now
            };
        }
    }
}
