using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CL.Core.Domain;
using CL.Core.Shared.ModelViews.Medico;
using CL.Manager.Interfaces.Managers;
using CL.Manager.Interfaces.Repositories;

namespace CL.Manager.Implementation
{
    public class MedicoManager : IMedicoManager
    {
        private readonly IMedicoRepository _repository;
        private readonly IMapper _mapper;

        public MedicoManager(IMedicoRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<MedicoView>> GetMedicosAsync()
        {
            return _mapper.Map<IEnumerable<Medico>, IEnumerable<MedicoView>>(await _repository.GetMedicosAsync());
        }

        public async Task<MedicoView> GetMedicoAsync(int id)
        {
            return _mapper.Map<MedicoView>(await _repository.GetMedicoAsync(id));
        }

        public async Task<MedicoView> InsertMedicoAsync(NovoMedico novoMedico)
        {
            var medico = _mapper.Map<Medico>(novoMedico);
            return _mapper.Map<MedicoView>(await _repository.InsertMedicoAsync(medico));
        }

        public async Task<MedicoView> UpdateMedicoAsync(AlteraMedico alteraMedico)
        {
            var medico = _mapper.Map<Medico>(alteraMedico);
            return _mapper.Map<MedicoView>(await _repository.UpdateMedicoAsync(medico));
        }

        public async Task DeleteMedicoAsync(int id)
        {
            await _repository.DeleteMedicoAsync(id);
        }
    }
}
