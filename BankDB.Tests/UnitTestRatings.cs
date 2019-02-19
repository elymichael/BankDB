namespace BankDB.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Web.Http.Results;
    using BankDB.Models;
    using BankDB.Controllers;

    [TestClass]
    public class UnitTestRatings
    {
        [TestMethod]
        public void TestMethodGetList()
        {

            var context = new TestBankDBContext();
            context.Ratings.Add(new Rating { Id = 1, BranchId = 1, Value = 1, Description = "Bad Service", UserId = 1 });
            context.Ratings.Add(new Rating { Id = 2, BranchId = 1, Value = 5, Description = "Great Service", UserId = 1 });
            context.Ratings.Add(new Rating { Id = 3, BranchId = 2, Value = 4, Description = "Good Service", UserId = 1 });

            var controller = new RatingsController(context);
            var result = controller.GetRatings() as TestRatingDbSet;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Local.Count);
        }

        [TestMethod]
        public void TestMethodGet()
        {
            var context = new TestBankDBContext();
            context.Ratings.Add(GetSingleItem());

            var controller = new RatingsController(context);
            var result = controller.GetRating(1) as OkNegotiatedContentResult<Rating>;

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Content.Id);
        }

        [TestMethod]
        public void TestMethodGetSave()
        {
            var controller = new RatingsController(new TestBankDBContext());
            
            var item = GetSingleItem();

            var result =
                controller.PostRating(item) as CreatedAtRouteNegotiatedContentResult<Rating>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.Id);
            Assert.AreEqual(result.Content.Description, item.Description);
        }

        [TestMethod]
        public void TestMethodDelete()
        {
            var context = new TestBankDBContext();
            var item = GetSingleItem();
            context.Ratings.Add(item);

            var controller = new RatingsController(context);
            var result = controller.DeleteRating(1) as OkNegotiatedContentResult<Rating>;

            Assert.IsNotNull(result);
            Assert.AreEqual(item.Id, result.Content.Id);
        }

        Rating GetSingleItem()
        {
            return new Rating()
            {
                Id = 1, BranchId = 1, Value = 1, Description = "Bad Service", UserId = 1
            };
        }
    }
}
