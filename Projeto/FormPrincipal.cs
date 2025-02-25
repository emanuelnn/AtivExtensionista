using System.Runtime.InteropServices;
using Timer = System.Windows.Forms.Timer;
using CONECTA.Classes;


namespace CONECTA
{
    public partial class FormPrincipal : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        private Rectangle previousBounds;
        private bool isMaximizedAdjusted = false;
        public int userID = 0;

        #region funções ligadas ao formulário principal
        public FormPrincipal()
        {
            InitializeComponent();
            clsConnect.CriarBancoSQLite();
            clsConnect.CriarTabelasSQLite();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Load += new EventHandler(FormPrincipal_Load);
            this.MouseDown += new MouseEventHandler(PanelTop_MouseDown);
            PMenu_Left.Width = 0;
            AbrirLogin();

        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            base.OnResize(e);
            ArredondarBorda(20);
            PMenu_Left.Width = 0;
            PanelTop.Width = 0;

            IntPtr region = CreateRoundRectRgn(0, 0, this.Width, this.Height, 30, 30);
            if (region != IntPtr.Zero)
            {
                SetWindowRgn(this.Handle, region, true);
                DeleteObject(region);
            }

        }

        private void ArredondarBorda(int raio)
        {
            IntPtr hRgn = CreateRoundRectRgn(0, 0, Width, Height, raio, raio);
            SetWindowRgn(Handle, hRgn, true);
        }

        #endregion

        #region Funções ligadas ao usuario

        private void AbrirLogin()
        {
            login login = new login(this);
            login.TopLevel = false;
            login.FormBorderStyle = FormBorderStyle.None;
            login.Dock = DockStyle.Fill;
            PanelMain.Controls.Clear();
            PanelMain.Controls.Add(login);
            login.Show();
        }

        public void usuarioLogado(string cpfUsuario)
        {
            expandirMenu();
            LbBenvindo.Visible = true;
            LbUsuarioLogado.Text = clsConnect.GetValor($"select caus_nome from cadastro_usuario where caus_cpf = '{cpfUsuario}'", "caus_nome");
            userID = int.Parse(clsConnect.GetValor($"select caus_pk from cadastro_usuario where caus_cpf = '{cpfUsuario}'", "caus_pk"));
            LbUsuarioLogado.Visible = true;

            resumoProjetos form = new resumoProjetos(userID);
            AbrirPagina(form);
        }

        #endregion

        #region Configurações e ações da tela
        private void PanelTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        public void AbrirPagina(Form formulario)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                PanelMain.Controls.Clear();

                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;

                PanelMain.Controls.Add(formulario);

                formulario.Show();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception iex)
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void PicClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PicMax_Click(object sender, EventArgs e)
        {
            if (isMaximizedAdjusted)
            {
                this.Bounds = previousBounds;
                isMaximizedAdjusted = false;
                ArredondarBorda(20);
            }
            else
            {
                previousBounds = this.Bounds;

                Rectangle workingArea = Screen.GetWorkingArea(this);
                this.Location = workingArea.Location;
                this.Size = workingArea.Size;
                ArredondarBorda(0);
                isMaximizedAdjusted = true;
            }
        }

        private void PicMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region DLLs e Outros

        [DllImport("gdi32.dll", SetLastError = true)]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);

        [DllImport("gdi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DeleteObject(IntPtr hObject);

        [DllImport("user32.dll")]
        private static extern void ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        #endregion

        #region Funções ligadas ao menu
        public void expandirMenu()
        {
            Timer timer = new Timer();
            timer.Interval = 10;
            int step = 10;
            int expandedWidth = 240;
            int collapsedWidth = 60;

            bool isExpanding = PMenu_Left.Width == collapsedWidth;

            timer.Tick += (envio, args) =>
            {
                if (isExpanding)
                {
                    // Expandindo
                    if (PMenu_Left.Width < expandedWidth)
                    {
                        PMenu_Left.Width += step;
                    }
                    else
                    {
                        PMenu_Left.Width = expandedWidth;
                        timer.Stop();
                    }
                }
                else
                {
                    // Recolhendo
                    if (PMenu_Left.Width > collapsedWidth)
                    {
                        PMenu_Left.Width -= step;
                    }
                    else
                    {
                        PMenu_Left.Width = collapsedWidth;
                        timer.Stop();
                    }

                    if (PMenu_Left.Width < collapsedWidth)
                    {
                        PMenu_Left.Width += step;
                    }
                }
            };

            timer.Start();
        }


        #region botões do menu
        private void PicExpMenu_Click(object sender, EventArgs e)
        {
            expandirMenu();
        }
        #endregion


        #endregion

        #region Clique (Botões / Imagens)

        private void PicHome_Click(object sender, EventArgs e)
        {
            resumoProjetos form = new resumoProjetos(userID);
            AbrirPagina(form);
        }

        private void PicRegistrar_Click(object sender, EventArgs e)
        {
            projetos Form = new projetos(userID);
            AbrirPagina(Form);
        }

        private void PicConfig_Click(object sender, EventArgs e)
        {
            GestaoUsuarios Form = new GestaoUsuarios(userID);
            AbrirPagina(Form);
        }

        #endregion

    }
}
