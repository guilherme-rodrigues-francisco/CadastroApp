using CadastroApp.Domain.Entities;

namespace CadastroApp.Application.Interfaces;

public interface IClienteRepository
{
    /// <summary>
    /// Adiciona um cliente ao DB
    /// </summary>
    Task<Cliente> AdicionarAsync(Cliente cliente);

    /// <summary>
    /// Atualiza um cliente no DB
    /// </summary>
    Task<Cliente> AtualizarAsync(Cliente cliente);

    /// <summary>
    /// Exclui um cliente no DB
    /// </summary>
    Task<bool> ExcluirAsync(int id);

    /// <summary>
    /// Busca um cliente especifico usando o Id
    /// </summary>
    Task<Cliente> BuscarPorIdAsync(int id);

    /// <summary>
    /// Busca todos clientes no DB
    /// </summary>
    Task<List<Cliente>> ListarTodosAsync();
}
