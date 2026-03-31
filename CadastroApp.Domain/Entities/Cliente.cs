namespace CadastroApp.Domain.Entities;

public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Telefone { get; set; }
    public DateTime DataCadastro { get; set; }
    public bool Ativo { get; set; }

    public Cliente()
    {
        DataCadastro = DateTime.Now;
        Ativo = true;
    }

    public List<string> Validar()
    {
        var erros = new List<string>();

        if (string.IsNullOrEmpty(Nome))
            erros.Add("O Nome é obrigatório!");
        else if (Nome.Length < 3)
            erros.Add("O Nome deve conter pelo menos 3 caracteres!");

        if (string.IsNullOrEmpty(Email))
            erros.Add("O Email é obrigatório!");
        else if (!Email.Contains("@"))
            erros.Add("O Email deve ser válido - falta '@'");

        if (DataCadastro > DateTime.Now)
            erros.Add("A Data de Cadastro não pode ser futura.");

        return erros;
    }

    public bool EhValido()
    {
        return Validar().Count == 0;
    }
}
