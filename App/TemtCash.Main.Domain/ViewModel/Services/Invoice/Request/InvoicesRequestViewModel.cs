using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.ViewModel.Services.Invoice.Response;

namespace TemtCash.Main.Domain.ViewModel.Services.Invoice.Request
{
    public class InvoicesRequestViewModel : SearchBaseOptionsViewModel
    {
        public static class OrderFields
        {
            public static string Number = nameof(InvoicesResponseViewModel.Number).ToUpperInvariant();
            public static string Date = nameof(InvoicesResponseViewModel.Date).ToUpperInvariant();
            public static string SumWithoutKm = nameof(InvoicesResponseViewModel.SumWithoutKm).ToUpperInvariant();
            public static string SumKm = nameof(InvoicesResponseViewModel.SumKm).ToUpperInvariant();
            public static string SumBruto = nameof(InvoicesResponseViewModel.SumBruto).ToUpperInvariant();
            public static string Client = nameof(InvoicesResponseViewModel.Client).ToUpperInvariant();
            public static string PaymentMethod = nameof(InvoicesResponseViewModel.PaymentMethod).ToUpperInvariant();
            public static string Seller = nameof(InvoicesResponseViewModel.Seller).ToUpperInvariant();
        }
    }
}