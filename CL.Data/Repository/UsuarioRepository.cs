using System.Collections.Generic;
using System.Threading.Tasks;
using CL.Core.Domain;
using CL.Data.Context;
using CL.Manager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CL.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ClContext _context;

        public UsuarioRepository(ClContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Usuario>> GetAsync()
        {
            return await _context.Usuarios.AsNoTracking().ToListAsync();
        }

        public async Task<Usuario> GetAsync(string login)
        {
            return await _context.Usuarios
                .Include(p => p.Funcoes)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.Login == login);
        }

        public async Task<Usuario> InsertAsync(Usuario usuario)
        {
            await InsertUsuarioFuncaoAsync(usuario);
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        private async Task InsertUsuarioFuncaoAsync(Usuario usuario)
        {
            var funcoesConsultas = new List<Funcao>();
            foreach (var funcao in usuario.Funcoes)
            {
                var funcaoConsultada = await _context.Funcoes.FindAsync(funcao.Id);
                funcoesConsultas.Add(funcaoConsultada);
            }
            usuario.Funcoes = funcoesConsultas;
        }
       
        public async Task<Usuario> UpdateAsync(Usuario usuario)
        {
            var usuarioConsultado = await _context.Usuarios.FindAsync(usuario.Login);
            if (usuarioConsultado == null)
            {
                return null;
            }
            _context.Entry(usuarioConsultado).CurrentValues.SetValues(usuario);
            await _context.SaveChangesAsync();
            return usuarioConsultado;
        }
    }
}
