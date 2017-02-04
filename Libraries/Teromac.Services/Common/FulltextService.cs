using System;
using System.Linq;
using Teromac.Core.Data;
using Teromac.Core.Domain.Common;
using Teromac.Data;

namespace Teromac.Services.Common
{
    /// <summary>
    /// Full-Text service
    /// </summary>
    public partial class FulltextService : IFulltextService
    {
        #region Fields

        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly CommonSettings _commonSettings;
        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="dataProvider">Data provider</param>
        /// <param name="dbContext">Database Context</param>
        /// <param name="commonSettings">Common settings</param>
        public FulltextService(IDataProvider dataProvider, IDbContext dbContext,
            CommonSettings commonSettings)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._commonSettings = commonSettings;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets value indicating whether Full-Text is supported
        /// </summary>
        /// <returns>Result</returns>
        public virtual bool IsFullTextSupported()
        {

            //stored procedures are enabled and supported by the database. 
            var result = _dbContext.SqlQuery<int>("EXEC [FullText_IsSupported]");
            return result.FirstOrDefault() > 0;
        }

        /// <summary>
        /// Enable Full-Text support
        /// </summary>
        public virtual void EnableFullText()
        {
            //stored procedures are enabled and supported by the database.
            _dbContext.ExecuteSqlCommand("EXEC [FullText_Enable]", true);

        }

        /// <summary>
        /// Disable Full-Text support
        /// </summary>
        public virtual void DisableFullText()
        {
            //stored procedures are enabled and supported by the database.
            _dbContext.ExecuteSqlCommand("EXEC [FullText_Disable]", true);
        }

        #endregion
    }
}
