using SpeysCloud.Main.Domain.Model;

namespace SpeysCloud.Main.DAL.Model
{
    public class ShipmentDetail : BaseModel<int>
    {
        public float? Length { get; set; }
        public float? Width { get; set; }
        public float? Height { get; set; }
        public float? Weight { get; set; }
        public string ProductDescription { get; set; }
        public string ProductAdditionalInfo { get; set; }
        public bool? DangerousGoods { get; set; }

        //
        // One-2-Many and Many-2-One references
        //

        public int? ShipmentId { get; set; }
        public Shipment Shipment { get; set; }

        public int? QuantityId { get; set; }
        public int? TypeId { get; set; }
    }
}