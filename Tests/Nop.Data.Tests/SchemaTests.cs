using System.Data.Entity;
using Teromac.Tests;
using NUnit.Framework;

namespace Teromac.Data.Tests
{
    [TestFixture]
    public class SchemaTests
    {
        [Test]
        public void Can_generate_schema()
        {
            Database.SetInitializer<TeromacObjectContext>(null);
            var ctx = new TeromacObjectContext("Test");
            string result = ctx.CreateDatabaseScript();
            result.ShouldNotBeNull();
        }
    }
}
