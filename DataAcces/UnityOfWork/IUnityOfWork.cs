using DataAcces.Abstarct;

namespace DataAccess.UnityOfWork
{
    public interface IUnityOfWork
    {
        public IVehicleRepository VehicleRepository { get;  set; }
        public IContainerRepository ContainerRepository { get; set; }
    }
}
