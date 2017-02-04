using Teromac.Core.Domain.Catalog;
using Teromac.Core.Domain.Customers;
using Teromac.Tests;
using NUnit.Framework;

namespace Teromac.Data.Tests.Customers
{
    [TestFixture]
    public class CheckoutAttributeValuePersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_customerAttributeValue()
        {
            var cav = new CustomerAttributeValue
                    {
                        Name = "Name 2",
                        IsPreSelected = true,
                        DisplayOrder = 1,
                        CustomerAttribute = new CustomerAttribute
                        {
                            Name = "Name 1",
                            IsRequired = true,
                            AttributeControlType = AttributeControlType.DropdownList,
                            DisplayOrder = 2
                        }
                    };

            var fromDb = SaveAndLoadEntity(cav);
            fromDb.ShouldNotBeNull();
            fromDb.Name.ShouldEqual("Name 2");
            fromDb.IsPreSelected.ShouldEqual(true);
            fromDb.DisplayOrder.ShouldEqual(1);

            fromDb.CustomerAttribute.ShouldNotBeNull();
            fromDb.CustomerAttribute.Name.ShouldEqual("Name 1");
        }
    }
}