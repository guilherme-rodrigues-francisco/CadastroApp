namespace CadastroApp.Domain.Entities;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string CodigoBarra { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
    public bool Ativo { get; set; }

    public Produto()
    {
        Ativo = true;
    }

    public List<string> Validar()
    {
        var erros = new List<string>();

        if (string.IsNullOrEmpty(Nome))
            erros.Add("O Nome do Produto é obrigatório!");
        else if (Nome.Length > 100)
            erros.Add("O Nome do Produto deve conter menos que 100 caracteres!");

        if (string.IsNullOrEmpty(CodigoBarra))
            erros.Add("O Código de Barra do Produto é obrigatório!");
        else if (CodigoBarra.Length < 8)
            erros.Add("O Código de Barra do Produto deve conter pelo menos 8 caracteres!");
        else if (CodigoBarra.Length > 20)
            erros.Add("O Código de Barra do Produto deve conter MENOS que 20 caracteres!");

        if (Preco <= 0)
            erros.Add("O Preço do Produto deve ser maior que zero!");

        if (Estoque < 0)
            erros.Add("O Estoque do Produto não pode ser negativo!");

        return erros;
    }

    public bool EhValido()
    {
        return Validar().Count == 0;
    }
}