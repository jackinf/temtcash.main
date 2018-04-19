using System.Collections.Generic;
using FluentValidation.Results;
using Newtonsoft.Json;
using SpeysCloud.Core.Result;

namespace TemtCash.Main.IntegrationTests.Utils
{
    public class TestServiceResult<T> : ServiceResult<T>
    {
        [JsonProperty("validation")]
        public TestValidationResult TestValidation { get; set; }
    }

    public class TestValidationResult : ValidationResult
    {
        [JsonProperty("errors")]
        public new IList<TestValidationFailure> Errors { get; set; } = new List<TestValidationFailure>();
    }

    public class TestValidationFailure
    {
        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }

        [JsonProperty("propertyName")]
        public string PropertyName { get; set; }
    }
}