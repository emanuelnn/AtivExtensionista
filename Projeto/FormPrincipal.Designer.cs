namespace CONECTA
{
    partial class FormPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            PanelTop = new Panel();
            LbUsuarioLogado = new Label();
            LbBenvindo = new Label();
            panel1 = new Panel();
            PicMin = new PictureBox();
            PicMax = new PictureBox();
            PicClose = new PictureBox();
            PMenu_Left = new Panel();
            LbProjeto = new Label();
            LbInicio = new Label();
            PicConfig = new PictureBox();
            PicRegistrar = new PictureBox();
            PicHome = new PictureBox();
            PicExpMenu = new PictureBox();
            PanelMain = new Panel();
            label1 = new Label();
            PanelTop.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PicMin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PicMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PicClose).BeginInit();
            PMenu_Left.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PicConfig).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PicRegistrar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PicHome).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PicExpMenu).BeginInit();
            SuspendLayout();
            // 
            // PanelTop
            // 
            PanelTop.BackColor = Color.FromArgb(55, 63, 81);
            PanelTop.Controls.Add(LbUsuarioLogado);
            PanelTop.Controls.Add(LbBenvindo);
            PanelTop.Controls.Add(panel1);
            PanelTop.Dock = DockStyle.Top;
            PanelTop.Location = new Point(60, 0);
            PanelTop.Name = "PanelTop";
            PanelTop.Size = new Size(1140, 46);
            PanelTop.TabIndex = 4;
            PanelTop.MouseDown += PanelTop_MouseDown;
            // 
            // LbUsuarioLogado
            // 
            LbUsuarioLogado.AutoSize = true;
            LbUsuarioLogado.ForeColor = Color.White;
            LbUsuarioLogado.Location = new Point(18, 22);
            LbUsuarioLogado.Name = "LbUsuarioLogado";
            LbUsuarioLogado.Size = new Size(12, 15);
            LbUsuarioLogado.TabIndex = 2;
            LbUsuarioLogado.Text = "-";
            LbUsuarioLogado.Visible = false;
            // 
            // LbBenvindo
            // 
            LbBenvindo.AutoSize = true;
            LbBenvindo.ForeColor = Color.White;
            LbBenvindo.Location = new Point(18, 3);
            LbBenvindo.Name = "LbBenvindo";
            LbBenvindo.Size = new Size(79, 15);
            LbBenvindo.TabIndex = 1;
            LbBenvindo.Text = "Bem Vindo(a)";
            LbBenvindo.Visible = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(PicMin);
            panel1.Controls.Add(PicMax);
            panel1.Controls.Add(PicClose);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(1017, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(123, 46);
            panel1.TabIndex = 0;
            // 
            // PicMin
            // 
            PicMin.Image = (Image)resources.GetObject("PicMin.Image");
            PicMin.Location = new Point(11, 12);
            PicMin.Name = "PicMin";
            PicMin.Size = new Size(25, 25);
            PicMin.SizeMode = PictureBoxSizeMode.StretchImage;
            PicMin.TabIndex = 2;
            PicMin.TabStop = false;
            PicMin.Click += PicMin_Click;
            // 
            // PicMax
            // 
            PicMax.Image = (Image)resources.GetObject("PicMax.Image");
            PicMax.Location = new Point(50, 12);
            PicMax.Name = "PicMax";
            PicMax.Size = new Size(25, 25);
            PicMax.SizeMode = PictureBoxSizeMode.StretchImage;
            PicMax.TabIndex = 1;
            PicMax.TabStop = false;
            PicMax.Click += PicMax_Click;
            // 
            // PicClose
            // 
            PicClose.Image = (Image)resources.GetObject("PicClose.Image");
            PicClose.Location = new Point(89, 12);
            PicClose.Name = "PicClose";
            PicClose.Size = new Size(25, 25);
            PicClose.SizeMode = PictureBoxSizeMode.StretchImage;
            PicClose.TabIndex = 0;
            PicClose.TabStop = false;
            PicClose.Click += PicClose_Click;
            // 
            // PMenu_Left
            // 
            PMenu_Left.BackColor = Color.FromArgb(55, 63, 81);
            PMenu_Left.Controls.Add(label1);
            PMenu_Left.Controls.Add(LbProjeto);
            PMenu_Left.Controls.Add(LbInicio);
            PMenu_Left.Controls.Add(PicConfig);
            PMenu_Left.Controls.Add(PicRegistrar);
            PMenu_Left.Controls.Add(PicHome);
            PMenu_Left.Controls.Add(PicExpMenu);
            PMenu_Left.Dock = DockStyle.Left;
            PMenu_Left.Location = new Point(0, 0);
            PMenu_Left.Name = "PMenu_Left";
            PMenu_Left.Size = new Size(60, 550);
            PMenu_Left.TabIndex = 3;
            // 
            // LbProjeto
            // 
            LbProjeto.AutoSize = true;
            LbProjeto.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LbProjeto.ForeColor = Color.White;
            LbProjeto.Location = new Point(58, 195);
            LbProjeto.Name = "LbProjeto";
            LbProjeto.Size = new Size(125, 19);
            LbProjeto.TabIndex = 10;
            LbProjeto.Text = "Registrar Projeto";
            // 
            // LbInicio
            // 
            LbInicio.AutoSize = true;
            LbInicio.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LbInicio.ForeColor = Color.White;
            LbInicio.Location = new Point(58, 128);
            LbInicio.Name = "LbInicio";
            LbInicio.Size = new Size(99, 19);
            LbInicio.TabIndex = 9;
            LbInicio.Text = "Página Inicial";
            // 
            // PicConfig
            // 
            PicConfig.Image = (Image)resources.GetObject("PicConfig.Image");
            PicConfig.Location = new Point(12, 498);
            PicConfig.Name = "PicConfig";
            PicConfig.Size = new Size(40, 40);
            PicConfig.SizeMode = PictureBoxSizeMode.StretchImage;
            PicConfig.TabIndex = 8;
            PicConfig.TabStop = false;
            PicConfig.Click += PicConfig_Click;
            // 
            // PicRegistrar
            // 
            PicRegistrar.Image = (Image)resources.GetObject("PicRegistrar.Image");
            PicRegistrar.Location = new Point(12, 185);
            PicRegistrar.Name = "PicRegistrar";
            PicRegistrar.Size = new Size(40, 40);
            PicRegistrar.SizeMode = PictureBoxSizeMode.StretchImage;
            PicRegistrar.TabIndex = 5;
            PicRegistrar.TabStop = false;
            PicRegistrar.Click += PicRegistrar_Click;
            // 
            // PicHome
            // 
            PicHome.Image = (Image)resources.GetObject("PicHome.Image");
            PicHome.Location = new Point(12, 113);
            PicHome.Name = "PicHome";
            PicHome.Size = new Size(40, 40);
            PicHome.SizeMode = PictureBoxSizeMode.StretchImage;
            PicHome.TabIndex = 4;
            PicHome.TabStop = false;
            PicHome.Click += PicHome_Click;
            // 
            // PicExpMenu
            // 
            PicExpMenu.Image = (Image)resources.GetObject("PicExpMenu.Image");
            PicExpMenu.Location = new Point(12, 3);
            PicExpMenu.Name = "PicExpMenu";
            PicExpMenu.Size = new Size(40, 40);
            PicExpMenu.SizeMode = PictureBoxSizeMode.StretchImage;
            PicExpMenu.TabIndex = 3;
            PicExpMenu.TabStop = false;
            PicExpMenu.Click += PicExpMenu_Click;
            // 
            // PanelMain
            // 
            PanelMain.BackColor = Color.FromArgb(255, 250, 255);
            PanelMain.Dock = DockStyle.Fill;
            PanelMain.Location = new Point(60, 46);
            PanelMain.Name = "PanelMain";
            PanelMain.Size = new Size(1140, 504);
            PanelMain.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(58, 510);
            label1.Name = "label1";
            label1.Size = new Size(123, 19);
            label1.TabIndex = 11;
            label1.Text = "Perfil do Usuário";
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 550);
            Controls.Add(PanelMain);
            Controls.Add(PanelTop);
            Controls.Add(PMenu_Left);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CONECTA";
            Load += FormPrincipal_Load;
            PanelTop.ResumeLayout(false);
            PanelTop.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PicMin).EndInit();
            ((System.ComponentModel.ISupportInitialize)PicMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)PicClose).EndInit();
            PMenu_Left.ResumeLayout(false);
            PMenu_Left.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PicConfig).EndInit();
            ((System.ComponentModel.ISupportInitialize)PicRegistrar).EndInit();
            ((System.ComponentModel.ISupportInitialize)PicHome).EndInit();
            ((System.ComponentModel.ISupportInitialize)PicExpMenu).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelTop;
        private Panel PMenu_Left;
        private Panel panel1;
        private PictureBox PicMin;
        private PictureBox PicMax;
        private PictureBox PicClose;
        private PictureBox PicExpMenu;
        private PictureBox PicConfig;
        private PictureBox pictureBox4;
        private PictureBox PicRegistrar;
        private PictureBox PicHome;
        private Label LbProjeto;
        private Label LbInicio;
        private Label LbBenvindo;
        private Label LbUsuarioLogado;
        private Panel PanelMain;
        private Label label1;
    }
}
