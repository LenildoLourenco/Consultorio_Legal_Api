using System.Collections.Generic;
using System.Threading.Tasks;
using CL.Core.Domain;

namespace CL.Manager.Interfaces.Repositories
{
    public interface IMedicoRepository
    {
        Task<IEnumerable<Medico>> GetMedicosAsync();

        Task<Medico> GetMedicoAsync(int id);

        Task<Medico> InsertMedicoAsync(Medico medico);

        Task<Medico> UpdateMedicoAsync(Medico medico);

        Task DeleteMedicoAsync(int id);
    }
}
