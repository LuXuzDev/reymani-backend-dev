using System;
using reymani_web_api.Domain.Entities;

namespace reymani_web_api.Application.Interfaces
{
  public interface INegocioClienteRepository
  {
    Task AddAsync(NegocioCliente negocioCliente);
    Task DeleteAsync(NegocioCliente negocioCliente);
    Task<NegocioCliente?> GetByIdAsync(Guid id);
    Task<IEnumerable<Negocio>> GetNegociosByClienteIdAsync(Guid clienteId);
    Task<IEnumerable<Cliente>> GetClientesByNegocioIdAsync(Guid negocioId);
  }
}
