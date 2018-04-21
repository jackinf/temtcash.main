using TemtCash.Main.IntegrationTests.Utils;
using Xunit;

namespace TemtCash.Main.IntegrationTests.Features
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
                context.Companies.RemoveRange(context.Companies);
                context.CompanyLicences.RemoveRange(context.CompanyLicences);
                context.Customers.RemoveRange(context.Customers);
                context.InfoChannelMessages.RemoveRange(context.InfoChannelMessages);
                context.SaveChanges();
            });
        }
    }
}