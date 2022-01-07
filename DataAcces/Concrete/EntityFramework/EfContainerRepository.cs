using DataAcces.Abstarct;
using DataAcces.Concrete.Context;
using Entity.Concrete;


namespace DataAcces.Concrete.EntityFramework
{
    public class EfContainerRepository: EfRepostioryBase<Container>,IContainerRepository
    {
        private readonly ProjectContext _context;
        public EfContainerRepository(ProjectContext context) : base(context) => _context = context;
    }
}
