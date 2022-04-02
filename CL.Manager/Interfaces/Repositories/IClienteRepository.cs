﻿using System.Collections.Generic;
using System.Threading.Tasks;
using CL.Core.Domain;

namespace CL.Manager.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        Task<Cliente> DeleteClienteAsync(int id);

        Task<Cliente> GetClienteAsync(int id);

        Task<IEnumerable<Cliente>> GetClientesAsync();

        Task<Cliente> InsertClienteAsync(Cliente cliente);

        Task<Cliente> UpdateClienteAsync(Cliente cliente);
    }
}
