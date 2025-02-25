namespace CONECTA.Classes
{
    partial class resumoProjetos
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
            PanelPrincipal_ResumoProjetos = new Panel();
            BtnExtrair = new Button();
            label1 = new Label();
            CboTipoProjeto = new ComboBox();
            LbQtdProjetos = new Label();
            label4 = new Label();
            CboBairro = new ComboBox();
            label3 = new Label();
            GridDadosGeral = new DataGridView();
            label2 = new Label();
            CboEstado = new ComboBox();
            PanelPrincipal_ResumoProjetos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GridDadosGeral).BeginInit();
            SuspendLayout();
            // 
            // PanelPrincipal_ResumoProjetos
            // 
            PanelPrincipal_ResumoProjetos.Controls.Add(BtnExtrair);
            PanelPrincipal_ResumoProjetos.Controls.Add(label1);
            PanelPrincipal_ResumoProjetos.Controls.Add(CboTipoProjeto);
            PanelPrincipal_ResumoProjetos.Controls.Add(LbQtdProjetos);
            PanelPrincipal_ResumoProjetos.Controls.Add(label4);
            PanelPrincipal_ResumoProjetos.Controls.Add(CboBairro);
            PanelPrincipal_ResumoProjetos.Controls.Add(label3);
            PanelPrincipal_ResumoProjetos.Controls.Add(GridDadosGeral);
            PanelPrincipal_ResumoProjetos.Controls.Add(label2);
            PanelPrincipal_ResumoProjetos.Controls.Add(CboEstado);
            PanelPrincipal_ResumoProjetos.Dock = DockStyle.Fill;
            PanelPrincipal_ResumoProjetos.Location = new Point(0, 0);
            PanelPrincipal_ResumoProjetos.Name = "PanelPrincipal_ResumoProjetos";
            PanelPrincipal_ResumoProjetos.Size = new Size(1124, 465);
            PanelPrincipal_ResumoProjetos.TabIndex = 0;
            // 
            // BtnExtrair
            // 
            BtnExtrair.Enabled = false;
            BtnExtrair.Location = new Point(623, 68);
            BtnExtrair.Name = "BtnExtrair";
            BtnExtrair.Size = new Size(107, 23);
            BtnExtrair.TabIndex = 22;
            BtnExtrair.Text = "Extrair Dados";
            BtnExtrair.UseVisualStyleBackColor = true;
            BtnExtrair.Visible = false;
            BtnExtrair.Click += BtnExtrair_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 49);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 21;
            label1.Text = "Tipo de Projeto";
            // 
            // CboTipoProjeto
            // 
            CboTipoProjeto.FormattingEnabled = true;
            CboTipoProjeto.Items.AddRange(new object[] { "Todos", "Sou Colaborador", "Sou Voluntário" });
            CboTipoProjeto.Location = new Point(12, 68);
            CboTipoProjeto.Name = "CboTipoProjeto";
            CboTipoProjeto.Size = new Size(172, 23);
            CboTipoProjeto.TabIndex = 20;
            CboTipoProjeto.SelectedIndexChanged += CboTipoProjeto_SelectedIndexChanged;
            // 
            // LbQtdProjetos
            // 
            LbQtdProjetos.AutoSize = true;
            LbQtdProjetos.Location = new Point(162, 27);
            LbQtdProjetos.Name = "LbQtdProjetos";
            LbQtdProjetos.Size = new Size(12, 15);
            LbQtdProjetos.TabIndex = 19;
            LbQtdProjetos.Text = "-";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(423, 50);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 18;
            label4.Text = "Bairro";
            // 
            // CboBairro
            // 
            CboBairro.FormattingEnabled = true;
            CboBairro.Location = new Point(421, 68);
            CboBairro.Name = "CboBairro";
            CboBairro.Size = new Size(172, 23);
            CboBairro.TabIndex = 17;
            CboBairro.SelectedIndexChanged += CboBairro_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(192, 50);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 16;
            label3.Text = "Estado";
            // 
            // GridDadosGeral
            // 
            GridDadosGeral.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridDadosGeral.Location = new Point(12, 95);
            GridDadosGeral.Name = "GridDadosGeral";
            GridDadosGeral.Size = new Size(1100, 358);
            GridDadosGeral.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 27);
            label2.Name = "label2";
            label2.Size = new Size(139, 15);
            label2.TabIndex = 14;
            label2.Text = "Projetos em Andamento:";
            // 
            // CboEstado
            // 
            CboEstado.FormattingEnabled = true;
            CboEstado.Location = new Point(190, 68);
            CboEstado.Name = "CboEstado";
            CboEstado.Size = new Size(225, 23);
            CboEstado.TabIndex = 13;
            CboEstado.SelectedIndexChanged += CboEstado_SelectedIndexChanged;
            // 
            // resumoProjetos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1124, 465);
            Controls.Add(PanelPrincipal_ResumoProjetos);
            FormBorderStyle = FormBorderStyle.None;
            Name = "resumoProjetos";
            Text = "resumoProjetos";
            PanelPrincipal_ResumoProjetos.ResumeLayout(false);
            PanelPrincipal_ResumoProjetos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)GridDadosGeral).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelPrincipal_ResumoProjetos;
        private Label LbQtdProjetos;
        private Label label4;
        private ComboBox CboBairro;
        private Label label3;
        private DataGridView GridDadosGeral;
        private Label label2;
        private ComboBox CboEstado;
        private Label label1;
        private ComboBox CboTipoProjeto;
        private Button BtnExtrair;
    }
}