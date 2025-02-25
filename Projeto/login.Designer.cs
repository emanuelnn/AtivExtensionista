namespace CONECTA
{
    partial class login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            TextCpf = new TextBox();
            TextSenha = new TextBox();
            LbLogin = new Label();
            label1 = new Label();
            BtnLogin = new Button();
            LbCadastrese = new Label();
            PanelCadastro = new Panel();
            label7 = new Label();
            TextEndereco = new TextBox();
            LbCadNome = new Label();
            TextNome = new TextBox();
            label5 = new Label();
            TextCep = new TextBox();
            label4 = new Label();
            TextEstado = new TextBox();
            BtnCadastrar = new Button();
            label2 = new Label();
            label3 = new Label();
            TextNumero = new TextBox();
            TextBairro = new TextBox();
            label6 = new Label();
            TextTelefone = new TextBox();
            PanelCadastro.SuspendLayout();
            SuspendLayout();
            // 
            // TextCpf
            // 
            TextCpf.Location = new Point(515, 10);
            TextCpf.Name = "TextCpf";
            TextCpf.Size = new Size(197, 23);
            TextCpf.TabIndex = 0;
            // 
            // TextSenha
            // 
            TextSenha.Location = new Point(515, 39);
            TextSenha.Name = "TextSenha";
            TextSenha.Size = new Size(197, 23);
            TextSenha.TabIndex = 1;
            // 
            // LbLogin
            // 
            LbLogin.AutoSize = true;
            LbLogin.BackColor = Color.Transparent;
            LbLogin.Location = new Point(482, 14);
            LbLogin.Name = "LbLogin";
            LbLogin.Size = new Size(31, 15);
            LbLogin.TabIndex = 2;
            LbLogin.Text = "CPF:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(471, 43);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 3;
            label1.Text = "Senha:";
            // 
            // BtnLogin
            // 
            BtnLogin.Location = new Point(721, 24);
            BtnLogin.Name = "BtnLogin";
            BtnLogin.Size = new Size(75, 23);
            BtnLogin.TabIndex = 4;
            BtnLogin.Text = "Login";
            BtnLogin.UseVisualStyleBackColor = true;
            BtnLogin.Click += BtnLogin_Click;
            // 
            // LbCadastrese
            // 
            LbCadastrese.AutoSize = true;
            LbCadastrese.BackColor = Color.Transparent;
            LbCadastrese.Location = new Point(500, 65);
            LbCadastrese.Name = "LbCadastrese";
            LbCadastrese.Size = new Size(225, 15);
            LbCadastrese.TabIndex = 20;
            LbCadastrese.Text = "Não possui uma conta? Cadastre-se aqui!";
            LbCadastrese.Click += LbCadastrese_Click;
            // 
            // PanelCadastro
            // 
            PanelCadastro.BackColor = Color.Transparent;
            PanelCadastro.Controls.Add(label6);
            PanelCadastro.Controls.Add(TextTelefone);
            PanelCadastro.Controls.Add(label7);
            PanelCadastro.Controls.Add(TextEndereco);
            PanelCadastro.Controls.Add(LbCadNome);
            PanelCadastro.Controls.Add(TextNome);
            PanelCadastro.Controls.Add(label5);
            PanelCadastro.Controls.Add(TextCep);
            PanelCadastro.Controls.Add(label4);
            PanelCadastro.Controls.Add(TextEstado);
            PanelCadastro.Controls.Add(BtnCadastrar);
            PanelCadastro.Controls.Add(label2);
            PanelCadastro.Controls.Add(label3);
            PanelCadastro.Controls.Add(TextNumero);
            PanelCadastro.Controls.Add(TextBairro);
            PanelCadastro.Location = new Point(419, 83);
            PanelCadastro.Name = "PanelCadastro";
            PanelCadastro.Size = new Size(317, 255);
            PanelCadastro.TabIndex = 21;
            PanelCadastro.Visible = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Location = new Point(30, 155);
            label7.Name = "label7";
            label7.Size = new Size(59, 15);
            label7.TabIndex = 32;
            label7.Text = "Endereço:";
            // 
            // TextEndereco
            // 
            TextEndereco.Location = new Point(96, 152);
            TextEndereco.Name = "TextEndereco";
            TextEndereco.Size = new Size(197, 23);
            TextEndereco.TabIndex = 7;
            // 
            // LbCadNome
            // 
            LbCadNome.AutoSize = true;
            LbCadNome.BackColor = Color.Transparent;
            LbCadNome.Location = new Point(46, 10);
            LbCadNome.Name = "LbCadNome";
            LbCadNome.Size = new Size(43, 15);
            LbCadNome.TabIndex = 30;
            LbCadNome.Text = "Nome:";
            // 
            // TextNome
            // 
            TextNome.Location = new Point(96, 7);
            TextNome.Name = "TextNome";
            TextNome.Size = new Size(197, 23);
            TextNome.TabIndex = 2;
            TextNome.TextChanged += TextNome_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Location = new Point(58, 39);
            label5.Name = "label5";
            label5.Size = new Size(31, 15);
            label5.TabIndex = 28;
            label5.Text = "CEP:";
            // 
            // TextCep
            // 
            TextCep.Location = new Point(96, 36);
            TextCep.Name = "TextCep";
            TextCep.Size = new Size(197, 23);
            TextCep.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Location = new Point(44, 68);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 26;
            label4.Text = "Estado:";
            // 
            // TextEstado
            // 
            TextEstado.Location = new Point(96, 65);
            TextEstado.Name = "TextEstado";
            TextEstado.Size = new Size(197, 23);
            TextEstado.TabIndex = 4;
            // 
            // BtnCadastrar
            // 
            BtnCadastrar.Location = new Point(100, 214);
            BtnCadastrar.Name = "BtnCadastrar";
            BtnCadastrar.Size = new Size(118, 23);
            BtnCadastrar.TabIndex = 8;
            BtnCadastrar.Text = "Cadastrar-se";
            BtnCadastrar.UseVisualStyleBackColor = true;
            BtnCadastrar.Click += BtnCadastrar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(35, 126);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 23;
            label2.Text = "Numero:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Location = new Point(48, 97);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 22;
            label3.Text = "Bairro:";
            // 
            // TextNumero
            // 
            TextNumero.Location = new Point(96, 123);
            TextNumero.Name = "TextNumero";
            TextNumero.Size = new Size(197, 23);
            TextNumero.TabIndex = 6;
            // 
            // TextBairro
            // 
            TextBairro.Location = new Point(96, 94);
            TextBairro.Name = "TextBairro";
            TextBairro.Size = new Size(197, 23);
            TextBairro.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Location = new Point(2, 181);
            label6.Name = "label6";
            label6.Size = new Size(88, 15);
            label6.TabIndex = 34;
            label6.Text = "Telefone/Email:";
            // 
            // TextTelefone
            // 
            TextTelefone.Location = new Point(96, 178);
            TextTelefone.Name = "TextTelefone";
            TextTelefone.Size = new Size(197, 23);
            TextTelefone.TabIndex = 33;
            // 
            // login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Sienna;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1140, 504);
            Controls.Add(PanelCadastro);
            Controls.Add(LbCadastrese);
            Controls.Add(BtnLogin);
            Controls.Add(label1);
            Controls.Add(LbLogin);
            Controls.Add(TextSenha);
            Controls.Add(TextCpf);
            FormBorderStyle = FormBorderStyle.None;
            Name = "login";
            Text = "Login";
            PanelCadastro.ResumeLayout(false);
            PanelCadastro.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TextCpf;
        private TextBox TextSenha;
        private Label LbLogin;
        private Label label1;
        private Button BtnLogin;
        private PictureBox PicBackgroundLogin;
        private Label LbCadastrese;
        private Panel PanelCadastro;
        private Label label7;
        private TextBox TextEndereco;
        private Label LbCadNome;
        private TextBox TextNome;
        private Label label5;
        private TextBox TextCep;
        private Label label4;
        private TextBox TextEstado;
        private Button BtnCadastrar;
        private Label label2;
        private Label label3;
        private TextBox TextNumero;
        private TextBox TextBairro;
        private Label label6;
        private TextBox TextTelefone;
    }
}
