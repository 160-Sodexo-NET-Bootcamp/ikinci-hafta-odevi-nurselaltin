using DataAcces.Abstarct;
using DataAcces.Concrete.Context;
using DataAcces.Concrete.Dapper;
using DataAcces.Concrete.EntityFramework;


namespace DataAccess.UnityOfWork
{
    public class DapUnityOfWork : IUnityOfWork
    {
        private ProjectContext _context;

        public DapUnityOfWork(ProjectContext context)
        {
            _context = context;
            VehicleRepository = new DapVehicleRepository(_context);
            ContainerRepository = new DapContainerRepository(_context);
        }

        public IVehicleRepository VehicleRepository { get ;  set ; }
        public IContainerRepository ContainerRepository { get ; set ; }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
