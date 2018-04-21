using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.ViewModel.Services.InfoChannelMessage.Response;

namespace TemtCash.Main.Domain.ViewModel.Services.InfoChannelMessage.Request
{
    public class InfoChannelMessagesRequestViewModel : PaginatedSearchBaseOptionsResult
    {
        public class OrderFields
        {
            public static string Subject = nameof(InfoChannelMessagesResponseViewModel.Subject).ToUpperInvariant();
            public static string Message = nameof(InfoChannelMessagesResponseViewModel.Message).ToUpperInvariant();
            public static string Date = nameof(InfoChannelMessagesResponseViewModel.Date).ToUpperInvariant();
            public static string IsVisible = nameof(InfoChannelMessagesResponseViewModel.IsVisible).ToUpperInvariant();
        }
    }
}