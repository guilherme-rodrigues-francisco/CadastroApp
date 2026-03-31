using CadastroApp.Domain.Entities;

namespace CadastroApp.Application.Interfaces;

public interface IClienteRepository
{
    Task<Cliente> AdicionarAsync(Cliente cliente);
}
