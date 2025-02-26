using CONECTA.Classes;
using System.Data;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Text;

namespace CONECTA
{
    public partial class login : Form
    {

        #region DLLs
        [DllImport("gdi32.dll", SetLastError = true)]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        #endregion

        string usuario = "";
        string permissao = "";
        private FormPrincipal _formPrincipal;

        #region funções ligadas ao formulário
        public login(FormPrincipal formPrincipal)
        {
            _formPrincipal = formPrincipal;
            InitializeComponent();
            ArredondarBordas_TextBox(TextCpf, 20);
            ArredondarBordas_TextBox(TextSenha, 20);
        }

        private void ArredondarBorda(int raio)
        {
            IntPtr hRgn = CreateRoundRectRgn(0, 0, Width, Height, raio, raio);
            SetWindowRgn(Handle, hRgn, true);
        }

        #endregion


        private void BtnLogin_Click(object sender, EventArgs e)
        {
            verificarLogin();
        }

        #region funções


        private string obterID()
        {
            string nomeComputador = Environment.UserName;
            return nomeComputador;
        }
        private void ArredondarBordas_TextBox(TextBox campo, int radius)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(campo.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(campo.Width - radius, campo.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, campo.Height - radius, radius, radius, 90, 90);
                path.CloseFigure();

                campo.Region = new Region(path);
            }
        }

        #endregion

        #region Manipulação de Usuário
        /*Novo Usuário*/

        private void verificarLogin()
        {
            string cpf = TextCpf.Text.Trim();

            cpf = new string(cpf.Normalize(NormalizationForm.FormD)
                                .Where(c => char.IsDigit(c))
                                .ToArray());
            if (cpf.Length != 11)
            {
                MessageBox.Show("CPF inválido! O CPF deve ter 11 dígitos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string userID = cpf;
            string userPassword = TextSenha.Text.Trim();

            if (userID.Length < 8)
            {
                MessageBox.Show("Preencha seu ID conforme indicado no Crachá: (Exemplo: '00123456')", "AVISO");
                return;
            }

            if (string.IsNullOrEmpty(userID))
            {
                MessageBox.Show("Preencha o Campo ID!", "Erro");
                return;
            }

            if (string.IsNullOrEmpty(userPassword))
            {
                MessageBox.Show("Preencha o Campo Senha!", "Erro");
                return;
            }

            string permissao = validarUsuario(userID, userPassword);

            if (string.IsNullOrEmpty(permissao))
            {
                MessageBox.Show("Usuário ou senha incorretos!", "Erro");
                return;
            }

            _formPrincipal.usuarioLogado(userID);
            this.Close();
        }

        private string validarUsuario(string cpf, string senha)
        {
            string resultado = string.Empty;

            cpf = new string(cpf.Normalize(NormalizationForm.FormD)
                                .Where(c => char.IsDigit(c))
                                .ToArray());

            Console.WriteLine(cpf.Length);
            if (cpf.Length != 11)
            {
                MessageBox.Show("CPF inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }


            resultado = clsConnect.GetValor($"select caus_senha from cadastro_usuario where caus_cpf = '{cpf}'", "caus_senha");


            Console.WriteLine(resultado);
            if (string.IsNullOrEmpty(resultado))
            {
                MessageBox.Show("Usuário não foi localizado!", "ERRO");
                return string.Empty;
            }

            if (clsConnect.DescriptografarSenha(resultado) == TextSenha.Text)
            {
                resultado = clsConnect.GetValor($"select caus_perfil from cadastro_usuario where caus_cpf = '{cpf}'", "caus_perfil");
            }
            else
            {
                resultado = string.Empty;
            }

            return resultado;
        }

        #endregion

        private void LbCadastrese_Click(object sender, EventArgs e)
        {
            LbCadastrese.Visible = false;
            PanelCadastro.Visible = true;
        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            string cpf = TextCpf.Text;

            cpf = new string(cpf.Normalize(NormalizationForm.FormD)
                                .Where(c => char.IsDigit(c))
                                .ToArray());

            Console.WriteLine(cpf.Length);
            if (cpf.Length != 11)
            {
                MessageBox.Show("CPF inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(TextSenha.Text.Length < 10)
            {
                MessageBox.Show("Sua senha deve conter ao menos 10 caracteres!");
                return;
            }

            if (TextNome.Text.Length < 5)
            {
                MessageBox.Show("É obrigatório informar um nome!");
                return;
            }

            if (TextNome.Text.Length < 5)
            {
                MessageBox.Show("É obrigatório informar um nome!");
                return;
            }

            try
            {
                if (cpf.Length != 11)
                {
                    MessageBox.Show("CPF inválido! O CPF deve ter 11 dígitos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    clsConnect.NovoUsuario(TextNome.Text, cpf, TextCep.Text, TextEstado.Text, TextBairro.Text, TextNumero.Text, TextEndereco.Text, "PERFIL", TextSenha.Text, TextTelefone.Text);
                    MessageBox.Show($"Cadastrado com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LbCadastrese.Visible = true;
                    PanelCadastro.Visible = false;
                }
            }
            catch (Exception iex)
            {
                MessageBox.Show($"Erro ao criar usuario:{iex.Message}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TextNome_TextChanged(object sender, EventArgs e)
        {
            if (TextNome.Text.Length > 30)
            {
                int posicaoAtual = TextNome.SelectionStart;
                TextNome.Text = TextNome.Text.Substring(0, 30);
                TextNome.SelectionStart = Math.Min(posicaoAtual, 30);
            }
        }
    }
}
