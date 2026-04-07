using CadastroApp.Application.Interfaces;
using CadastroApp.Domain.Entities;
using Microsoft.Data.SqlClient;

namespace CadastroClientes.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly string _connectionString;

        public ClienteRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Cliente> AdicionarAsync(Cliente cliente)
        {
            const string sql = @"INSERT INTO Clientes (Nome, Email, Telefone, DataCadastro, Ativo) VALUES (@Nome, @Email, @Telefone, @DataCadastro, @Ativo) SELECT SCOPE_IDENTITY();";
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Nome", cliente.Nome);
            command.Parameters.AddWithValue("@Email", cliente.Email);
            command.Parameters.AddWithValue("@Telefone", (object?)cliente.Telefone ?? DBNull.Value);
            command.Parameters.AddWithValue("@DataCadastro", cliente.DataCadastro);
            command.Parameters.AddWithValue("@Ativo", cliente.Ativo);

            await connection.OpenAsync();
            var resultado = await command.ExecuteScalarAsync();
            cliente.Id = Convert.ToInt32(resultado);
            return cliente;
        }

        public async Task<Cliente> AtualizarAsync(Cliente cliente)
        {
            const string sql = @"UPDATE Clientes SET Nome = @Nome, Email = @Email, Telefone = @Telefone, Ativo = @Ativo WHERE Id = @Id";

            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Id", cliente.Id);
            command.Parameters.AddWithValue("@Nome", cliente.Nome);
            command.Parameters.AddWithValue("@Email", cliente.Email);
            command.Parameters.AddWithValue("@Telefone", (object?)cliente.Telefone ?? DBNull.Value);
            command.Parameters.AddWithValue("@Ativo", cliente.Ativo);

            await connection.OpenAsync();
            var resultado = await command.ExecuteScalarAsync();
            cliente.Id = Convert.ToInt32(resultado);
            return cliente;
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            const string sql = @"DELETE FROM Clientes WHERE Id = @Id";

            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Id", id);

            await connection.OpenAsync();

            var linhasAfetadas = await command.ExecuteNonQueryAsync();
            return linhasAfetadas > 0;
        }

        public async Task<Cliente?> BuscarPorIdAsync(int id)
        {
            const string sql = @"SELECT Id, Nome, Email, Telefone, DataCadastro, Ativo FROM Clientes WHERE Id = @Id";

            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Id", id);

            await connection.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
                return MapearCliente(reader);

            return null;
        }

        public async Task<List<Cliente>> ListarTodosAsync()
        {
            const string sql = @"SELECT Id, Nome, Email, Telefone, DataCadastro, Ativo FROM Clientes ORDER BY Nome";

            var clientes = new List<Cliente>();

            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(sql, connection);

            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                clientes.Add(MapearCliente(reader));
            }

            return clientes;
        }

        public async Task<List<Cliente>> ListarAtivosAsync()
        {
            const string sql = @"SELECT Id, Nome, Email, Telefone, DataCadastro, Ativo FROM Clientes WHERE Ativo = 1 ORDER BY Nome";

            var clientes = new List<Cliente>();

            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(sql, connection);

            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                clientes.Add(MapearCliente(reader));
            }

            return clientes;
        }


        public static Cliente MapearCliente(SqlDataReader reader)
        {
            return new Cliente
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Nome = reader.GetString(reader.GetOrdinal("Nome")),
                Email = reader.GetString(reader.GetOrdinal("Email")),
                Telefone = reader.IsDBNull(reader.GetOrdinal("Telefone")) ? null : reader.GetString(reader.GetOrdinal("Telefone")),
                DataCadastro = reader.GetDateTime(reader.GetOrdinal("DataCadastro")),
                Ativo = reader.GetBoolean(reader.GetOrdinal("Ativo"))
            };
        }
    }
}
