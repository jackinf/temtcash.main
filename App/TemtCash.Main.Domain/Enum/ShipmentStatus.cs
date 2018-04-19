using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SpeysCloud.Main.Domain.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ShipmentStatus
    {
        NotSelected = 0,
        
        Collecting = 10,

        Processing = 20,

        InTransit = 30,

        Delivering = 40
    }
}