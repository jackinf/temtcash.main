using FluentValidation;
using TemtCash.Main.Domain.ViewModel.Services.Company;
using TemtCash.Main.Domain.ViewModel.Services.Company.Requests;

namespace TemtCash.Main.Api.Services.Validator
{
    public class CompanyCreateOrUpdateRequestViewModelValidator : AbstractValidator<CompanyCreateOrUpdateRequestViewModel>
    {
        public CompanyCreateOrUpdateRequestViewModelValidator()
        {
            //RuleFor(x => x.Country).NotNull().WithMessage(ErrorMessage.Required.Country);
            //RuleFor(x => x.PostalCode).NotEmpty().WithMessage(ErrorMessage.Required.PostalCode);
            //RuleFor(x => x.City).NotEmpty().WithMessage(ErrorMessage.Required.City);
            //RuleFor(x => x.AddressLine1).NotEmpty().WithMessage(ErrorMessage.Required.AddressLine1);
            //RuleFor(x => x.Company).NotEmpty().WithMessage(ErrorMessage.Required.Company);
            //RuleFor(x => x.ContactName).NotEmpty().WithMessage(ErrorMessage.Required.ContactName);
            //RuleFor(x => x.ContactPhoneNumber).NotEmpty().WithMessage(ErrorMessage.Required.ContactPhoneNumber);
        }

        public static class ErrorMessage
        {
            public static class Required
            {
                //public const string Country = "Country is required";
                //public const string PostalCode = "PostalCode is required";
                //public const string City = "City is required";
                //public const string AddressLine1 = "AddressLine1 is required";
                //public const string Company = "Company is required";
                //public const string ContactName = "ContactName is required";
                //public const string ContactPhoneNumber = "ContactPhoneNumber is required";
            }
        }
    }
}