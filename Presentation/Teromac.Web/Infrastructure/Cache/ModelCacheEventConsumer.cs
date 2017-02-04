using Teromac.Core.Caching;
using Teromac.Core.Domain.Configuration;
using Teromac.Core.Domain.Directory;
using Teromac.Core.Domain.Localization;
using Teromac.Core.Events;
using Teromac.Core.Infrastructure;
using Teromac.Services.Events;

namespace Teromac.Web.Infrastructure.Cache
{
    /// <summary>
    /// Model cache event consumer (used for caching of presentation layer models)
    /// </summary>
    public partial class ModelCacheEventConsumer: 
        //languages
        IConsumer<EntityInserted<Language>>,
        IConsumer<EntityUpdated<Language>>,
        IConsumer<EntityDeleted<Language>>,
        //settings
        IConsumer<EntityUpdated<Setting>>,
        //states/province
        IConsumer<EntityInserted<StateProvince>>,
        IConsumer<EntityUpdated<StateProvince>>,
        IConsumer<EntityDeleted<StateProvince>>
    {

        #region Cache keys 

        private readonly ICacheManager _cacheManager;

        #endregion

        #region Ctor

        public ModelCacheEventConsumer()
        {
            //TODO inject static cache manager using constructor
            this._cacheManager = EngineContext.Current.ContainerManager.Resolve<ICacheManager>("teromac_cache_static");
        }
        
        #endregion 

        #region Cache keys 
        /// <summary>
        /// Key for SpecificationAttributeOptionFilter caching
        /// </summary>
        /// <remarks>
        /// {0} : comma separated list of specification attribute option IDs
        /// {1} : language id
        /// </remarks>
        public const string SPECS_FILTER_MODEL_KEY = "Teromac.pres.filter.specs-{0}-{1}";
        public const string SPECS_FILTER_PATTERN_KEY = "Teromac.pres.filter.specs";
       
        /// <summary>
        /// Key for states by country id
        /// </summary>
        /// <remarks>
        /// {0} : country ID
        /// {1} : "empty" or "select" item
        /// {2} : language ID
        /// </remarks>
        public const string STATEPROVINCES_BY_COUNTRY_MODEL_KEY = "Teromac.pres.stateprovinces.bycountry-{0}-{1}-{2}";
        public const string STATEPROVINCES_PATTERN_KEY = "Teromac.pres.stateprovinces";

        /// <summary>
        /// Key for available languages
        /// </summary>
        /// <remarks>
        /// {0} : current store ID
        /// </remarks>
        public const string AVAILABLE_LANGUAGES_MODEL_KEY = "Teromac.pres.languages.all-{0}";
        public const string AVAILABLE_LANGUAGES_PATTERN_KEY = "Teromac.pres.languages";
        #endregion

        #region Methods

        //languages
        public void HandleEvent(EntityInserted<Language> eventMessage)
        {
            //clear all localizable models
            _cacheManager.RemoveByPattern(SPECS_FILTER_PATTERN_KEY);
            _cacheManager.RemoveByPattern(STATEPROVINCES_PATTERN_KEY);
            _cacheManager.RemoveByPattern(AVAILABLE_LANGUAGES_PATTERN_KEY);
        }
        public void HandleEvent(EntityUpdated<Language> eventMessage)
        {
            //clear all localizable models
            _cacheManager.RemoveByPattern(SPECS_FILTER_PATTERN_KEY);
            _cacheManager.RemoveByPattern(STATEPROVINCES_PATTERN_KEY);
            _cacheManager.RemoveByPattern(AVAILABLE_LANGUAGES_PATTERN_KEY);
        }
        public void HandleEvent(EntityDeleted<Language> eventMessage)
        {
            //clear all localizable models
            _cacheManager.RemoveByPattern(SPECS_FILTER_PATTERN_KEY);
            _cacheManager.RemoveByPattern(STATEPROVINCES_PATTERN_KEY);
            _cacheManager.RemoveByPattern(AVAILABLE_LANGUAGES_PATTERN_KEY);
        }

        public void HandleEvent(EntityUpdated<Setting> eventMessage)
        {
            //clear models which depend on settings
        }

        //State/province
        public void HandleEvent(EntityInserted<StateProvince> eventMessage)
        {
            _cacheManager.RemoveByPattern(STATEPROVINCES_PATTERN_KEY);
        }
        public void HandleEvent(EntityUpdated<StateProvince> eventMessage)
        {
            _cacheManager.RemoveByPattern(STATEPROVINCES_PATTERN_KEY);
        }
        public void HandleEvent(EntityDeleted<StateProvince> eventMessage)
        {
            _cacheManager.RemoveByPattern(STATEPROVINCES_PATTERN_KEY);
        }

        #endregion
    }
}
