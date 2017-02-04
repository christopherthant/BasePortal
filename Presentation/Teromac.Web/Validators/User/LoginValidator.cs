using FluentValidation;
using Teromac.Core.Domain.Users;
using Teromac.Services.Localization;
using Teromac.Web.Framework.Validators;
using Teromac.Web.Models.User;

namespace Teromac.Web.Validators.User
{
    public partial class LoginValidator : BaseTeromacValidator<LoginModel>
    {
        public LoginValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage(localizationService.GetResource("Account.Login.Fields.Username.Required"));
            RuleFor(x => x.Password).NotEmpty().WithMessage(localizationService.GetResource("Account.Login.Fields.Password.Required"));
            //RuleFor(x => x.Email).EmailAddress().WithMessage(localizationService.GetResource("Common.WrongEmail"));
        }
    }
}