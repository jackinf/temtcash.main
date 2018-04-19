using FluentValidation;
using SpeysCloud.Main.Domain.ViewModel.Services.Shipment;

namespace SpeysCloud.Main.Services.Validator
{
    public class ShipmentCreateOrUpdateRequestViewModelValidator : AbstractValidator<ShipmentCreateOrUpdateRequestViewModel>
    {
        public ShipmentCreateOrUpdateRequestViewModelValidator()
        {
            RuleFor(x => x.Number).NotEmpty().WithMessage(ErrorMessage.Required.Number);
            RuleFor(x => x.TransportCompany).NotEmpty().WithMessage(ErrorMessage.Required.Company);
            RuleFor(x => x.Status).NotEmpty().WithMessage(ErrorMessage.Required.Status);
            RuleFor(x => x.TotalEur).NotNull().WithMessage(ErrorMessage.Required.Total);
            RuleFor(x => x.TotalEur).GreaterThan(0m).WithMessage(ErrorMessage.GreaterThan.Total);

            RuleFor(x => x.Sender.Country).NotEmpty().WithMessage(ErrorMessage.Required.SenderCountry).When(x => x.Sender != null);
            RuleFor(x => x.Sender.PostCode).NotEmpty().WithMessage(ErrorMessage.Required.SenderPostCode).When(x => x.Sender != null);
            RuleFor(x => x.Sender.City).NotEmpty().WithMessage(ErrorMessage.Required.SenderCity).When(x => x.Sender != null);
            RuleFor(x => x.Sender.AddressLine1).NotEmpty().WithMessage(ErrorMessage.Required.SenderAddressLine1).When(x => x.Sender != null);
            RuleFor(x => x.Sender.CompanyName).NotEmpty().WithMessage(ErrorMessage.Required.SenderCompanyName).When(x => x.Sender != null);
            RuleFor(x => x.Sender.ContactPersonName).NotEmpty().WithMessage(ErrorMessage.Required.SenderContactPersonName).When(x => x.Sender != null);
            RuleFor(x => x.Sender.Phone).NotEmpty().WithMessage(ErrorMessage.Required.SenderPhone).When(x => x.Sender != null);

            RuleFor(x => x.SenderAlternative.Country).NotEmpty().WithMessage(ErrorMessage.Required.SenderAlternativeCountry).When(x => x.SenderAlternative != null && x.UseSenderAlternative == true);
            RuleFor(x => x.SenderAlternative.PostCode).NotEmpty().WithMessage(ErrorMessage.Required.SenderAlternativePostCode).When(x => x.SenderAlternative != null && x.UseSenderAlternative == true);
            RuleFor(x => x.SenderAlternative.City).NotEmpty().WithMessage(ErrorMessage.Required.SenderAlternativeCity).When(x => x.SenderAlternative != null && x.UseSenderAlternative == true);
            RuleFor(x => x.SenderAlternative.AddressLine1).NotEmpty().WithMessage(ErrorMessage.Required.SenderAlternativeAddressLine1).When(x => x.SenderAlternative != null && x.UseSenderAlternative == true);
            RuleFor(x => x.SenderAlternative.CompanyName).NotEmpty().WithMessage(ErrorMessage.Required.SenderAlternativeCompanyName).When(x => x.SenderAlternative != null && x.UseSenderAlternative == true);
            RuleFor(x => x.SenderAlternative.ContactPersonName).NotEmpty().WithMessage(ErrorMessage.Required.SenderAlternativeContactPersonName).When(x => x.SenderAlternative != null && x.UseSenderAlternative == true);
            RuleFor(x => x.SenderAlternative.Phone).NotEmpty().WithMessage(ErrorMessage.Required.SenderAlternativePhone).When(x => x.SenderAlternative != null && x.UseSenderAlternative == true);

            RuleFor(x => x.Receiver.Country).NotEmpty().WithMessage(ErrorMessage.Required.ReceiverCountry).When(x => x.Receiver != null);
            RuleFor(x => x.Receiver.PostCode).NotEmpty().WithMessage(ErrorMessage.Required.ReceiverPostCode).When(x => x.Receiver != null);
            RuleFor(x => x.Receiver.City).NotEmpty().WithMessage(ErrorMessage.Required.ReceiverCity).When(x => x.Receiver != null);
            RuleFor(x => x.Receiver.AddressLine1).NotEmpty().WithMessage(ErrorMessage.Required.ReceiverAddressLine1).When(x => x.Receiver != null);
            RuleFor(x => x.Receiver.CompanyName).NotEmpty().WithMessage(ErrorMessage.Required.ReceiverCompanyName).When(x => x.Receiver != null);
            RuleFor(x => x.Receiver.ContactPersonName).NotEmpty().WithMessage(ErrorMessage.Required.ReceiverContactPersonName).When(x => x.Receiver != null);
            RuleFor(x => x.Receiver.Phone).NotEmpty().WithMessage(ErrorMessage.Required.ReceiverPhone).When(x => x.Receiver != null);

            RuleFor(x => x.ReceiverAlternative.Country).NotEmpty().WithMessage(ErrorMessage.Required.ReceiverAlternativeCountry).When(x => x.ReceiverAlternative != null && x.UseReceiverAlternative == true);
            RuleFor(x => x.ReceiverAlternative.PostCode).NotEmpty().WithMessage(ErrorMessage.Required.ReceiverAlternativePostCode).When(x => x.ReceiverAlternative != null && x.UseReceiverAlternative == true);
            RuleFor(x => x.ReceiverAlternative.City).NotEmpty().WithMessage(ErrorMessage.Required.ReceiverAlternativeCity).When(x => x.ReceiverAlternative != null && x.UseReceiverAlternative == true);
            RuleFor(x => x.ReceiverAlternative.AddressLine1).NotEmpty().WithMessage(ErrorMessage.Required.ReceiverAlternativeAddressLine1).When(x => x.ReceiverAlternative != null && x.UseReceiverAlternative == true);
            RuleFor(x => x.ReceiverAlternative.CompanyName).NotEmpty().WithMessage(ErrorMessage.Required.ReceiverAlternativeCompanyName).When(x => x.ReceiverAlternative != null && x.UseReceiverAlternative == true);
            RuleFor(x => x.ReceiverAlternative.ContactPersonName).NotEmpty().WithMessage(ErrorMessage.Required.ReceiverAlternativeContactPersonName).When(x => x.ReceiverAlternative != null && x.UseReceiverAlternative == true);
            RuleFor(x => x.ReceiverAlternative.Phone).NotEmpty().WithMessage(ErrorMessage.Required.ReceiverAlternativePhone).When(x => x.ReceiverAlternative != null && x.UseReceiverAlternative == true);
        }

        public static class ErrorMessage
        {
            public static class Required
            {
                public const string Number = "Number is required";
                public const string Company = "Company is required";
                public const string Status = "Status is required";
                public const string Total = "Total is required";

                public const string SenderCountry = "Sender's country is required";
                public const string SenderPostCode = "Sender's post code is required";
                public const string SenderCity = "Sender's city is required";
                public const string SenderAddressLine1 = "Sender's address line 1 is required";
                public const string SenderCompanyName = "Sender's company name is required";
                public const string SenderContactPersonName = "Sender's contact person name is required";
                public const string SenderPhone = "Sender's phone is required";

                public const string SenderAlternativeCountry = "Alternative sender's country is required";
                public const string SenderAlternativePostCode = "Alternative sender's post code is required";
                public const string SenderAlternativeCity = "Alternative sender's city is required";
                public const string SenderAlternativeAddressLine1 = "Alternative sender's address line 1 is required";
                public const string SenderAlternativeCompanyName = "Alternative sender's company name is required";
                public const string SenderAlternativeContactPersonName = "Alternative sender's contact person name is required";
                public const string SenderAlternativePhone = "Alternative sender's phone is required";

                public const string ReceiverCountry = "Receiver's country is required";
                public const string ReceiverPostCode = "Receiver's post code is required";
                public const string ReceiverCity = "Receiver's city is required";
                public const string ReceiverAddressLine1 = "Receiver's address line 1 is required";
                public const string ReceiverCompanyName = "Receiver's company name is required";
                public const string ReceiverContactPersonName = "Receiver's contact person name is required";
                public const string ReceiverPhone = "Receiver's phone is required";

                public const string ReceiverAlternativeCountry = "Alternative receiver's country is required";
                public const string ReceiverAlternativePostCode = "Alternative receiver's post code is required";
                public const string ReceiverAlternativeCity = "Alternative receiver's city is required";
                public const string ReceiverAlternativeAddressLine1 = "Alternative receiver's address line 1 is required";
                public const string ReceiverAlternativeCompanyName = "Alternative receiver's company name is required";
                public const string ReceiverAlternativeContactPersonName = "Alternative receiver's contact person name is required";
                public const string ReceiverAlternativePhone = "Alternative receiver's phone is required";
            }

            public static class GreaterThan
            {
                public const string Total = "Total should be greater than zero";
            }
        }
    }
}