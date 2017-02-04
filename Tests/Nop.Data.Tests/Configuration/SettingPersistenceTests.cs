using Teromac.Core.Domain.Configuration;
using Teromac.Tests;
using NUnit.Framework;

namespace Teromac.Data.Tests.Configuration
{
    [TestFixture]
    public class SettingPersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_setting()
        {
            var setting = new Setting
            {
                Name = "Setting1",
                Value = "Value1",
                StoreId = 1,
            };

            var fromDb = SaveAndLoadEntity(setting);
            fromDb.ShouldNotBeNull();
            fromDb.Name.ShouldEqual("Setting1");
            fromDb.Value.ShouldEqual("Value1");
            fromDb.StoreId.ShouldEqual(1);
        }
    }
}
