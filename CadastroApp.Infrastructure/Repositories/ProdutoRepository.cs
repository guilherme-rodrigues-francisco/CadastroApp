using CadastroApp.Application.Interfaces;
using CadastroApp.Domain.Entities;
using Microsoft.Data.SqlClient;

namespace CadastroApp.Infrastructure.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly string _connectionString;
    public ProdutoRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<Produto> AdicionarAsync(Produto produto)
    {
        const string sql = @"INSERT INTO Produtos (Nome, CodigoBarra, Preco, Estoque, Ativo)
                             VALUES (@Nome, @CodigoBarra, @Preco, @Estoque, @Ativo); SELECT SCOPE_IDENTITY();";

        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@Nome", produto.Nome);
        command.Parameters.AddWithValue("@CodigoBarra", produto.CodigoBarra);
        command.Parameters.AddWithValue("@Preco", produto.Preco);
        command.Parameters.AddWithValue("@Estoque", produto.Estoque);
        command.Parameters.AddWithValue("@Ativo", produto.Ativo);

        await connection.OpenAsync();
        var resultado = await command.ExecuteScalarAsync();

        if (resultado == null || resultado == DBNull.Value)
            throw new Exception("Erro ao obter o Id do produto inserido.");

        produto.Id = Convert.ToInt32(resultado);

        return produto;
    }

    public async Task<Produto> AtualizarAsync(Produto produto)
    {
        const string sql = @"UPDATE Produtos SET Nome = @Nome, CodigoBarra = @CodigoBarra, Preco = @Preco, Estoque = @Estoque, Ativo = @Ativo
                             WHERE Id = @Id";
        
        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@Id", produto.Id);
        command.Parameters.AddWithValue("@Nome", produto.Nome);
        command.Parameters.AddWithValue("@CodigoBarra", produto.CodigoBarra);
        command.Parameters.AddWithValue("@Preco", produto.Preco);
        command.Parameters.AddWithValue("@Estoque", produto.Estoque);
        command.Parameters.AddWithValue("@Ativo", produto.Ativo);

        await connection.OpenAsync();
        var resultado = await command.ExecuteScalarAsync();
        produto.Id = Convert.ToInt32(resultado);

        return produto;
    }

    public async Task<bool> ExcluirAsync(int id)
    {
        const string sql = @"DELETE FROM Produtos WHERE Id = @Id";

        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand(sql, connection);
        
        command.Parameters.AddWithValue("@Id", id);

        await connection.OpenAsync();

        var linhasAfetadas = await command.ExecuteNonQueryAsync();
        return linhasAfetadas > 0;
    }

    public async Task<Produto?> BuscarPorIdAsync(int id)
    {
        const string sql = @"SELECT Id, Nome, CodigoBarra, Preco, Estoque, Ativo FROM Produtos WHERE Id = @Id";

        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@Id", id);

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        if(await reader.ReadAsync())
            return MapearProduto(reader);

        return null;
    }

    public async Task<Produto?> BuscarPorCodigoBarraAsync(string codigoBarra)
    {
        const string sql = @"SELECT Id, Nome, CodigoBarra, Preco, Estoque, Ativo 
                         FROM Produtos 
                         WHERE CodigoBarra = @CodigoBarra";

        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@CodigoBarra", codigoBarra);

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync())
            return MapearProduto(reader);

        return null;
    }

    public async Task<List<Produto>> ListarTodosAsync() 
    {
        const string sql = @"SELECT Id, Nome, CodigoBarra, Preco, Estoque, Ativo FROM Produtos ORDER BY Nome ASC";

        var produtos = new List<Produto>();

        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand(sql, connection);

        await connection.OpenAsync();
        using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
            produtos.Add(MapearProduto(reader));

        return produtos;
    }

    public async Task<List<Produto>> ListarAtivosAsync()
    {
        const string sql = @"SELECT Id, Nome, CodigoBarra, Preco, Estoque, Ativo FROM Produtos WHERE Ativo = 1 ORDER BY Nome ASC";
        
        var produtos = new List<Produto>();
        
        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand(sql, connection);
        
        await connection.OpenAsync();
        using var reader = await command.ExecuteReaderAsync();
        
        while (await reader.ReadAsync())
            produtos.Add(MapearProduto(reader));
        
        return produtos;
    }

    public static Produto MapearProduto(SqlDataReader reader)
    {
        return new Produto
        {
            Id = reader.GetInt32(reader.GetOrdinal("Id")),
            Nome = reader.GetString(reader.GetOrdinal("Nome")),
            CodigoBarra = reader.GetString(reader.GetOrdinal("CodigoBarra")),
            Preco = reader.GetDecimal(reader.GetOrdinal("Preco")),
            Estoque = reader.GetInt32(reader.GetOrdinal("Estoque")),
            Ativo = reader.GetBoolean(reader.GetOrdinal("Ativo"))
        };
    }
}
