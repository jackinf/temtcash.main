namespace SpeysCloud.Main.Domain.ViewModel.Services.Shipment
{
    /// <summary>
    /// In this case, <see cref="ShipmentCreateOrUpdateRequestViewModel"/> shares all the same
    /// properties as <see cref="ShipmentResponseViewModel"/> because before opening create model
    /// in frontend, the request is sent to get all single delivery response.
    /// 
    /// To update, the same view model is used, but view model is named differently to reflect purpose better.
    /// </summary>
    public class ShipmentCreateOrUpdateRequestViewModel : ShipmentResponseViewModel
    {
    }
}