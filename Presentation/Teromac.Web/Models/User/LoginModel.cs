using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Teromac.Web.Framework;
using Teromac.Web.Framework.Mvc;
using Teromac.Web.Validators.User;

namespace Teromac.Web.Models.User
{
    [Validator(typeof(LoginValidator))]
    public partial class LoginModel : BaseTeromacModel
    {
        [AllowHtml]
        public string Email { get; set; }

        [TeromacResourceDisplayName("User.Fields.Username")]
        [AllowHtml]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [NoTrim]
        [TeromacResourceDisplayName("User.Fields.Password")]
        [AllowHtml]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public bool DisplayCaptcha { get; set; }
    }
}