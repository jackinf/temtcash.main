using FluentValidation;
using TemtCash.Main.Domain.Model;

namespace TemtCash.Main.Api.Services.Validator
{
    public class CustomerCreateOrUpdateRequestViewModelValidator : AbstractValidator<Customer>
    {
        public CustomerCreateOrUpdateRequestViewModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.IsCompany).NotNull();
            RuleFor(x => x.CompanyId).NotNull();
        }
    }
}