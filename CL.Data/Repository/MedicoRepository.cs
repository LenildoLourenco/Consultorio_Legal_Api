using System.Collections.Generic;
using System.Threading.Tasks;
using CL.Core.Domain;
using CL.Data.Context;
using CL.Manager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CL.Data.Repository
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly ClContext _context;

        public MedicoRepository(ClContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Medico>> GetMedicosAsync()
        {
            return await _context.Medicos
              .Include(p => p.Especialidades)
              .AsNoTracking().ToListAsync();
        }

        public async Task<Medico> GetMedicoAsync(int id)
        {
            return await _context.Medicos
                .Include(p => p.Especialidades)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Medico> InsertMedicoAsync(Medico medico)
        {
            await InsertMedicoEspecilidades(medico);
            await _context.Medicos.AddAsync(medico);
            await _context.SaveChangesAsync();
            return medico;
        }

        private async Task InsertMedicoEspecilidades(Medico medico)
        {
            foreach (var especialidade in medico.Especialidades)
            {
                var especialidadeConsultada = await _context.Especialidades.AsNoTracking().FirstAsync(p => p.Id == especialidade.Id);
                _context.Entry(especialidade).CurrentValues.SetValues(especialidadeConsultada);
            }
        }

        public async Task<Medico> UpdateMedicoAsync(Medico medico)
        {
            var medicoConsultado = await _context.Medicos
                                        .Include(p => p.Especialidades)
                                        .SingleOrDefaultAsync(p => p.Id == medico.Id);
            if (medicoConsultado == null)
            {
                return null;
            }
            _context.Entry(medicoConsultado).CurrentValues.SetValues(medico);
            await UpdateMedicoEspecialidades(medico, medicoConsultado);
            await _context.SaveChangesAsync();
            return medicoConsultado;
        }

        private async Task UpdateMedicoEspecialidades(Medico medico, Medico medicoConsultado)
        {
            medicoConsultado.Especialidades.Clear();
            foreach (var especialidade in medico.Especialidades)
            {
                var especialidadeConsultada = await _context.Especialidades.FindAsync(especialidade.Id);
                medicoConsultado.Especialidades.Add(especialidadeConsultada);
            }
        }

        public async Task DeleteMedicoAsync(int id)
        {
            var medicoConsultado = await _context.Medicos.FindAsync(id);
            _context.Medicos.Remove(medicoConsultado);
            await _context.SaveChangesAsync();
        }
    }
}
