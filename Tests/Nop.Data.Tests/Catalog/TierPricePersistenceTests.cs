using System;
using Teromac.Core.Domain.Catalog;
using Teromac.Core.Domain.Customers;
using Teromac.Tests;
using NUnit.Framework;

namespace Teromac.Data.Tests.Catalog
{
    [TestFixture]
    public class TierPricePersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_tierPrice()
        {
            var tierPrice = new TierPrice
            {
                StoreId = 7,
                Quantity = 1,
                Price = 2.1M,
                Product = GetTestProduct(),
           };

            var fromDb = SaveAndLoadEntity(tierPrice);
            fromDb.ShouldNotBeNull();
            fromDb.StoreId.ShouldEqual(7);
            fromDb.Quantity.ShouldEqual(1);
            fromDb.Price.ShouldEqual(2.1M);

            fromDb.Product.ShouldNotBeNull();
        }

        [Test]
        public void Can_save_and_load_tierPriceWithCustomerRole()
        {
            var tierPrice = new TierPrice
            {
                Quantity = 1,
                Price = 2,
                Product = GetTestProduct(),
                CustomerRole = new CustomerRole
                {
                    Name = "Administrators",
                    FreeShipping = true,
                    TaxExempt = true,
                    Active = true,
                    IsSystemRole = true,
                    SystemName = "Administrators"
                }
            };

            var fromDb = SaveAndLoadEntity(tierPrice);
            fromDb.ShouldNotBeNull();

            fromDb.CustomerRole.ShouldNotBeNull();
            fromDb.CustomerRole.Name.ShouldEqual("Administrators");
        }

        protected Product GetTestProduct()
        {
            return new Product
            {
                Name = "Product name 1",
                CreatedOnUtc = new DateTime(2010, 01, 03),
                UpdatedOnUtc = new DateTime(2010, 01, 04),
            };
        }
    }
}
