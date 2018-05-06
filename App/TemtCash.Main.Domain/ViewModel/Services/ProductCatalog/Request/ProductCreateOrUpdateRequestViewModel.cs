namespace TemtCash.Main.Domain.ViewModel.Services.ProductCatalog.Request
{
    public class ProductCreateOrUpdateRequestViewModel
    {
        public string ProductName { get; set; }
        public string Code { get; set; }
        public string EanCode { get; set; }
        public int? ProductGroupId { get; set; }
        public string Description { get; set; }
        public float SellingPriceBruto { get; set; }
        public string VatPercent { get; set; }
        public string Type { get; set; }
        public int? Unit { get; set; }
        public bool? UseProductVat { get; set; }
    }
}