using System;
using FluentValidation;
using TemtCash.Main.Domain.Model;

namespace TemtCash.Main.Api.Services.Validator
{
    public class ProductCreateOrUpdateRequestViewModelValidator : AbstractValidator<Product>
    {
        public ProductCreateOrUpdateRequestViewModelValidator()
        {
            throw new NotImplementedException();
        }
    }
}