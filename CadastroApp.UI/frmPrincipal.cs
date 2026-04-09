using CadastroApp.Application.Services;
using CadastroApp.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroApp.UI
{
    public partial class frmPrincipal : Form
    {
        private readonly ProdutoService _produtoService;

        public frmPrincipal(ProdutoService produtoService)
        {
            _produtoService = produtoService;
            InitializeComponent();
        }

        private async Task CarregarProdutos()
        {
            try
            {
                var produtos = await _produtoService.ListarTodosProdutosAsync();
                dgvProdutos.DataSource = null;
                dgvProdutos.DataSource = produtos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produtos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrid()
        {
            if (dgvProdutos.Columns.Count == 0) return;

            dgvProdutos.Columns["Id"].HeaderText = "Código";
            dgvProdutos.Columns["Id"].Width = 70;
            dgvProdutos.Columns["Nome"].HeaderText = "Nome";
            dgvProdutos.Columns["Nome"].Width = 220;
            dgvProdutos.Columns["CodigoBarra"].HeaderText = "Cód. Barra";
            dgvProdutos.Columns["CodigoBarra"].Width = 140;
            dgvProdutos.Columns["Preco"].HeaderText = "Preço";
            dgvProdutos.Columns["Preco"].Width = 90;
            dgvProdutos.Columns["Preco"].DefaultCellStyle.Format = "C2";
            dgvProdutos.Columns["Estoque"].HeaderText = "Estoque";
            dgvProdutos.Columns["Estoque"].Width = 80;
            dgvProdutos.Columns["Ativo"].HeaderText = "Ativo";
            dgvProdutos.Columns["Ativo"].Width = 55;

            dgvProdutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProdutos.MultiSelect = false;
            dgvProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        }


        private async void frmPrincipal_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            await CarregarProdutos();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            var frmCadastroProduto = Program.ServiceProvider!.GetRequiredService<frmCadastroProduto>();
            frmCadastroProduto.ShowDialog();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private async void btnAtualizar_Click(object sender, EventArgs e)
        {
            await CarregarProdutos();
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            var produtoSelecionado = ObterProdutoSelecionado();

            if (produtoSelecionado == null)
            {
                MessageBox.Show("Selecione um Produto para Editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var FrmCadastroProduto = Program.ServiceProvider!.GetRequiredService<frmCadastroProduto>();
            FrmCadastroProduto.CarregarProduto(produtoSelecionado.Id);
            FrmCadastroProduto.ShowDialog();
            await CarregarProdutos();
        }

        private Produto? ObterProdutoSelecionado()
        {
            if (dgvProdutos.SelectedRows.Count == 0)
                return null;

            return dgvProdutos.SelectedRows[0].DataBoundItem as Produto;
        }

        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            var produtoSelecionado = ObterProdutoSelecionado();

            if (produtoSelecionado == null)
            {
                MessageBox.Show("Selecione um Produto para Excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = MessageBox.Show($"Deseja realmente a exclusão do Produto '{produtoSelecionado.Nome}'?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                var (sucesso, mensagem) = await _produtoService.ExcluirProdutoAsync(produtoSelecionado.Id);

                if(sucesso)
                {
                    MessageBox.Show(mensagem, "Produto excluído com sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CarregarProdutos();
                }
                else
                {
                    MessageBox.Show(mensagem, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
