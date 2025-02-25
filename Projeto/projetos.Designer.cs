namespace CONECTA
{
    partial class projetos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(projetos));
            PanelGeral = new Panel();
            panel1 = new Panel();
            LbAutorProjeto = new Label();
            LbAutor = new Label();
            ComboEstados = new ComboBox();
            DataFinalProjeto = new DateTimePicker();
            LbProjetos = new Label();
            CboProjetos = new ComboBox();
            TextTitulo = new TextBox();
            label13 = new Label();
            label12 = new Label();
            GridParticipantes = new DataGridView();
            TextComplemento = new TextBox();
            label11 = new Label();
            TextNumero = new TextBox();
            label10 = new Label();
            TextBairro = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            DataInicioProjeto = new DateTimePicker();
            CboColaboradores = new ComboBox();
            BtnAddColab = new Button();
            BtnAddArquivo = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            GridAnexos = new DataGridView();
            label1 = new Label();
            GridColaboradores = new DataGridView();
            TextDescricao = new TextBox();
            CboTipo = new ComboBox();
            panelTopo = new Panel();
            MenuProjetos = new ToolStrip();
            BtnSelecionarProjeto = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            BtnNovoProjeto = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            BtnSalvar = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            BtnExtrairDados = new ToolStripButton();
            toolStripSeparator6 = new ToolStripSeparator();
            BtnParticipar = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            BtnSair = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            BtnExcluirProjeto = new ToolStripButton();
            PanelGeral.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GridParticipantes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GridAnexos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GridColaboradores).BeginInit();
            panelTopo.SuspendLayout();
            MenuProjetos.SuspendLayout();
            SuspendLayout();
            // 
            // PanelGeral
            // 
            PanelGeral.Controls.Add(panel1);
            PanelGeral.Controls.Add(panelTopo);
            PanelGeral.Dock = DockStyle.Fill;
            PanelGeral.Location = new Point(0, 0);
            PanelGeral.Name = "PanelGeral";
            PanelGeral.Size = new Size(1124, 465);
            PanelGeral.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(LbAutorProjeto);
            panel1.Controls.Add(LbAutor);
            panel1.Controls.Add(ComboEstados);
            panel1.Controls.Add(DataFinalProjeto);
            panel1.Controls.Add(LbProjetos);
            panel1.Controls.Add(CboProjetos);
            panel1.Controls.Add(TextTitulo);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(GridParticipantes);
            panel1.Controls.Add(TextComplemento);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(TextNumero);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(TextBairro);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(DataInicioProjeto);
            panel1.Controls.Add(CboColaboradores);
            panel1.Controls.Add(BtnAddColab);
            panel1.Controls.Add(BtnAddArquivo);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(GridAnexos);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(GridColaboradores);
            panel1.Controls.Add(TextDescricao);
            panel1.Controls.Add(CboTipo);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 30);
            panel1.Name = "panel1";
            panel1.Size = new Size(1124, 435);
            panel1.TabIndex = 4;
            // 
            // LbAutorProjeto
            // 
            LbAutorProjeto.AutoSize = true;
            LbAutorProjeto.Location = new Point(347, 158);
            LbAutorProjeto.Name = "LbAutorProjeto";
            LbAutorProjeto.Size = new Size(12, 15);
            LbAutorProjeto.TabIndex = 37;
            LbAutorProjeto.Text = "-";
            // 
            // LbAutor
            // 
            LbAutor.AutoSize = true;
            LbAutor.Location = new Point(301, 158);
            LbAutor.Name = "LbAutor";
            LbAutor.Size = new Size(40, 15);
            LbAutor.TabIndex = 36;
            LbAutor.Text = "Autor:";
            // 
            // ComboEstados
            // 
            ComboEstados.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboEstados.Enabled = false;
            ComboEstados.FormattingEnabled = true;
            ComboEstados.Location = new Point(12, 359);
            ComboEstados.Name = "ComboEstados";
            ComboEstados.Size = new Size(212, 23);
            ComboEstados.TabIndex = 35;
            ComboEstados.SelectedIndexChanged += ComboEstados_SelectedIndexChanged;
            // 
            // DataFinalProjeto
            // 
            DataFinalProjeto.CalendarFont = new Font("Segoe UI", 9F);
            DataFinalProjeto.Enabled = false;
            DataFinalProjeto.Location = new Point(301, 130);
            DataFinalProjeto.Name = "DataFinalProjeto";
            DataFinalProjeto.Size = new Size(245, 23);
            DataFinalProjeto.TabIndex = 33;
            DataFinalProjeto.Value = new DateTime(2025, 2, 16, 0, 0, 0, 0);
            // 
            // LbProjetos
            // 
            LbProjetos.AutoSize = true;
            LbProjetos.Location = new Point(15, 7);
            LbProjetos.Name = "LbProjetos";
            LbProjetos.Size = new Size(50, 15);
            LbProjetos.TabIndex = 30;
            LbProjetos.Text = "Projetos";
            // 
            // CboProjetos
            // 
            CboProjetos.AutoCompleteMode = AutoCompleteMode.Suggest;
            CboProjetos.FormattingEnabled = true;
            CboProjetos.Items.AddRange(new object[] { "COMPARTILHAR DE CONHECIMENTO", "AÇÃO SOCIAL" });
            CboProjetos.Location = new Point(12, 25);
            CboProjetos.Name = "CboProjetos";
            CboProjetos.Size = new Size(563, 23);
            CboProjetos.TabIndex = 29;
            CboProjetos.SelectedIndexChanged += CboProjetos_SelectedIndexChanged;
            // 
            // TextTitulo
            // 
            TextTitulo.Enabled = false;
            TextTitulo.Location = new Point(16, 130);
            TextTitulo.Name = "TextTitulo";
            TextTitulo.Size = new Size(261, 23);
            TextTitulo.TabIndex = 28;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(20, 112);
            label13.Name = "label13";
            label13.Size = new Size(37, 15);
            label13.TabIndex = 27;
            label13.Text = "Título";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(635, 55);
            label12.Name = "label12";
            label12.Size = new Size(133, 15);
            label12.TabIndex = 26;
            label12.Text = "Participantes do Projeto";
            // 
            // GridParticipantes
            // 
            GridParticipantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridParticipantes.Location = new Point(632, 77);
            GridParticipantes.Name = "GridParticipantes";
            GridParticipantes.Size = new Size(234, 345);
            GridParticipantes.TabIndex = 25;
            GridParticipantes.KeyDown += GridParticipantes_KeyDown;
            // 
            // TextComplemento
            // 
            TextComplemento.Enabled = false;
            TextComplemento.Location = new Point(241, 403);
            TextComplemento.Name = "TextComplemento";
            TextComplemento.Size = new Size(334, 23);
            TextComplemento.TabIndex = 24;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(245, 385);
            label11.Name = "label11";
            label11.Size = new Size(84, 15);
            label11.TabIndex = 23;
            label11.Text = "Complemento";
            // 
            // TextNumero
            // 
            TextNumero.Enabled = false;
            TextNumero.Location = new Point(12, 403);
            TextNumero.Name = "TextNumero";
            TextNumero.Size = new Size(212, 23);
            TextNumero.TabIndex = 22;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(16, 385);
            label10.Name = "label10";
            label10.Size = new Size(51, 15);
            label10.TabIndex = 21;
            label10.Text = "Número";
            // 
            // TextBairro
            // 
            TextBairro.Enabled = false;
            TextBairro.Location = new Point(241, 359);
            TextBairro.Name = "TextBairro";
            TextBairro.Size = new Size(212, 23);
            TextBairro.TabIndex = 20;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(245, 341);
            label9.Name = "label9";
            label9.Size = new Size(38, 15);
            label9.TabIndex = 19;
            label9.Text = "Bairro";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(17, 322);
            label8.Name = "label8";
            label8.Size = new Size(96, 15);
            label8.TabIndex = 18;
            label8.Text = "Local do Projeto";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(16, 341);
            label7.Name = "label7";
            label7.Size = new Size(42, 15);
            label7.TabIndex = 16;
            label7.Text = "Estado";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(366, 112);
            label6.Name = "label6";
            label6.Size = new Size(115, 15);
            label6.TabIndex = 15;
            label6.Text = "Data final do Projeto";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(355, 58);
            label5.Name = "label5";
            label5.Size = new Size(137, 15);
            label5.TabIndex = 13;
            label5.Text = "Data de Início do Projeto";
            // 
            // DataInicioProjeto
            // 
            DataInicioProjeto.CalendarFont = new Font("Segoe UI", 9F);
            DataInicioProjeto.Enabled = false;
            DataInicioProjeto.Location = new Point(301, 76);
            DataInicioProjeto.Name = "DataInicioProjeto";
            DataInicioProjeto.Size = new Size(245, 23);
            DataInicioProjeto.TabIndex = 12;
            DataInicioProjeto.Value = new DateTime(2025, 2, 16, 0, 0, 0, 0);
            // 
            // CboColaboradores
            // 
            CboColaboradores.FormattingEnabled = true;
            CboColaboradores.Items.AddRange(new object[] { "COMPARTILHAR DE CONHECIMENTO", "AÇÃO SOCIAL" });
            CboColaboradores.Location = new Point(872, 47);
            CboColaboradores.Name = "CboColaboradores";
            CboColaboradores.Size = new Size(201, 23);
            CboColaboradores.TabIndex = 11;
            // 
            // BtnAddColab
            // 
            BtnAddColab.BackColor = Color.Transparent;
            BtnAddColab.BackgroundImage = (Image)resources.GetObject("BtnAddColab.BackgroundImage");
            BtnAddColab.BackgroundImageLayout = ImageLayout.Stretch;
            BtnAddColab.Enabled = false;
            BtnAddColab.Location = new Point(1079, 43);
            BtnAddColab.Name = "BtnAddColab";
            BtnAddColab.Size = new Size(30, 30);
            BtnAddColab.TabIndex = 10;
            BtnAddColab.UseVisualStyleBackColor = false;
            BtnAddColab.Click += BtnAddColab_Click;
            // 
            // BtnAddArquivo
            // 
            BtnAddArquivo.BackColor = Color.Transparent;
            BtnAddArquivo.BackgroundImage = (Image)resources.GetObject("BtnAddArquivo.BackgroundImage");
            BtnAddArquivo.BackgroundImageLayout = ImageLayout.Stretch;
            BtnAddArquivo.Enabled = false;
            BtnAddArquivo.Location = new Point(1079, 238);
            BtnAddArquivo.Name = "BtnAddArquivo";
            BtnAddArquivo.Size = new Size(30, 30);
            BtnAddArquivo.TabIndex = 9;
            BtnAddArquivo.UseVisualStyleBackColor = false;
            BtnAddArquivo.Click += BtnAddArquivo_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 157);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 8;
            label4.Text = "Descrição";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(875, 254);
            label3.Name = "label3";
            label3.Size = new Size(109, 15);
            label3.TabIndex = 7;
            label3.Text = "Anexos/Conteúdos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(875, 29);
            label2.Name = "label2";
            label2.Size = new Size(84, 15);
            label2.TabIndex = 6;
            label2.Text = "Colaboradores";
            // 
            // GridAnexos
            // 
            GridAnexos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridAnexos.Location = new Point(872, 272);
            GridAnexos.Name = "GridAnexos";
            GridAnexos.Size = new Size(240, 150);
            GridAnexos.TabIndex = 5;
            GridAnexos.DoubleClick += GridAnexos_DoubleClick;
            GridAnexos.KeyDown += GridAnexos_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 58);
            label1.Name = "label1";
            label1.Size = new Size(91, 15);
            label1.TabIndex = 4;
            label1.Text = "Tipo do Projeto:";
            // 
            // GridColaboradores
            // 
            GridColaboradores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridColaboradores.Location = new Point(872, 77);
            GridColaboradores.Name = "GridColaboradores";
            GridColaboradores.Size = new Size(240, 150);
            GridColaboradores.TabIndex = 3;
            GridColaboradores.KeyDown += GridColaboradores_KeyDown;
            // 
            // TextDescricao
            // 
            TextDescricao.Enabled = false;
            TextDescricao.Location = new Point(12, 176);
            TextDescricao.Multiline = true;
            TextDescricao.Name = "TextDescricao";
            TextDescricao.Size = new Size(563, 143);
            TextDescricao.TabIndex = 2;
            // 
            // CboTipo
            // 
            CboTipo.Enabled = false;
            CboTipo.FormattingEnabled = true;
            CboTipo.Items.AddRange(new object[] { "Compartilhar Conhecimento", "Ação Social" });
            CboTipo.Location = new Point(12, 76);
            CboTipo.Name = "CboTipo";
            CboTipo.Size = new Size(261, 23);
            CboTipo.TabIndex = 1;
            // 
            // panelTopo
            // 
            panelTopo.Controls.Add(MenuProjetos);
            panelTopo.Dock = DockStyle.Top;
            panelTopo.Location = new Point(0, 0);
            panelTopo.Name = "panelTopo";
            panelTopo.Size = new Size(1124, 30);
            panelTopo.TabIndex = 3;
            // 
            // MenuProjetos
            // 
            MenuProjetos.Dock = DockStyle.Fill;
            MenuProjetos.Items.AddRange(new ToolStripItem[] { BtnSelecionarProjeto, toolStripSeparator1, BtnNovoProjeto, toolStripSeparator4, BtnSalvar, toolStripSeparator2, BtnExtrairDados, toolStripSeparator6, BtnParticipar, toolStripSeparator3, BtnSair, toolStripSeparator5, BtnExcluirProjeto });
            MenuProjetos.Location = new Point(0, 0);
            MenuProjetos.Name = "MenuProjetos";
            MenuProjetos.Size = new Size(1124, 30);
            MenuProjetos.TabIndex = 0;
            MenuProjetos.Text = "toolStrip1";
            // 
            // BtnSelecionarProjeto
            // 
            BtnSelecionarProjeto.Image = (Image)resources.GetObject("BtnSelecionarProjeto.Image");
            BtnSelecionarProjeto.ImageTransparentColor = Color.Magenta;
            BtnSelecionarProjeto.Name = "BtnSelecionarProjeto";
            BtnSelecionarProjeto.Size = new Size(143, 27);
            BtnSelecionarProjeto.Text = "Selecionar um Projeto";
            BtnSelecionarProjeto.Click += BtnSelecionarProjeto_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 30);
            // 
            // BtnNovoProjeto
            // 
            BtnNovoProjeto.Image = (Image)resources.GetObject("BtnNovoProjeto.Image");
            BtnNovoProjeto.ImageTransparentColor = Color.Magenta;
            BtnNovoProjeto.Name = "BtnNovoProjeto";
            BtnNovoProjeto.Size = new Size(114, 27);
            BtnNovoProjeto.Text = "Criar um Projeto";
            BtnNovoProjeto.Click += BtnNovoProjeto_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 30);
            // 
            // BtnSalvar
            // 
            BtnSalvar.Enabled = false;
            BtnSalvar.Image = (Image)resources.GetObject("BtnSalvar.Image");
            BtnSalvar.ImageTransparentColor = Color.Magenta;
            BtnSalvar.Name = "BtnSalvar";
            BtnSalvar.Size = new Size(58, 27);
            BtnSalvar.Text = "Salvar";
            BtnSalvar.Click += BtnSalvar_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 30);
            // 
            // BtnExtrairDados
            // 
            BtnExtrairDados.Enabled = false;
            BtnExtrairDados.Image = (Image)resources.GetObject("BtnExtrairDados.Image");
            BtnExtrairDados.ImageTransparentColor = Color.Magenta;
            BtnExtrairDados.Name = "BtnExtrairDados";
            BtnExtrairDados.Size = new Size(96, 27);
            BtnExtrairDados.Text = "Extrair Dados";
            BtnExtrairDados.Click += BtnExtrairDados_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(6, 30);
            // 
            // BtnParticipar
            // 
            BtnParticipar.Enabled = false;
            BtnParticipar.Image = (Image)resources.GetObject("BtnParticipar.Image");
            BtnParticipar.ImageTransparentColor = Color.Magenta;
            BtnParticipar.Name = "BtnParticipar";
            BtnParticipar.Size = new Size(100, 27);
            BtnParticipar.Text = "Voluntariar-se";
            BtnParticipar.Click += BtnParticipar_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 30);
            // 
            // BtnSair
            // 
            BtnSair.Enabled = false;
            BtnSair.Image = (Image)resources.GetObject("BtnSair.Image");
            BtnSair.ImageTransparentColor = Color.Magenta;
            BtnSair.Name = "BtnSair";
            BtnSair.Size = new Size(104, 27);
            BtnSair.Text = "Sair do Projeto";
            BtnSair.Click += BtnSair_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 30);
            // 
            // BtnExcluirProjeto
            // 
            BtnExcluirProjeto.Enabled = false;
            BtnExcluirProjeto.Image = (Image)resources.GetObject("BtnExcluirProjeto.Image");
            BtnExcluirProjeto.ImageTransparentColor = Color.Magenta;
            BtnExcluirProjeto.Name = "BtnExcluirProjeto";
            BtnExcluirProjeto.Size = new Size(113, 27);
            BtnExcluirProjeto.Text = "Excluir o Projeto";
            BtnExcluirProjeto.Click += BtnExcluirProjeto_Click;
            // 
            // projetos
            // 
            ClientSize = new Size(1124, 465);
            Controls.Add(PanelGeral);
            FormBorderStyle = FormBorderStyle.None;
            Name = "projetos";
            Load += projetos_Load;
            PanelGeral.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)GridParticipantes).EndInit();
            ((System.ComponentModel.ISupportInitialize)GridAnexos).EndInit();
            ((System.ComponentModel.ISupportInitialize)GridColaboradores).EndInit();
            panelTopo.ResumeLayout(false);
            panelTopo.PerformLayout();
            MenuProjetos.ResumeLayout(false);
            MenuProjetos.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelGeral;
        private Panel panelTopo;
        private ToolStrip MenuProjetos;
        private ToolStripButton BtnSalvar;
        private Panel panel1;
        private Label label3;
        private Label label2;
        private DataGridView GridAnexos;
        private Label label1;
        private DataGridView GridColaboradores;
        private TextBox TextDescricao;
        private ComboBox CboTipo;
        private Label label4;
        private Button BtnAddColab;
        private Button BtnAddArquivo;
        private ComboBox CboColaboradores;
        private Label label5;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton BtnNovoProjeto;
        private Label label6;
        private Label label7;
        private TextBox TextNumero;
        private Label label10;
        private TextBox TextBairro;
        private Label label9;
        private Label label8;
        private TextBox TextComplemento;
        private Label label11;
        private Label label12;
        private DataGridView GridParticipantes;
        private TextBox TextTitulo;
        private Label label13;
        private Label LbProjetos;
        private ComboBox CboProjetos;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton BtnParticipar;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton BtnSair;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton BtnSelecionarProjeto;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton BtnExcluirProjeto;
        private DateTimePicker DataInicioProjeto;
        private DateTimePicker DataFinalProjeto;
        private ComboBox ComboEstados;
        private Label LbAutorProjeto;
        private Label LbAutor;
        private ToolStripButton BtnExtrairDados;
        private ToolStripSeparator toolStripSeparator6;
    }
}
