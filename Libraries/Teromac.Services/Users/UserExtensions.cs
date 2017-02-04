using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using Teromac.Core;
using Teromac.Core.Domain.Users;
using Teromac.Core.Infrastructure;
using Teromac.Services.Common;

namespace Teromac.Services.Users
{
    public static class UserExtensions
    {
        /// <summary>
        /// Get full name
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>User full name</returns>
        public static string GetFullName(this User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            var firstName = user.GetAttribute<string>(SystemUserAttributeNames.FirstName);
            var lastName = user.GetAttribute<string>(SystemUserAttributeNames.LastName);

            string fullName = "";
            if (!String.IsNullOrWhiteSpace(firstName) && !String.IsNullOrWhiteSpace(lastName))
                fullName = string.Format("{0} {1}", firstName, lastName);
            else
            {
                if (!String.IsNullOrWhiteSpace(firstName))
                    fullName = firstName;

                if (!String.IsNullOrWhiteSpace(lastName))
                    fullName = lastName;
            }
            return fullName;
        }
        
        /// <summary>
        /// Check whether password recovery token is valid
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="token">Token to validate</param>
        /// <returns>Result</returns>
        public static bool IsPasswordRecoveryTokenValid(this User user, string token)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            var cPrt = user.GetAttribute<string>(SystemUserAttributeNames.PasswordRecoveryToken);
            if (String.IsNullOrEmpty(cPrt))
                return false;

            if (!cPrt.Equals(token, StringComparison.InvariantCultureIgnoreCase))
                return false;

            return true;
        }
        /// <summary>
        /// Check whether password recovery link is expired
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="userSettings">User settings</param>
        /// <returns>Result</returns>
        public static bool IsPasswordRecoveryLinkExpired(this User user, UserSettings userSettings)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            if (userSettings == null)
                throw new ArgumentNullException("userSettings");

            //if (userSettings.PasswordRecoveryLinkDaysValid == 0)
            //    return false;
            
            var geneatedDate = user.GetAttribute<DateTime?>(SystemUserAttributeNames.PasswordRecoveryTokenDateGenerated);
            if (!geneatedDate.HasValue)
                return false;

            //var daysPassed = (DateTime.UtcNow - geneatedDate.Value).TotalDays;
            //if (daysPassed > userSettings.PasswordRecoveryLinkDaysValid)
            //    return true;

            return false;
        }

        /// <summary>
        /// Get user role identifiers
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="showHidden">A value indicating whether to load hidden records</param>
        /// <returns>User role identifiers</returns>
        public static int[] GetUserRoleIds(this User user, bool showHidden = false)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            var userRolesIds = user.UserRoles
               .Where(cr => showHidden || cr.Active)
               .Select(cr => cr.Id)
               .ToArray();

            return userRolesIds;
        }
    }
}
