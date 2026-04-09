namespace CadastroApp.UI
{
    partial class frmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            btnFechar = new Guna.UI2.WinForms.Guna2Button();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            dgvProdutos = new Guna.UI2.WinForms.Guna2DataGridView();
            btnNovo = new Guna.UI2.WinForms.Guna2Button();
            btnEditar = new Guna.UI2.WinForms.Guna2Button();
            btnAtualizar = new Guna.UI2.WinForms.Guna2Button();
            btnExcluir = new Guna.UI2.WinForms.Guna2Button();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).BeginInit();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.DarkCyan;
            guna2Panel1.Controls.Add(btnFechar);
            guna2Panel1.Controls.Add(guna2HtmlLabel1);
            guna2Panel1.CustomizableEdges = customizableEdges3;
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel1.Size = new Size(800, 70);
            guna2Panel1.TabIndex = 0;
            // 
            // btnFechar
            // 
            btnFechar.CustomizableEdges = customizableEdges1;
            btnFechar.DisabledState.BorderColor = Color.DarkGray;
            btnFechar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnFechar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnFechar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnFechar.FillColor = Color.Red;
            btnFechar.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFechar.ForeColor = Color.White;
            btnFechar.Location = new Point(740, 24);
            btnFechar.Name = "btnFechar";
            btnFechar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnFechar.Size = new Size(35, 25);
            btnFechar.TabIndex = 1;
            btnFechar.Text = "X";
            btnFechar.Click += btnFechar_Click;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = Color.White;
            guna2HtmlLabel1.Location = new Point(24, 22);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(213, 27);
            guna2HtmlLabel1.TabIndex = 0;
            guna2HtmlLabel1.Text = "Cadastro de Produto";
            // 
            // dgvProdutos
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvProdutos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvProdutos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvProdutos.ColumnHeadersHeight = 4;
            dgvProdutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvProdutos.DefaultCellStyle = dataGridViewCellStyle3;
            dgvProdutos.GridColor = Color.FromArgb(231, 229, 255);
            dgvProdutos.Location = new Point(12, 85);
            dgvProdutos.Name = "dgvProdutos";
            dgvProdutos.RowHeadersVisible = false;
            dgvProdutos.Size = new Size(776, 293);
            dgvProdutos.TabIndex = 1;
            dgvProdutos.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvProdutos.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvProdutos.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvProdutos.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvProdutos.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvProdutos.ThemeStyle.BackColor = Color.White;
            dgvProdutos.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvProdutos.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvProdutos.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvProdutos.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvProdutos.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvProdutos.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvProdutos.ThemeStyle.HeaderStyle.Height = 4;
            dgvProdutos.ThemeStyle.ReadOnly = false;
            dgvProdutos.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvProdutos.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProdutos.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvProdutos.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvProdutos.ThemeStyle.RowsStyle.Height = 25;
            dgvProdutos.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvProdutos.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // btnNovo
            // 
            btnNovo.CustomizableEdges = customizableEdges5;
            btnNovo.DisabledState.BorderColor = Color.DarkGray;
            btnNovo.DisabledState.CustomBorderColor = Color.DarkGray;
            btnNovo.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnNovo.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnNovo.FillColor = Color.DarkCyan;
            btnNovo.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNovo.ForeColor = Color.White;
            btnNovo.Location = new Point(12, 393);
            btnNovo.Name = "btnNovo";
            btnNovo.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnNovo.Size = new Size(113, 45);
            btnNovo.TabIndex = 2;
            btnNovo.Text = "Novo";
            btnNovo.Click += btnNovo_Click;
            // 
            // btnEditar
            // 
            btnEditar.CustomizableEdges = customizableEdges7;
            btnEditar.DisabledState.BorderColor = Color.DarkGray;
            btnEditar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnEditar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnEditar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnEditar.FillColor = Color.FromArgb(196, 254, 254);
            btnEditar.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditar.ForeColor = Color.DarkCyan;
            btnEditar.Location = new Point(150, 393);
            btnEditar.Name = "btnEditar";
            btnEditar.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnEditar.Size = new Size(113, 45);
            btnEditar.TabIndex = 2;
            btnEditar.Text = "Editar";
            btnEditar.Click += btnEditar_Click;
            // 
            // btnAtualizar
            // 
            btnAtualizar.CustomizableEdges = customizableEdges9;
            btnAtualizar.DisabledState.BorderColor = Color.DarkGray;
            btnAtualizar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAtualizar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAtualizar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAtualizar.FillColor = Color.FromArgb(230, 230, 230);
            btnAtualizar.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAtualizar.ForeColor = Color.FromArgb(75, 75, 75);
            btnAtualizar.Location = new Point(288, 393);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnAtualizar.Size = new Size(113, 45);
            btnAtualizar.TabIndex = 2;
            btnAtualizar.Text = "Atualizar";
            btnAtualizar.Click += btnAtualizar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.CustomizableEdges = customizableEdges11;
            btnExcluir.DisabledState.BorderColor = Color.DarkGray;
            btnExcluir.DisabledState.CustomBorderColor = Color.DarkGray;
            btnExcluir.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnExcluir.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnExcluir.FillColor = Color.FromArgb(192, 0, 0);
            btnExcluir.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExcluir.ForeColor = Color.White;
            btnExcluir.Location = new Point(675, 393);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnExcluir.Size = new Size(113, 45);
            btnExcluir.TabIndex = 2;
            btnExcluir.Text = "Excluir";
            btnExcluir.Click += btnExcluir_Click;
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnExcluir);
            Controls.Add(btnAtualizar);
            Controls.Add(btnEditar);
            Controls.Add(btnNovo);
            Controls.Add(dgvProdutos);
            Controls.Add(guna2Panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += frmPrincipal_Load;
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button btnFechar;
        private Guna.UI2.WinForms.Guna2DataGridView dgvProdutos;
        private Guna.UI2.WinForms.Guna2Button btnNovo;
        private Guna.UI2.WinForms.Guna2Button btnEditar;
        private Guna.UI2.WinForms.Guna2Button btnAtualizar;
        private Guna.UI2.WinForms.Guna2Button btnExcluir;
    }
}
