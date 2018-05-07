using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.ViewModel.Services.ProductCatalog.Response;

namespace TemtCash.Main.Domain.ViewModel.Services.ProductCatalog.Request
{
    public class ProductsRequestViewModel : SearchBaseOptionsViewModel
    {
        public static class OrderFields
        {
            public static string ProductName = nameof(ProductsResponseViewModel.ProductName);
            public static string Code = nameof(ProductsResponseViewModel.Code);
            public static string EanCode = nameof(ProductsResponseViewModel.EanCode);
            public static string SellPriceBruto = nameof(ProductsResponseViewModel.SellPriceBruto);
            public static string Type = nameof(ProductsResponseViewModel.Type);
            public static string ProductGroup = nameof(ProductsResponseViewModel.ProductGroup);
        }
    }
}