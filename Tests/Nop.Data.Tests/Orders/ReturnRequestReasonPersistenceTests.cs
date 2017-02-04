using Teromac.Core.Domain.Orders;
using Teromac.Tests;
using NUnit.Framework;

namespace Teromac.Data.Tests.Orders
{
    [TestFixture]
    public class ReturnRequestReasonPersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_returnRequestReason()
        {
            var returnRequestReason = new ReturnRequestReason
            {
                Name = "Name 1",
                DisplayOrder = 1
            };

            var fromDb = SaveAndLoadEntity(returnRequestReason);
            fromDb.ShouldNotBeNull();
            fromDb.Name.ShouldEqual("Name 1");
            fromDb.DisplayOrder.ShouldEqual(1);
        }
    }
}
