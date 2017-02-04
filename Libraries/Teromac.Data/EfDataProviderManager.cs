using System;
using Teromac.Core;
using Teromac.Core.Data;

namespace Teromac.Data
{
    public partial class EfDataProviderManager : BaseDataProviderManager
    {
        public EfDataProviderManager(DataSettings settings):base(settings)
        {
        }

        public override IDataProvider LoadDataProvider()
        {

            var providerName = Settings.DataProvider;
            if (String.IsNullOrWhiteSpace(providerName))
                throw new TeromacException("Data Settings doesn't contain a providerName");

            switch (providerName.ToLowerInvariant())
            {
                case "sqlserver":
                    return new SqlServerDataProvider();
                default:
                    throw new TeromacException(string.Format("Not supported dataprovider name: {0}", providerName));
            }
        }

    }
}
