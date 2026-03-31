namespace CadastroApp.Domain.Entities;

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Login { get; set; } = string.Empty;
    public string SenhaHash { get; set; } = string.Empty;
    public bool Ativo { get; set; }
    public DateTime DataCadastro { get; set; }

    public Usuario()
    {
        DataCadastro = DateTime.Now;
        Ativo = true;
    }

    public List<string> Validar()
    {
        var erros = new List<string>();

        if (string.IsNullOrEmpty(Nome))
            erros.Add("O Nome do Usuário é obrigatório!");
        else if (Nome.Length < 3)
            erros.Add("O Nome precisa ter pelo menos 3 caracteres!");

        if (string.IsNullOrEmpty(Login))
            erros.Add("O Login do Usuário é obrigatório!");
        else if (Login.Length < 3)
            erros.Add("O Login precisa ter pelo menos 3 caracteres!");

        if (string.IsNullOrEmpty(SenhaHash))
            erros.Add("A Senha do Usuário é obrigatório!");

        if (DataCadastro > DateTime.Now)
            erros.Add("A Data de Cadastro não pode ser futura!");

        return erros;
    }

    public bool EhValido()
    {
        return Validar().Count == 0;
    }
}
