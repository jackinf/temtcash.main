namespace TemtCash.Main.Domain.ViewModel.Services.ProductCatalog.Response
{
    public class ProductsResponseViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Code { get; set; }
        public string EanCode { get; set; }
        public float? SellPriceBruto { get; set; }
        public string Type { get; set; }
        public string ProductGroup { get; set; }
    }
}