using AutoFixture.Dsl;
using SpeysCloud.Main.DAL.Model;

namespace SpeysCloud.Main.IntegrationTests.Utils
{
    public static class BuilderUtils
    {
        public static IPostprocessComposer<T> WithoutBaseProperties<T>(this IPostprocessComposer<T> builder) where T: BaseModel<int>
        {
            return builder
                .Without(x => x.Id)
                .Without(x => x.CreatedBy)
                .Without(x => x.CreatedOn)
                .Without(x => x.UpdatedOn)
                .Without(x => x.UpdatedBy)
                .Without(x => x.DeletedOn)
                .Without(x => x.DeletedBy);
        }
    }
}