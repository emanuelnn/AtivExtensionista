namespace CONECTA
{
    partial class GestaoUsuarios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestaoUsuarios));
            PanelPrincipal_GestaoUsuarios = new Panel();
            PanelAdmin = new Panel();
            panel2 = new Panel();
            DataGridUsuarios = new DataGridView();
            panel1 = new Panel();
            BtnModerador = new ToolStrip();
            BtnTornarModerador = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            BtnRemoverModerador = new ToolStripButton();
            PanelCadastro = new Panel();
            label1 = new Label();
            TextSenha = new TextBox();
            label7 = new Label();
            TextEndereco = new TextBox();
            LbCadNome = new Label();
            TextNome = new TextBox();
            label5 = new Label();
            TextCep = new TextBox();
            label4 = new Label();
            TextEstado = new TextBox();
            BtnAtualizar = new Button();
            label2 = new Label();
            label3 = new Label();
            TextNumero = new TextBox();
            TextBairro = new TextBox();
            PanelPrincipal_GestaoUsuarios.SuspendLayout();
            PanelAdmin.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridUsuarios).BeginInit();
            panel1.SuspendLayout();
            BtnModerador.SuspendLayout();
            PanelCadastro.SuspendLayout();
            SuspendLayout();
            // 
            // PanelPrincipal_GestaoUsuarios
            // 
            PanelPrincipal_GestaoUsuarios.Controls.Add(PanelAdmin);
            PanelPrincipal_GestaoUsuarios.Controls.Add(PanelCadastro);
            PanelPrincipal_GestaoUsuarios.Dock = DockStyle.Fill;
            PanelPrincipal_GestaoUsuarios.Location = new Point(0, 0);
            PanelPrincipal_GestaoUsuarios.Name = "PanelPrincipal_GestaoUsuarios";
            PanelPrincipal_GestaoUsuarios.Size = new Size(1140, 504);
            PanelPrincipal_GestaoUsuarios.TabIndex = 0;
            // 
            // PanelAdmin
            // 
            PanelAdmin.Controls.Add(panel2);
            PanelAdmin.Controls.Add(panel1);
            PanelAdmin.Dock = DockStyle.Bottom;
            PanelAdmin.Location = new Point(0, 303);
            PanelAdmin.Name = "PanelAdmin";
            PanelAdmin.Size = new Size(1140, 201);
            PanelAdmin.TabIndex = 26;
            // 
            // panel2
            // 
            panel2.Controls.Add(DataGridUsuarios);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 25);
            panel2.Name = "panel2";
            panel2.Size = new Size(1140, 176);
            panel2.TabIndex = 27;
            // 
            // DataGridUsuarios
            // 
            DataGridUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridUsuarios.Dock = DockStyle.Fill;
            DataGridUsuarios.Location = new Point(0, 0);
            DataGridUsuarios.Name = "DataGridUsuarios";
            DataGridUsuarios.Size = new Size(1140, 176);
            DataGridUsuarios.TabIndex = 0;
            DataGridUsuarios.KeyDown += DataGridUsuarios_KeyDown;
            // 
            // panel1
            // 
            panel1.Controls.Add(BtnModerador);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1140, 25);
            panel1.TabIndex = 26;
            // 
            // BtnModerador
            // 
            BtnModerador.Dock = DockStyle.Fill;
            BtnModerador.Items.AddRange(new ToolStripItem[] { BtnTornarModerador, toolStripSeparator1, BtnRemoverModerador });
            BtnModerador.Location = new Point(0, 0);
            BtnModerador.Name = "BtnModerador";
            BtnModerador.Size = new Size(1140, 25);
            BtnModerador.TabIndex = 1;
            BtnModerador.Text = "toolStrip1";
            // 
            // BtnTornarModerador
            // 
            BtnTornarModerador.Image = (Image)resources.GetObject("BtnTornarModerador.Image");
            BtnTornarModerador.ImageTransparentColor = Color.Magenta;
            BtnTornarModerador.Name = "BtnTornarModerador";
            BtnTornarModerador.Size = new Size(122, 22);
            BtnTornarModerador.Text = "Tornar Moderador";
            BtnTornarModerador.Click += BtnTornarModerador_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // BtnRemoverModerador
            // 
            BtnRemoverModerador.Image = (Image)resources.GetObject("BtnRemoverModerador.Image");
            BtnRemoverModerador.ImageTransparentColor = Color.Magenta;
            BtnRemoverModerador.Name = "BtnRemoverModerador";
            BtnRemoverModerador.Size = new Size(166, 22);
            BtnRemoverModerador.Text = "Remover Perfil Moderador";
            BtnRemoverModerador.Click += BtnRemoverModerador_Click;
            // 
            // PanelCadastro
            // 
            PanelCadastro.BackColor = Color.Transparent;
            PanelCadastro.Controls.Add(label1);
            PanelCadastro.Controls.Add(TextSenha);
            PanelCadastro.Controls.Add(label7);
            PanelCadastro.Controls.Add(TextEndereco);
            PanelCadastro.Controls.Add(LbCadNome);
            PanelCadastro.Controls.Add(TextNome);
            PanelCadastro.Controls.Add(label5);
            PanelCadastro.Controls.Add(TextCep);
            PanelCadastro.Controls.Add(label4);
            PanelCadastro.Controls.Add(TextEstado);
            PanelCadastro.Controls.Add(BtnAtualizar);
            PanelCadastro.Controls.Add(label2);
            PanelCadastro.Controls.Add(label3);
            PanelCadastro.Controls.Add(TextNumero);
            PanelCadastro.Controls.Add(TextBairro);
            PanelCadastro.Location = new Point(12, 6);
            PanelCadastro.Name = "PanelCadastro";
            PanelCadastro.Size = new Size(273, 246);
            PanelCadastro.TabIndex = 22;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(19, 181);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 34;
            label1.Text = "Senha:";
            // 
            // TextSenha
            // 
            TextSenha.Location = new Point(63, 177);
            TextSenha.Name = "TextSenha";
            TextSenha.Size = new Size(197, 23);
            TextSenha.TabIndex = 33;
            TextSenha.Text = "10111996";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Location = new Point(2, 152);
            label7.Name = "label7";
            label7.Size = new Size(59, 15);
            label7.TabIndex = 32;
            label7.Text = "Endereço:";
            // 
            // TextEndereco
            // 
            TextEndereco.Location = new Point(63, 148);
            TextEndereco.Name = "TextEndereco";
            TextEndereco.Size = new Size(197, 23);
            TextEndereco.TabIndex = 31;
            // 
            // LbCadNome
            // 
            LbCadNome.AutoSize = true;
            LbCadNome.BackColor = Color.Transparent;
            LbCadNome.Location = new Point(18, 7);
            LbCadNome.Name = "LbCadNome";
            LbCadNome.Size = new Size(43, 15);
            LbCadNome.TabIndex = 30;
            LbCadNome.Text = "Nome:";
            // 
            // TextNome
            // 
            TextNome.Location = new Point(63, 3);
            TextNome.Name = "TextNome";
            TextNome.Size = new Size(197, 23);
            TextNome.TabIndex = 29;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Location = new Point(30, 36);
            label5.Name = "label5";
            label5.Size = new Size(31, 15);
            label5.TabIndex = 28;
            label5.Text = "CEP:";
            // 
            // TextCep
            // 
            TextCep.Location = new Point(63, 32);
            TextCep.Name = "TextCep";
            TextCep.Size = new Size(197, 23);
            TextCep.TabIndex = 27;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Location = new Point(16, 65);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 26;
            label4.Text = "Estado:";
            // 
            // TextEstado
            // 
            TextEstado.Location = new Point(63, 61);
            TextEstado.Name = "TextEstado";
            TextEstado.Size = new Size(197, 23);
            TextEstado.TabIndex = 25;
            // 
            // BtnAtualizar
            // 
            BtnAtualizar.Location = new Point(84, 206);
            BtnAtualizar.Name = "BtnAtualizar";
            BtnAtualizar.Size = new Size(118, 23);
            BtnAtualizar.TabIndex = 24;
            BtnAtualizar.Text = "Atualizar Dados";
            BtnAtualizar.UseVisualStyleBackColor = true;
            BtnAtualizar.Click += BtnAtualizar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(7, 123);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 23;
            label2.Text = "Numero:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Location = new Point(20, 94);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 22;
            label3.Text = "Bairro:";
            // 
            // TextNumero
            // 
            TextNumero.Location = new Point(63, 119);
            TextNumero.Name = "TextNumero";
            TextNumero.Size = new Size(197, 23);
            TextNumero.TabIndex = 21;
            // 
            // TextBairro
            // 
            TextBairro.Location = new Point(63, 90);
            TextBairro.Name = "TextBairro";
            TextBairro.Size = new Size(197, 23);
            TextBairro.TabIndex = 20;
            // 
            // GestaoUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1140, 504);
            Controls.Add(PanelPrincipal_GestaoUsuarios);
            FormBorderStyle = FormBorderStyle.None;
            Name = "GestaoUsuarios";
            Text = "GestaoUsuarios";
            PanelPrincipal_GestaoUsuarios.ResumeLayout(false);
            PanelAdmin.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DataGridUsuarios).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            BtnModerador.ResumeLayout(false);
            BtnModerador.PerformLayout();
            PanelCadastro.ResumeLayout(false);
            PanelCadastro.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelPrincipal_GestaoUsuarios;
        private Panel PanelCadastro;
        private Label label7;
        private TextBox TextEndereco;
        private Label LbCadNome;
        private TextBox TextNome;
        private Label label5;
        private TextBox TextCep;
        private Label label4;
        private TextBox TextEstado;
        private Button BtnAtualizar;
        private Label label2;
        private Label label3;
        private TextBox TextNumero;
        private TextBox TextBairro;
        private Label label1;
        private TextBox TextSenha;
        private Panel PanelAdmin;
        private Panel panel2;
        private DataGridView DataGridUsuarios;
        private Panel panel1;
        private ToolStrip BtnModerador;
        private ToolStripButton BtnTornarModerador;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton BtnRemoverModerador;
    }
}