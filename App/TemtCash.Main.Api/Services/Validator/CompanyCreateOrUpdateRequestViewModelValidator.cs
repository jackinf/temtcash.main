using FluentValidation;
using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.ViewModel.Services.Company.Requests;

namespace TemtCash.Main.Api.Services.Validator
{
    public class CompanyCreateOrUpdateRequestViewModelValidator : AbstractValidator<Company>
    {
        public CompanyCreateOrUpdateRequestViewModelValidator()
        {
            RuleFor(x => x.Name).NotNull().WithName(nameof(CompanyCreateOrUpdateRequestViewModel.CompanyName)).WithMessage(ErrorMessage.Required.Name);
            RuleFor(x => x.Status).NotNull().WithName(nameof(CompanyCreateOrUpdateRequestViewModel.State)).WithMessage(ErrorMessage.Required.Status);
        }

        public static class ErrorMessage
        {
            public static class Required
            {
                public const string Name = "Name is required";
                public const string Status = "Status is required";
            }
        }
    }
}