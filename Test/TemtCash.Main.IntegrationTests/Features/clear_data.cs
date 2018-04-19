using SpeysCloud.Main.IntegrationTests.Utils;
using Xunit;

namespace SpeysCloud.Main.IntegrationTests.Features
{
    ///<summary>
    /// Collection("Database Tests") avoids running tests in parallel. 
    /// We don't want to run tests in parallel because in the preparation step we clear database.
    ///</summary>
    [Collection("Database Tests")]
    public abstract class clear_data
    {
        protected clear_data()
        {
            ApiServerFixture.Current.DoDatabaseOperation(context =>
            {
                context.ShipmentDetails.RemoveRange(context.ShipmentDetails);
                context.Shipments.RemoveRange(context.Shipments);
                context.Addresses.RemoveRange(context.Addresses);
                context.SaveChanges();
            });
        }
    }
}