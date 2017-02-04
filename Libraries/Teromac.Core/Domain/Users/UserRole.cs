using System.Collections.Generic;
using Teromac.Core.Domain.Security;

namespace Teromac.Core.Domain.Users
{
    /// <summary>
    /// Represents a customer role
    /// </summary>
    public partial class UserRole : BaseEntity
    {
        private ICollection<PermissionRecord> _permissionRecords;

        /// <summary>
        /// Gets or sets the customer role name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer role is active
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer role is system
        /// </summary>
        public bool IsSystemRole { get; set; }

        /// <summary>
        /// Gets or sets the customer role system name
        /// </summary>
        public string SystemName { get; set; }
       
        /// <summary>
        /// Gets or sets the permission records
        /// </summary>
        public virtual ICollection<PermissionRecord> PermissionRecords
        {
            get { return _permissionRecords ?? (_permissionRecords = new List<PermissionRecord>()); }
            protected set { _permissionRecords = value; }
        }
    }

}