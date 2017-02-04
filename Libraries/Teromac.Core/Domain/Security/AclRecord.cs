using Teromac.Core.Domain.Users;

namespace Teromac.Core.Domain.Security
{
    /// <summary>
    /// Represents an ACL record
    /// </summary>
    public partial class AclRecord : BaseEntity
    {
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        public int EntityId { get; set; }

        /// <summary>
        /// Gets or sets the entity name
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        /// Gets or sets the user role identifier
        /// </summary>
        public int UserRoleId { get; set; }

        /// <summary>
        /// Gets or sets the user role
        /// </summary>
        public virtual UserRole UserRole { get; set; }
    }
}
