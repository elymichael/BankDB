namespace BankDB.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Web.Http.Results;
    using BankDB.Models;
    using BankDB.Controllers;

    [TestClass]
    public class UnitTestBranches
    {
        [TestMethod]
        public void TestMethodGetList()
        {

            var context = new TestBankDBContext();
            context.Branches.Add(new Branch { Id = 1, Name = "BPD", Street = "Av. Lope de Vega", ZipCode = "78451", BankId = 1, UserId = 1, CreatedOn = DateTime.Now });
            context.Branches.Add(new Branch { Id = 2, Name = "BHD", Street = "Av. Lope de Vega", ZipCode = "78458", BankId = 2, UserId = 1, CreatedOn = DateTime.Now });
            context.Branches.Add(new Branch { Id = 3, Name = "Banreservas", Street = "Av. Lope de Vega", ZipCode = "78457", BankId = 3, UserId = 1, CreatedOn = DateTime.Now });

            var controller = new BranchesController(context);
            var result = controller.GetBranches() as TestBranchDbSet;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Local.Count);
        }

        [TestMethod]
        public void TestMethodGet()
        {
            var context = new TestBankDBContext();
            context.Branches.Add(GetSingleItem());

            var controller = new BranchesController(context);
            var result = controller.GetBranch(1) as OkNegotiatedContentResult<Branch>;

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Content.Id);
        }

        [TestMethod]
        public void TestMethodGetSave()
        {
            var controller = new BranchesController(new TestBankDBContext());

            var item = GetSingleItem();

            var result =
                controller.PostBranch(item) as CreatedAtRouteNegotiatedContentResult<Branch>;

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
            context.Branches.Add(item);

            var controller = new BranchesController(context);
            var result = controller.DeleteBranch(1) as OkNegotiatedContentResult<Branch>;

            Assert.IsNotNull(result);
            Assert.AreEqual(item.Id, result.Content.Id);
        }

        Branch GetSingleItem()
        {
            return new Branch()
            {
                Id = 1, Name = "BPD", Street="Av. Lope de Vega", ZipCode="78451", BankId= 1,UserId = 1, CreatedOn = DateTime.Now
            };
        }
    }
}
