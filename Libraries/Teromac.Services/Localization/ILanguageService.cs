using System.Collections.Generic;
using Teromac.Core.Domain.Localization;

namespace Teromac.Services.Localization
{
    /// <summary>
    /// Language service interface
    /// </summary>
    public partial interface ILanguageService
    {
        /// <summary>
        /// Deletes a language
        /// </summary>
        /// <param name="language">Language</param>
        void DeleteLanguage(Language language);

        /// <summary>
        /// Gets all languages
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Languages</returns>
        IList<Language> GetAllLanguages(bool showHidden = false);

        /// <summary>
        /// Gets a language
        /// </summary>
        /// <param name="languageId">Language identifier</param>
        /// <returns>Language</returns>
        Language GetLanguageById(int languageId);

        /// <summary>
        /// Inserts a language
        /// </summary>
        /// <param name="language">Language</param>
        void InsertLanguage(Language language);

        /// <summary>
        /// Updates a language
        /// </summary>
        /// <param name="language">Language</param>
        void UpdateLanguage(Language language);
    }
}
