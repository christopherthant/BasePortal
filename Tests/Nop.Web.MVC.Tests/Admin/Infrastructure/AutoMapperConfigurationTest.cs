using Teromac.Admin.Infrastructure.Mapper;
using NUnit.Framework;

namespace Teromac.Web.MVC.Tests.Admin.Infrastructure
{
    [TestFixture]
    public class AutoMapperConfigurationTest
    {
        [Test]
        public void Configuration_is_valid()
        {
            AutoMapperConfiguration.Init();
            AutoMapperConfiguration.MapperConfiguration.AssertConfigurationIsValid();
        }
    }
}
