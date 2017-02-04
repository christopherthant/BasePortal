using Teromac.Core;
using Teromac.Core.Domain.Media;
using Teromac.Tests;
using NUnit.Framework;

namespace Teromac.Data.Tests.Media
{
    [TestFixture]
    public class PicturePersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_picture()
        {
            var picture = new Picture
            {
                PictureBinary = new byte[] { 1, 2, 3 },
                MimeType = MimeTypes.ImagePJpeg,
                SeoFilename = "seo filename 1",
                AltAttribute = "AltAttribute 1",
                TitleAttribute = "TitleAttribute 1",
                IsNew = true
            };

            var fromDb = SaveAndLoadEntity(picture);
            fromDb.ShouldNotBeNull();
            fromDb.PictureBinary.ShouldEqual(new byte[] { 1, 2, 3 });
            fromDb.MimeType.ShouldEqual(MimeTypes.ImagePJpeg);
            fromDb.SeoFilename.ShouldEqual("seo filename 1");
            fromDb.AltAttribute.ShouldEqual("AltAttribute 1");
            fromDb.TitleAttribute.ShouldEqual("TitleAttribute 1");
            fromDb.IsNew.ShouldEqual(true);
        }
    }
}
