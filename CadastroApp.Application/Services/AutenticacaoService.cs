using CadastroApp.Application.Interfaces;
using CadastroApp.Domain.Entities;
using System.Security.Cryptography;
using System.Text;

namespace CadastroApp.Application.Services;

public class AutenticacaoService
{
    private readonly IUsuarioRepository _usuarioRepository;
    public Usuario? UsuarioLogado { get; private set; }

    public AutenticacaoService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<(bool Sucesso, string Mensagem)> AutenticarUsuarioAsync(string login, string senha)
    {
        if (string.IsNullOrWhiteSpace(login))
            return (false, "Informe o login.");
        if (string.IsNullOrWhiteSpace(senha))
            return (false, "Informe a senha.");

        var usuario = await _usuarioRepository.BuscarPorLoginAsync(login);
        if (usuario == null)
            return (false, "Usuário não encontrado.");
        if (!usuario.Ativo)
            return (false, "Usuario inativo. Contate o administrador.");

        var hashInformado = GerarHash(senha);
        if (hashInformado != usuario.SenhaHash)
            return (false, "Senha Incorreta.");

        UsuarioLogado = usuario;
        return (true, $"Bem vindo, {usuario.Nome}");
    }

    public async Task<(bool Sucesso, string Mensagem)> RegistrarUsuarioAsync(string nome, string login, string senha)
    {
        if (string.IsNullOrWhiteSpace(senha) || senha.Length < 4)
            return (false, "A senha deve ter pelo menos 4 caracteres.");

        if (await _usuarioRepository.LoginExisteAsync(login))
            return (false, "Já existe um usuário com esse login.");

        var usuario = new Usuario
        {
            Nome = nome,
            Login = login.ToLower().Trim(),
            SenhaHash = GerarHash(senha)
        };

        var erros = usuario.Validar();
        if (erros.Count > 0)
            return (false, string.Join("\n", erros));

        await _usuarioRepository.AdicionarAsync(usuario);
        return (true, "Usuário registrado com sucesso!");
    }

    public void Logout()
    {
        UsuarioLogado = null;
    }

    private static string GerarHash(string texto)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(texto));
        return Convert.ToHexString(bytes).ToLower();
    }
}
