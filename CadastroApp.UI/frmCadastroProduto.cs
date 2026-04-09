using CadastroApp.Application.Services;
using CadastroApp.Domain.Entities;

namespace CadastroApp.UI;

public partial class frmCadastroProduto : Form
{
    private readonly ProdutoService _produtoService;
    private Produto? _produtoAtual;
    private bool _modoEdicao = false;
    private int? _produtoParaEditarId;
    public frmCadastroProduto(ProdutoService produtoService)
    {
        _produtoService = produtoService;
        InitializeComponent();
    }

    public void CarregarProduto(int id)
    {
        _produtoParaEditarId = id;
    }

    private void PreencherCampos()
    {
        if (_produtoAtual != null)
        {
            txtNome.Text = _produtoAtual.Nome;
            txtCodigoBarra.Text = _produtoAtual.CodigoBarra;
            txtPreco.Text = _produtoAtual.Preco.ToString("F2");
            nudEstoque.Value = _produtoAtual.Estoque;
            chkAtivo.Checked = _produtoAtual.Ativo;
        }
    }

    private async void frmCadastroProduto_Load(object sender, EventArgs e)
    {
        if (_produtoParaEditarId.HasValue)
        {
            _produtoAtual = await _produtoService.BuscarProdutoPorIdAsync(_produtoParaEditarId.Value);

            if (_produtoAtual != null)
            {
                _modoEdicao = true;
                this.Text = "Editar Produto";
                PreencherCampos();
            }
            else
            {
                MessageBox.Show("Produto não encontrado para edição.", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        else
        {
            _produtoAtual = new Produto();
            _modoEdicao = false;
            this.Text = "Cadastrar Novo Produto";
        }
    }

    private async void btnCadastrar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtNome.Text))
        {
            MessageBox.Show("Informe o Nome do Produto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtNome.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(txtCodigoBarra.Text))
        {
            MessageBox.Show("Informe o Código de Barra do Produto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtCodigoBarra.Focus();
            return;
        }


        if (!decimal.TryParse(txtPreco.Text, out decimal preco) || preco <= 0)
        {
            MessageBox.Show("Informe um Preço válido (maior que zero).", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtPreco.Focus();
            return;
        }

        try
        {
            if (_produtoAtual == null)
                _produtoAtual = new Produto();

            _produtoAtual.Nome = txtNome.Text.Trim();
            _produtoAtual.CodigoBarra = txtCodigoBarra.Text.Trim();
            _produtoAtual.Preco = preco;
            _produtoAtual.Estoque = (int)nudEstoque.Value;
            _produtoAtual.Ativo = chkAtivo.Checked;

            bool sucesso;
            List<string> erros;

            if (_modoEdicao)
                (sucesso, erros, _) = await _produtoService.AtualizarProdutoAsync(_produtoAtual);
            else
                (sucesso, erros, _) = await _produtoService.CadastrarProdutosAsync(_produtoAtual);

            if (sucesso)
            {
                MessageBox.Show("Produto salvo com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                var msg = string.Join("\n", erros);
                MessageBox.Show(msg, "Erros de validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao salvar produto: {ex.Message}", "Erro",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnFechar_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        Close();
    }


}
