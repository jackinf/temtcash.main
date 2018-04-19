using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using SpeysCloud.Main.Domain.ViewModel.Services.Dashboard;

namespace SpeysCloud.Main.Domain.Services
{
    public interface IDashboardService
    {
        Task<ServiceResult<List<RecentDeliveriesResponseViewModel>>> GetRecentDeliveries(RecentDeliveriesRequestViewModel viewModel);
        Task<ServiceResult<FrequentContactsResponseViewModel>> GetFrequentContacts();
    }
}