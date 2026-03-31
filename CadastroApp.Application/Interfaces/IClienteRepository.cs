using CadastroApp.Domain.Entities;

namespace CadastroApp.Application.Interfaces;

public interface IClienteRepository
{
    Task<Cliente> AdicionarAsync(Cliente cliente);
    Task<Cliente> ExcluirAsync(Cliente cliente);
    Task<Cliente> Async(Cliente cliente);
}
