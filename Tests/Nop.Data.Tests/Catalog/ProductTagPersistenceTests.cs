﻿using Teromac.Core.Domain.Catalog;
using Teromac.Tests;
using NUnit.Framework;

namespace Teromac.Data.Tests.Catalog
{
    [TestFixture]
    public class ProductTagPersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_productTag()
        {
            var productTag = new ProductTag
                               {
                                   Name = "Name 1",
                               };

            var fromDb = SaveAndLoadEntity(productTag);
            fromDb.ShouldNotBeNull();
            fromDb.Name.ShouldEqual("Name 1");
        }
    }
}