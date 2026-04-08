using CadastroApp.Domain.Entities;

namespace CadastroApp.Application.Interfaces;

public interface IProdutoRepository
{
    Task<Produto> AdicionarAsync(Produto produto);
    Task<Produto> AtualizarAsync(Produto produto);
    Task<bool> ExcluirAsync(int id);
    Task<Produto?> BuscarPorIdAsync(int id);
    Task<Produto?> BuscarPorCodigoBarraAsync(string codigoBarra);
    Task<List<Produto>> ListarTodosAsync();
     Task<List<Produto>> ListarAtivosAsync();
}
