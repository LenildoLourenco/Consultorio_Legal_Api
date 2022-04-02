using System.Threading.Tasks;
using CL.Data.Context;
using CL.Manager.Interfaces.Repositories;

namespace CL.Data.Repository
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly ClContext _context;
        public EspecialidadeRepository(ClContext context)
        {
            this._context = context;
        }

        public async Task<bool> ExisteAsync(int id)
        {
            return await _context.Especialidades.FindAsync(id) != null;
        }
    }
}
