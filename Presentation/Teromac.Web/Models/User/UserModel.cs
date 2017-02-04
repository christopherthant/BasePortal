using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Teromac.Web.Framework;
using Teromac.Web.Framework.Mvc;

namespace Teromac.Web.Models.User
{
    //[Validator(typeof(UserValidator))]
    public partial class UserModel : BaseTeromacEntityModel
    {
        public UserModel()
        {

        }

        [AllowHtml]
        public string Username { get; set; }


        [AllowHtml]
        public string Email { get; set; }

        [AllowHtml]
        public string Password { get; set; }


        [AllowHtml]
        public string FirstName { get; set; }

        [AllowHtml]
        public string LastName { get; set; }

        
        [AllowHtml]
        public string Phone { get; set; }

        public bool Active { get; set; }

        //customer roles
        public string UserRoleNames { get; set; }
        public List<SelectListItem> AvailableUserRoles { get; set; }

        [UIHint("MultiSelect")]
        public IList<int> SelectedUserRoleIds { get; set; }

        #region Nested classes
        #endregion
    }
}