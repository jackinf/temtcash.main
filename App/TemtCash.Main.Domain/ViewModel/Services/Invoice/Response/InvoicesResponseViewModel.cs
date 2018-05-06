using System;

namespace TemtCash.Main.Domain.ViewModel.Services.Invoice.Response
{
    public class InvoicesResponseViewModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime? Date { get; set; }
        public float? SumWithoutKm { get; set; }
        public float? SumKm { get; set; }
        public float? SumBruto { get; set; }
        public string Client { get; set; }
        public string PaymentMethod { get; set; }
        public string Seller { get; set; }
    }
}