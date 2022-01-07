using DataAcces.Abstarct;
using DataAcces.Concrete.Context;
using Entity.Concrete;
using System.Linq;

namespace DataAcces.Concrete.EntityFramework
{
    public class EfVehicleRepository: EfRepostioryBase<Vehicle>,IVehicleRepository
    {
        private readonly ProjectContext _context;
        public EfVehicleRepository(ProjectContext context) : base(context) => _context = context;

        public override void Delete(int ID, bool save = true)
        {
            //Delete >> Container of Vehicle
            var efContainer = new EfContainerRepository(_context);

            //Get containers of vehicle
            var containers = efContainer.GetAll(x => x.VehicleID == ID);
            if(containers.Count() > 0)
            {
                containers.Select(i => i.ContainerID).ToList()
                .ForEach(x => efContainer.Delete(x, false)); //Container's save value must be false. Firstly , Vehicle must delete then container can delete.

            }

            //Delete Vehicle
            base.Delete(ID, save);
        }
    }
}
