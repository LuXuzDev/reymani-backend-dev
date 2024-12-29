using System;

namespace reymani_web_api.Application.Interfaces;

public interface IClienteRepository
{
  Task<IEnumerable<Cliente>> GetAllAsync();
  Task<Cliente?> GetByIdAsync(Guid id);
  Task AddAsync(Cliente cliente);
  Task UpdateAsync(Cliente cliente);
  Task DeleteAsync(Cliente cliente);
  Task<Cliente?> GetClienteByUsernameOrPhoneAsync(string usernameOrPhone);
  Task<string[]> GetIdRolesClienteAsync(Guid id);
  Task<List<string>> GetPermissionsAsync(Guid clienteId);
}