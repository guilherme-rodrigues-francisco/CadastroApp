using CadastroApp.Application.Interfaces;
using CadastroApp.Domain.Entities;

namespace CadastroApp.Infrastructure.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly string _connectionString;

    public ClienteRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<Cliente> AdicionarAsync(Cliente cliente)
    {
        const string sql = @"INSERT INTO Cliente (Nome, Email, Telefone, DataCadastro, Ativo) VALUES(@Nome, @Email, @Telefone, @DataCadastro, @Ativo)";
    }
}
