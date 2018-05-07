using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.ViewModel.Services.ProductCatalog.Response;

namespace TemtCash.Main.Domain.ViewModel.Services.ProductCatalog.Request
{
    public class ProductGroupsRequestViewModel : SearchBaseOptionsViewModel
    {
        public static class OrderFields
        {
            public static string Name = nameof(ProductGroupsResponseViewModel.Name);
            public static string KmPercent = nameof(ProductGroupsResponseViewModel.KmPercent);
        }
    }
}