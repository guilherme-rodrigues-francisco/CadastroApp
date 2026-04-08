using CadastroApp.Application.Interfaces;
using CadastroApp.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace CadastroApp.Application.Services;

public class ClienteService
{
    private readonly IClienteRepository _clienteRepository;
    public ClienteService(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<(bool Sucesso, List<string> Erros, Cliente? Cliente)> CadastrarClienteAsync(Cliente cliente)
    {
        var erros = cliente.Validar();

        if (erros.Any())
            return (false, erros, null);

        try
        {
            var clienteSalvo = await _clienteRepository.AdicionarAsync(cliente);
            return (true, new List<string>(), clienteSalvo);
        }
        catch (Exception ex)
        {
            return (false, new List<string>() { $"Erro ao salvar cliente: {ex.Message}" }, null);
        }
    }

    public async Task<(bool Sucesso, List<string> Erros, Cliente? Cliente)> AtualizarClienteAsync(Cliente cliente)
    {
        var erros = cliente.Validar();

        if (erros.Any())
            return (false, erros, null);

        var clienteExiste = await _clienteRepository.BuscarPorIdAsync(cliente.Id);
        if (clienteExiste == null)
            return (false, new List<string>() { "Cliente não encontrado." }, null);

        try
        {
            var clienteSalvo = await _clienteRepository.AtualizarAsync(cliente);
            return (true, new List<string>(), clienteSalvo);
        }
        catch (Exception ex)
        {
            return (false, new List<string>() { $"Erro ao salvar cliente: {ex.Message}" }, null);
        }
    }

    public async Task<(bool Sucesso, string Mensagem)> ExcluirClienteAsync(int id)
    {
        try
        {
            var clienteExiste = await _clienteRepository.BuscarPorIdAsync(id);
            if (clienteExiste == null)
                return (false, "Cliente não encontrado.");

            var clienteRemovido = await _clienteRepository.ExcluirAsync(id);
            return clienteRemovido ? (true, "Cliente removido com sucesso!") : (false, "Não foi possível excluir o Cliente.");

        }
        catch (Exception ex)
        {
            return (false, $"Erro ao excluir o cliente. Erro externo: {ex.Message}\n Erro interno: {ex.InnerException}");
        }
    }

    public async Task<Cliente?> BuscarClientePorIdAsync(int id)
    {
        return await _clienteRepository.BuscarPorIdAsync(id);
    }

    public async Task<List<Cliente>> ListarClientesAsync()
    {
        return await _clienteRepository.ListarTodosAsync();
    }

    public async Task<List<Cliente>> ListarClientesAtivosAsync()
    {
        return await _clienteRepository.ListarAtivosAsync();
    }
}
