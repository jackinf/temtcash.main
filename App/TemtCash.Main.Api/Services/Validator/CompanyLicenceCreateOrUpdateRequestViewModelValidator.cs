using FluentValidation;
using TemtCash.Main.Domain.Model;

namespace TemtCash.Main.Api.Services.Validator
{
    public class CompanyLicenceCreateOrUpdateRequestViewModelValidator : AbstractValidator<CompanyLicence>
    {
        public CompanyLicenceCreateOrUpdateRequestViewModelValidator()
        {
            RuleFor(x => x.CompanyId).NotNull().GreaterThan(0);
            RuleFor(x => x.LicenceKey).NotEmpty();
        }
    }
}