using SpeysCloud.Main.DAL.Repository;

namespace SpeysCloud.Main.DAL.UnitOfWork
{
    public class AddressAndShipmentUnitOfWork : BaseUnitOfWork
    {
        public AddressAndShipmentUnitOfWork(ApplicationDbContext context) : base(context)
        {
            ShipmentRepository = new ShipmentRepository(context);
            AddressRepository = new AddressRepository(context);
        }

        public ShipmentRepository ShipmentRepository { get; }
        public AddressRepository AddressRepository { get; }
    }
}