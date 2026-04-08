using CadastroApp.Application.Interfaces;
using CadastroApp.Domain.Entities;

namespace CadastroApp.Application.Services;

public class ProdutoService
{
    private readonly IProdutoRepository _produtoRepository;
    public ProdutoService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<(bool Sucesso, List<string> Erros, Produto? Produto)> CadastrarProdutosAsync(Produto produto)
    {
        var erros = produto.Validar();
        if (erros.Any())
            return (false, erros, null);
        
        // verifica se o código de barra já existe
        var codigoBarraEmUso = await _produtoRepository.BuscarPorCodigoBarraAsync(produto.CodigoBarra);
        if (codigoBarraEmUso != null)
            return (false, new List<string> { "Código de barra já cadastrado para outro produto." }, null);

        try
        {
            var produtoSalvo = await _produtoRepository.AdicionarAsync(produto);
            return (true, new List<string>(), produtoSalvo);
        }
        catch (Exception ex)
        {
            return (false, new List<string> { $"Erro ao cadastrar produto: {ex.Message}" }, null);
        }
    }

    public async Task<(bool Sucesso, List<string> Erros, Produto? Produto)> AtualizarProdutoAsync(Produto produto)
    {
        var erros = produto.Validar();
        if (erros.Any())
            return (false, erros, null);

        var produtoExistente = await _produtoRepository.BuscarPorIdAsync(produto.Id);
        if (produtoExistente == null)
            return (false, new List<string> { "Produto não encontrado." }, null);

        var codigoBarraEmUso = await _produtoRepository.BuscarPorCodigoBarraAsync(produto.CodigoBarra);
        if(codigoBarraEmUso != null && codigoBarraEmUso.Id != produto.Id)
            return (false, new List<string> { "Já existe um produto com esse Código de Barra!" }, null);

        try
        {
            var produtoSalvo = await _produtoRepository.AtualizarAsync(produto);
            return (true, new List<string>(), produtoSalvo);
        }
        catch (Exception ex)
        {
            return(false, new List<string> { $"Erro ao salvar Produto: {ex.Message}" }, null);
        }
    }
}
