using System.Collections.Generic;
using Teromac.Core.Configuration;

namespace Teromac.Core.Domain.Common
{
    public class CommonSettings : ISettings
    {
        public CommonSettings()
        {
            
        }
        /// <summary>
        /// Gets or sets a value indicating whether full-text search is supported
        /// </summary>
        public bool UseFullTextSearch { get; set; }

        /// <summary>
        /// Gets or sets a Full-Text search mode
        /// </summary>
        public FulltextSearchMode FullTextMode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 404 errors (page or file not found) should be logged
        /// </summary>
        public bool Log404Errors { get; set; }
    }
}