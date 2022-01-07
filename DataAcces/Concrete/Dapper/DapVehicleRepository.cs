using DataAcces.Abstarct;
using DataAcces.Concrete.Context;
using Entity.Concrete;

namespace DataAcces.Concrete.Dapper
{
    public class DapVehicleRepository: DapRepostioryBase<Vehicle>, IVehicleRepository
    {
        private readonly ProjectContext _context;
        public DapVehicleRepository(ProjectContext context) : base(context) => _context = context;
    }
}
