using System;
using reymani_web_api.Api.Endpoints.Cliente;

namespace reymani_web_api.Application.Interfaces;

public interface IClienteService
{
  Task<IEnumerable<Cliente>> GetAllClientesAsync();
  Task<Cliente?> GetClienteByIdAsync(Guid id);
  Task UpdateClienteAsync(Cliente cliente);
  Task DeleteClienteAsync(Guid id);
  Task AssignRolesToClienteAsync(Guid clienteId, IEnumerable<Guid> roleIds);
  Task<bool> CheckPasswordAsync(Cliente cliente, string password);
  Task ChangePasswordAsync(Cliente cliente, string newPassword);
  Task<List<string>> GetPermissionsAsync(Guid clienteId);
  Task ChangeClienteStatusAsync(Guid id, bool activo);
}
