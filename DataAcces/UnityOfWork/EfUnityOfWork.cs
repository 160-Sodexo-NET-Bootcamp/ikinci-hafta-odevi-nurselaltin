using DataAcces.Abstarct;
using DataAcces.Concrete.Context;
using DataAcces.Concrete.EntityFramework;


namespace DataAccess.UnityOfWork
{
    public class EfUnityOfWork : IUnityOfWork
    {
        private ProjectContext _context;

        public EfUnityOfWork(ProjectContext context)
        {
            _context = context;
            VehicleRepository = new EfVehicleRepository(_context);
            ContainerRepository = new EfContainerRepository(_context);
        }

        public IVehicleRepository VehicleRepository { get ;  set ; }
        public IContainerRepository ContainerRepository { get ; set ; }
    }
}
