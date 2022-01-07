using DataAcces.Abstarct;
using DataAcces.Concrete.Context;
using Entity.Concrete;


namespace DataAcces.Concrete.Dapper
{
    public class DapContainerRepository: DapRepostioryBase<Container>, IContainerRepository
    {
        private readonly ProjectContext _context;
        public DapContainerRepository(ProjectContext context) : base(context) => _context = context;
    }
}
