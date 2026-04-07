using CadastroApp.Application.Interfaces;
using CadastroApp.Domain.Entities;
using Microsoft.Data.SqlClient;

namespace CadastroClientes.Infrastructure.Repositories;

/// <summary>
/// Repositório de Usuarios - Acesso a dados usando ADO.NET puro.
/// 
/// MESMO PADRÃO DO ClienteRepository:
/// - Implementa a interface definida na Application
/// - Usa SqlConnection/SqlCommand para acessar o banco
/// - Contém APENAS lógica de acesso a dados (sem regras de negócio)
/// 
/// CONCEITOS ADO.NET APLICADOS:
/// - SqlConnection: gerencia a conexão com o SQL Server
/// - SqlCommand: encapsula o comando SQL a ser executado
/// - SqlParameter: passa parâmetros de forma segura (anti SQL Injection)
/// - SqlDataReader: lê os resultados de queries SELECT
/// </summary>
public class UsuarioRepository : IUsuarioRepository
{
    private readonly string _connectionString;

    public UsuarioRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    /// <summary>
    /// Busca um usuário pelo login.
    /// 
    /// NOTA: Usamos LOWER() e TRIM() no SQL para garantir
    /// que a busca não é case-sensitive, igual ao que o EF Core
    /// fazia com LINQ (u => u.Login == login.ToLower().Trim()).
    /// 
    /// Com ADO.NET, escrevemos o SQL diretamente — temos controle total!
    /// </summary>
    public async Task<Usuario?> BuscarPorLoginAsync(string login)
    {
        const string sql = @"
            SELECT Id, Nome, Login, SenhaHash, DataCadastro, Ativo 
            FROM Usuarios 
            WHERE Login = @Login";

        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand(sql, connection);

        // Normaliza o login antes de enviar ao banco
        command.Parameters.AddWithValue("@Login", login.ToLower().Trim());

        await connection.OpenAsync();
        using var reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync())
        {
            return MapearUsuario(reader);
        }

        return null;
    }

    /// <summary>
    /// Adiciona um novo usuário ao banco usando INSERT.
    /// 
    /// ExecuteNonQueryAsync: usado porque não precisamos retornar dados,
    /// apenas executar o INSERT.
    /// </summary>
    public async Task AdicionarAsync(Usuario usuario)
    {
        const string sql = @"
            INSERT INTO Usuarios (Nome, Login, SenhaHash, DataCadastro, Ativo)
            VALUES (@Nome, @Login, @SenhaHash, @DataCadastro, @Ativo)";

        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@Nome", usuario.Nome);
        command.Parameters.AddWithValue("@Login", usuario.Login);
        command.Parameters.AddWithValue("@SenhaHash", usuario.SenhaHash);
        command.Parameters.AddWithValue("@DataCadastro", usuario.DataCadastro);
        command.Parameters.AddWithValue("@Ativo", usuario.Ativo);

        await connection.OpenAsync();
        await command.ExecuteNonQueryAsync();
    }

    /// <summary>
    /// Verifica se já existe um usuário com o login informado.
    /// 
    /// ExecuteScalarAsync: retorna um único valor.
    /// COUNT(*) retorna o número de registros encontrados.
    /// Se > 0, o login já existe.
    /// </summary>
    public async Task<bool> LoginExisteAsync(string login)
    {
        const string sql = "SELECT COUNT(*) FROM Usuarios WHERE Login = @Login";

        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@Login", login.ToLower().Trim());

        await connection.OpenAsync();

        var count = Convert.ToInt32(await command.ExecuteScalarAsync());
        return count > 0;
    }

    /// <summary>
    /// Método auxiliar: converte uma linha do SqlDataReader em um objeto Usuario.
    /// 
    /// MAPEAMENTO MANUAL:
    /// Com ADO.NET, cada coluna precisa ser mapeada manualmente para a propriedade
    /// correspondente da entidade. Isso é mais trabalhoso que o EF Core (que faz
    /// automaticamente), mas dá TOTAL controle sobre o processo.
    /// </summary>
    private static Usuario MapearUsuario(SqlDataReader reader)
    {
        return new Usuario
        {
            Id = reader.GetInt32(reader.GetOrdinal("Id")),
            Nome = reader.GetString(reader.GetOrdinal("Nome")),
            Login = reader.GetString(reader.GetOrdinal("Login")),
            SenhaHash = reader.GetString(reader.GetOrdinal("SenhaHash")),
            DataCadastro = reader.GetDateTime(reader.GetOrdinal("DataCadastro")),
            Ativo = reader.GetBoolean(reader.GetOrdinal("Ativo"))
        };
    }
}
