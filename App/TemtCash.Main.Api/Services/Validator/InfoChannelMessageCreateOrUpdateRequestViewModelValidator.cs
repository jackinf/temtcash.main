using FluentValidation;
using TemtCash.Main.Domain.Model;

namespace TemtCash.Main.Api.Services.Validator
{
    public class InfoChannelMessageCreateOrUpdateRequestViewModelValidator : AbstractValidator<InfoChannelMessage>
    {
        public InfoChannelMessageCreateOrUpdateRequestViewModelValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Message).NotEmpty();
            RuleFor(x => x.Status).NotEmpty();
        }
    }
}