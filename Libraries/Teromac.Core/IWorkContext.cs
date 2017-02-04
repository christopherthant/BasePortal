using Teromac.Core.Domain.Localization;
using Teromac.Core.Domain.Users;

namespace Teromac.Core
{
    /// <summary>
    /// Work context
    /// </summary>
    public interface IWorkContext
    {
        /// <summary>
        /// Gets or sets the current customer
        /// </summary>
        User CurrentUser { get; set; }
        /// <summary>
        /// Gets or sets the original customer (in case the current one is impersonated)
        /// </summary>
        User OriginalUserIfImpersonated { get; }
        /// <summary>
        /// Get or set current user working language
        /// </summary>
        Language WorkingLanguage { get; set; }
        /// <summary>
        /// Get or set value indicating whether we're in admin area
        /// </summary>
        bool IsAdmin { get; set; }
    }
}
