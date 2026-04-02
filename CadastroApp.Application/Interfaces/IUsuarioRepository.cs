using CadastroApp.Domain.Entities;

namespace CadastroApp.Application.Interfaces;

public interface IUsuarioRepository
{
    /// <summary>
    /// Busca um usuário pelo login (usado na autenticação) 
    /// </summary>
    Task<Usuario?> BuscarPorLoginAsync(string login);

    /// <summary>
    /// Adiciona um novo usuário ao DB
    /// </summary>
    Task AdicionarAsync(Usuario usuario);

    /// <summary>
    /// Verifica se já existe um usuário com o login informado
    /// </summary>
    Task<bool> LoginExisteAsync(string login);
}
