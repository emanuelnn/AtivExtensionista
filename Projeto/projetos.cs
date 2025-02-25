using CONECTA.Classes;
using System.Data;
using System.Runtime.InteropServices;
using System.Globalization;
using ClosedXML.Excel;
using System;
using System.Diagnostics;
using System.IO;

namespace CONECTA
{
    public partial class projetos : Form
    {
        string usuario = "";
        string permissaoNoProjeto = "";
        private FormPrincipal _formPrincipal;
        int identificacaoUsuario = 0;
        static int registroAtual = 0;
        bool verifColaborador = false;
        bool verifParticipante = false;
        bool verifAutorProjeto = false;
        bool verifModerador = false;
        DateTime dataFinal;
        bool statusProjetoAberto = false;

        #region DLLs

        [DllImport("gdi32.dll", SetLastError = true)]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        #endregion

        #region funções ligadas ao formulário
        public projetos(int userKey)
        {
            identificacaoUsuario = userKey;
            InitializeComponent();
            DataFinalProjeto.CustomFormat = "dd/MM/yyyy";
            DataInicioProjeto.CustomFormat = "dd/MM/yyyy";

            verifModerador = clsConnect.GetValor($"Select caus_perfil from cadastro_usuario where caus_perfil   = {identificacaoUsuario}", "caus_perfil") != "" ? true : false;
        }

        private void projetos_Load(object sender, EventArgs e)
        {
            carregarComboProjetos();
            clsConnect.PreencherComboEstados(ComboEstados);
        }

        #endregion

        #region Funções Gerais

        private void CopiarArquivosParaProjeto()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Selecione os arquivos para anexar";
                openFileDialog.Multiselect = true;
                openFileDialog.Filter = "Todos os arquivos (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string pastaDestino = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "attachments", $"PROJ-{registroAtual}");

                    if (!Directory.Exists(pastaDestino))
                    {
                        Directory.CreateDirectory(pastaDestino);
                    }

                    foreach (string arquivo in openFileDialog.FileNames)
                    {
                        string nomeArquivo = Path.GetFileName(arquivo);
                        string caminhoDestino = Path.Combine(pastaDestino, nomeArquivo);

                        try
                        {
                            File.Copy(arquivo, caminhoDestino, true);
                            MessageBox.Show($"Arquivo copiado: {nomeArquivo}", "Sucesso");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Erro ao copiar {nomeArquivo}: {ex.Message}", "Erro");
                        }
                    }
                }
            }
            ListarArquivosNoGrid();
        }

        private int obterProjeto()
        {
            string projeto = CboProjetos.Text;

            int posicao = projeto.IndexOf(";");

            if (posicao > 0)
            {
                projeto = projeto.Substring(0, posicao);

                if (!string.IsNullOrEmpty(projeto))
                {
                    return int.Parse(projeto);
                }
            }

            return 0;

        }

        private void limparCampos()
        {
            CboTipo.Text = "";
            TextTitulo.Text = "";
            TextDescricao.Text = "";
            DataInicioProjeto.Text = "";
            DataFinalProjeto.Text = "";
            TextComplemento.Text = "";
            TextNumero.Text = "";
            TextBairro.Text = "";
            ComboEstados.Text = "";
            registroAtual = 0;
            permissaoNoProjeto = "";
            CboProjetos.Text = "";

            verifColaborador = false;
            verifParticipante = false;
            verifAutorProjeto = false;
            verifModerador = false;

            GridColaboradores.DataSource = null;
            GridParticipantes.DataSource = null;
            GridAnexos.DataSource = null;

            if (GridColaboradores != null)
                GridColaboradores.Rows.Clear();

            if (GridParticipantes != null)
                GridParticipantes.Rows.Clear();

            if (GridAnexos != null)
                GridAnexos.Rows.Clear();
            statusCampos(false);
        }

        private void selecionarProjeto()
        {
            CboProjetos.Enabled = true;
            BtnSalvar.Enabled = false;
            statusCampos(false);
            carregarComboProjetos();
        }

        #endregion

        #region Carregamento de dados

        private void carregarProjeto(int chaveProjeto)
        {
            DataTable m_Data = new DataTable();

            m_Data = clsConnect.GetDados($"select * from cadastro_projeto where capr_pk = {chaveProjeto}");

            CboTipo.Text = m_Data.Rows[0]["capr_tipo_projeto"]?.ToString();
            TextTitulo.Text = m_Data.Rows[0]["capr_titulo"]?.ToString();
            TextDescricao.Text = m_Data.Rows[0]["capr_descricao"]?.ToString();
            DataInicioProjeto.Text = m_Data.Rows[0]["capr_data_inicio"]?.ToString();
            DataFinalProjeto.Text = m_Data.Rows[0]["capr_data_fim"]?.ToString();
            TextComplemento.Text = m_Data.Rows[0]["capr_endereco"]?.ToString();
            TextNumero.Text = m_Data.Rows[0]["capr_numero"]?.ToString();
            TextBairro.Text = m_Data.Rows[0]["capr_bairro"]?.ToString();

            ComboEstados.DropDownStyle = ComboBoxStyle.Simple;
            ComboEstados.Text = m_Data.Rows[0]["capr_estado"]?.ToString();

            DateTime.TryParseExact(DataFinalProjeto.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataFinal);
            dataFinal = DataFinalProjeto.Value;
            statusProjetoAberto = (dataFinal >= DateTime.Today);
            string autor = clsConnect.GetValor($"Select capr_autor from cadastro_projeto where capr_pk = {registroAtual}", "capr_autor");
            verifAutorProjeto = autor == identificacaoUsuario.ToString() ? true : false;
            LbAutorProjeto.Text = clsConnect.GetValor($"select caus_nome from cadastro_usuario a left join cadastro_projeto b on b.capr_caus_fk = a.caus_pk", "caus_nome");
            verifColaborador = clsConnect.GetValor($"Select prco_pk from projeto_colaboradores where prco_caus_fk = {identificacaoUsuario} and prco_capr_fk = {registroAtual} and prco_status = 'COLABORADOR'", "prco_pk") != "" ? true : false;
            verifParticipante = clsConnect.GetValor($"Select prco_pk from projeto_colaboradores where prco_caus_fk = {identificacaoUsuario} and prco_capr_fk = {registroAtual} and prco_status = 'PARTICIPANTE'", "prco_pk") != "" ? true : false;

            carregarGridColab();
            carregarParticipantes();
            carregarComboUsuarios();
            ListarArquivosNoGrid();
            permissoes();
        }

        #region Combos
        private void carregarComboProjetos()
        {
            DataTable m_Data = new DataTable();
            CboProjetos.Items.Clear();
            m_Data = clsConnect.GetDados("SELECT capr_pk || ';' || capr_titulo || ' (' || CASE " +
                                            " WHEN date(substr(capr_data_fim,7,4) || '-' || substr(capr_data_fim,4,2) || '-' || substr(capr_data_fim,1,2)) >= date('now') THEN 'Em Andamento' " +
                                            " WHEN date(substr(capr_data_fim,7,4) || '-' || substr(capr_data_fim,4,2) || '-' || substr(capr_data_fim,1,2)) < date('now') THEN 'Encerrado' " +
                                            " ELSE '' END || ')' AS Projetos " +
                                            "FROM cadastro_projeto " +
                                            "order by capr_pk desc"
                                        );




            CboProjetos.Items.Add("");
            if (m_Data.Rows.Count > 0)
            {
                for (int i = 0; i < m_Data.Rows.Count; i++)
                {
                    CboProjetos.Items.Add(m_Data.Rows[i][0]?.ToString());
                }
            }
        }

        private void carregarComboUsuarios()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                DataTable m_Data = new DataTable();
                m_Data = clsConnect.GetDados($"select distinct caus_pk ||';'|| caus_nome as Usuarios from cadastro_usuario where caus_pk <> {identificacaoUsuario}");

                CboColaboradores.Items.Clear();

                for (int i = 0; i < m_Data.Rows.Count; i++)
                {
                    CboColaboradores.Items.Add(m_Data.Rows[i]["Usuarios"].ToString());
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show($"Erro ao carregar Usuários: {ex.Message}");
            }
        }

        private void ComboEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboEstados.Text == "Online")
            {
                TextBairro.Text = "N/A";
                TextComplemento.Text = "N/A";
                TextNumero.Text = "N/A";
            }
            else
            {
                TextBairro.Text = "";
                TextComplemento.Text = "";
                TextNumero.Text = "";
            }
        }
        #endregion

        #region GRIDs
        private void carregarParticipantes()
        {
            DataTable m_Data = new DataTable();

            m_Data = clsConnect.GetDados("select b.prco_pk as [PK],b.prco_caus_fk as [User], a.caus_nome as [Participantes] from cadastro_usuario a " +
                                                                                                                     "left join projeto_colaboradores b " +
                                                                                                                            "on b.prco_caus_fk = a.caus_pk " +
                                                                                                                          $"and b.prco_capr_fk = {registroAtual} " +
                                                                                                                         "where b.prco_status  = 'PARTICIPANTE' " +
                                                                                                                         "order by a.caus_nome ");
            GridParticipantes.DataSource = m_Data;
            GridParticipantes.Columns[0].Visible = false;
            GridParticipantes.Columns[1].Visible = false;
        }

        private void carregarGridColab()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataTable m_Data = new DataTable();

                m_Data = clsConnect.GetDados("select b.prco_pk as [PK],b.prco_caus_fk as [User], a.caus_nome as [Participantes] from cadastro_usuario a " +
                                                                                                                     "left join projeto_colaboradores b " +
                                                                                                                            "on b.prco_caus_fk = a.caus_pk " +
                                                                                                                          $"and b.prco_capr_fk = {registroAtual} " +
                                                                                                                         "where b.prco_status  = 'COLABORADOR' " +
                                                                                                                         "order by a.caus_nome ");

                GridColaboradores.DataSource = m_Data;
                GridColaboradores.Columns[0].Visible = false;
                GridColaboradores.Columns[1].Visible = false;


                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show($"Erro ao carregar Grid de Colaboradores: {ex.Message}");
            }
        }

        private void ListarArquivosNoGrid()
        {
            string pastaProjeto = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "attachments", $"PROJ-{registroAtual}");

            if (!Directory.Exists(pastaProjeto))
            {
                Directory.CreateDirectory(pastaProjeto);
            }

            GridAnexos.Rows.Clear();
            GridAnexos.Columns.Clear();

            GridAnexos.Columns.Add("NomeArquivo", "Nome do Arquivo");
            GridAnexos.Columns.Add("CaminhoArquivo", "Caminho Completo");
            GridAnexos.Columns[1].Visible = false;
            GridAnexos.Columns[1].ReadOnly = true;


            try
            {
                string[] arquivos = Directory.GetFiles(pastaProjeto);
                foreach (string arquivo in arquivos)
                {
                    string nomeArquivo = Path.GetFileName(arquivo);
                    GridAnexos.Rows.Add(nomeArquivo, arquivo);
                }

                if (GridAnexos.Rows.Count == 0)
                {
                    MessageBox.Show("Nenhum arquivo encontrado no diretório!", "Aviso");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao listar arquivos: {ex.Message}", "Erro");
            }

        }

        #endregion

        #endregion

        #region Manipulação de Usuário e Permissões

        private void permissoes()
        {

            permissaoNoProjeto = verifColaborador == true ? "COLABORADOR" : "PARTICIPANTE";

            BtnSair.Enabled = ((verifColaborador || verifParticipante) && !verifAutorProjeto && statusProjetoAberto);
            BtnParticipar.Enabled = (!verifParticipante && !verifColaborador && !verifAutorProjeto && statusProjetoAberto);
            DataFinalProjeto.Enabled = (verifAutorProjeto && statusProjetoAberto); //Apenas o autor do projeto pode Alterar a data final do projeto
            CboColaboradores.Enabled = (verifAutorProjeto && statusProjetoAberto); //Apenas o autor do projeto pode adicionar novos Colaboradores
            BtnAddColab.Enabled = (verifAutorProjeto && statusProjetoAberto); //Apenas o autor do projeto pode adicionar novos Colaboradores
            BtnAddArquivo.Enabled = ((verifColaborador || verifAutorProjeto) && statusProjetoAberto);
            BtnSalvar.Enabled = (verifAutorProjeto && statusProjetoAberto); //Apenas o autor do projeto pode Salvar mudanças
            BtnExcluirProjeto.Enabled = (verifAutorProjeto && statusProjetoAberto); //Apenas o autor do projeto ou um moderador do sistema pode realziar exclusões
            BtnExtrairDados.Enabled = ((verifColaborador || verifAutorProjeto) && statusProjetoAberto);

            statusCampos(verifAutorProjeto && statusProjetoAberto);
        }

        private void statusCampos(bool status)
        {
            CboTipo.Enabled = status;
            DataInicioProjeto.Enabled = status;
            DataFinalProjeto.Enabled = status;
            TextTitulo.Enabled = (status && registroAtual == 0);
            CboTipo.Enabled = (status && registroAtual == 0);
            DataInicioProjeto.Enabled = (status && registroAtual == 0);
            TextDescricao.Enabled = status;
            ComboEstados.Enabled = (status && registroAtual == 0);
            TextBairro.Enabled = (status && registroAtual == 0);
            TextNumero.Enabled = (status && registroAtual == 0);
            TextComplemento.Enabled = (status && registroAtual == 0);
            CboColaboradores.Enabled = status;
        }

        #endregion

        #region Interações com o Projeto

        private void BtnNovoProjeto_Click(object sender, EventArgs e)
        {
            if (CboProjetos.Items.Count > 0) CboProjetos.Items.Clear();
            CboProjetos.Enabled = false;
            BtnParticipar.Enabled = false;
            BtnSair.Enabled = false;
            BtnExcluirProjeto.Enabled = false;
            BtnSalvar.Enabled = true;
            BtnAddColab.Enabled = false;
            BtnAddArquivo.Enabled = false;
            ComboEstados.DropDownStyle = ComboBoxStyle.DropDownList;
            limparCampos();
            statusCampos(true);

        }

        private void BtnParticipar_Click(object sender, EventArgs e)
        {
            string verifUsuario = "";

            verifUsuario = clsConnect.GetValor($"select prco_pk from projeto_colaboradores where prco_caus_fk = {identificacaoUsuario} and prco_status <> 'PARTICIPANTE'", "prco_pk");
            if (!string.IsNullOrEmpty(verifUsuario))
            {
                MessageBox.Show("Usuário já Cadastrado neste projeto!");
                return;
            }

            clsConnect.InserirProjetoColaboradores(registroAtual.ToString(), identificacaoUsuario, "PARTICIPANTE");

            carregarProjeto(registroAtual);
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            if (!verifAutorProjeto) clsConnect.removerProjetoColaboradores(registroAtual.ToString(), identificacaoUsuario, permissaoNoProjeto);
            limparCampos();
            statusCampos(false);
            permissoes();
        }

        private void BtnAddColab_Click(object sender, EventArgs e)
        {
            try
            {
                string colaborador = CboColaboradores.Text;
                int posicao = colaborador.IndexOf(";");

                if (posicao > 0)
                {
                    colaborador = colaborador.Substring(0, posicao);

                    if (!string.IsNullOrEmpty(colaborador))
                    {
                        colaborador = int.Parse(colaborador).ToString();
                    }
                }

                if (string.IsNullOrEmpty(colaborador)) return;

                clsConnect.InserirProjetoColaboradores(registroAtual.ToString(), int.Parse(colaborador), "COLABORADOR");

                carregarProjeto(registroAtual);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show($"Erro ao incluir novo colaborador: {ex.Message}");
            }
        }

        private void BtnSelecionarProjeto_Click(object sender, EventArgs e)
        {
            limparCampos();
            selecionarProjeto();
        }

        private void BtnExcluirProjeto_Click(object sender, EventArgs e)
        {
            clsConnect.GenDeletarDados("PROJETO_COLABORADORES", "PRCO_CAPR_FK", registroAtual.ToString());
            clsConnect.GenDeletarDados("CADASTRO_PROJETO", "CAPR_PK", registroAtual.ToString());
            limparCampos();
            statusCampos(false);
            carregarComboProjetos();
            BtnExcluirProjeto.Enabled = false;
            selecionarProjeto();

        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (registroAtual == 0)
            {
                try
                {
                    if (string.IsNullOrEmpty(ComboEstados.Text) || string.IsNullOrEmpty(TextBairro.Text) || string.IsNullOrEmpty(TextNumero.Text) || string.IsNullOrEmpty(TextComplemento.Text))
                    {
                        MessageBox.Show("É necessário preencher todas as informações do endereço!", "Atenção!");
                    }
                    clsConnect.CadastrarProjeto(identificacaoUsuario, CboTipo.Text, TextTitulo.Text, TextDescricao.Text, DateTime.Parse(DataInicioProjeto.Text).ToString("dd/MM/yyyy"), DateTime.Parse(DataFinalProjeto.Text).ToString("dd/MM/yyyy"), TextComplemento.Text, TextNumero.Text, TextBairro.Text, ComboEstados.Text);
                    carregarComboProjetos();
                    selecionarProjeto();
                    limparCampos();
                }
                catch (Exception iex)
                {
                    MessageBox.Show(iex.Message);
                }
            }
            else
            {
                bool verifColaborador = clsConnect.GetValor($"Select prco_pk from projeto_colaboradores where prco_caus_fk = {identificacaoUsuario} and prco_capr_fk = {registroAtual} and prco_status = 'COLABORADOR'", "prco_pk") != "" ? true : false;

                if (verifColaborador)
                {
                    clsConnect.GenAtualizarDados("CADASTRO_PROJETO", "CAPR_DESCRICAO", TextDescricao.Text, "CAPR_PK", registroAtual.ToString());
                    clsConnect.GenAtualizarDados("CADASTRO_PROJETO", "CAPR_DATA_FIM", DateTime.Parse(DataFinalProjeto.Text).ToString("dd/MM/yyyy"), "CAPR_PK", registroAtual.ToString());
                }


            }
        }

        private void CboProjetos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string projeto = CboProjetos.Text;
            if (CboProjetos.SelectedIndex > 0 && !string.IsNullOrEmpty(projeto))
            {
                registroAtual = obterProjeto();

                carregarProjeto(registroAtual);
            }
            else
            {
                MessageBox.Show("Nenhum projeto encontrado!");
            }

        }

        private void BtnAddArquivo_Click(object sender, EventArgs e)
        {
            CopiarArquivosParaProjeto();
        }

        private void GridAnexos_DoubleClick(object sender, EventArgs e)
        {
            int m_Col = GridAnexos.CurrentCell.ColumnIndex;
            int m_Row = GridAnexos.CurrentCell.RowIndex;
            string arquivo = GridAnexos.Rows[m_Row].Cells[1].Value?.ToString();

            try
            {
                if (!string.IsNullOrEmpty(arquivo) && File.Exists(arquivo))
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = arquivo,
                        UseShellExecute = true,
                        Verb = "open"
                    });
                }
                else
                {
                    MessageBox.Show("O arquivo não foi encontrado!", "Erro");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro");
            }
        }

        private void GridParticipantes_KeyDown(object sender, KeyEventArgs e)
        {
            int m_Col = GridParticipantes.CurrentCell.ColumnIndex;
            int m_Row = GridParticipantes.CurrentCell.RowIndex;
            string participante = GridParticipantes.Rows[m_Row].Cells[1].Value.ToString();
            string chave = GridParticipantes.Rows[m_Row].Cells[0].Value.ToString();

            if (!verifAutorProjeto)
            {
                MessageBox.Show("Apenas o Autor do Projeto pode realizar esta operação!");
                return;
            }


            if (e.KeyCode == Keys.Delete)
            {
                if (statusProjetoAberto && (verifAutorProjeto && participante != identificacaoUsuario.ToString())) clsConnect.executarSql($"delete from projeto_colaboradores where prco_pk = '{chave}'");

                carregarParticipantes();
            }
        }

        private void GridColaboradores_KeyDown(object sender, KeyEventArgs e)
        {
            int m_Col = GridColaboradores.CurrentCell.ColumnIndex;
            int m_Row = GridColaboradores.CurrentCell.RowIndex;
            string colaborador = GridColaboradores.Rows[m_Row].Cells[1].Value.ToString();
            string chave = GridColaboradores.Rows[m_Row].Cells[0].Value.ToString();

            if (e.KeyCode == Keys.Delete)
            {
                if (statusProjetoAberto && (verifAutorProjeto && colaborador != identificacaoUsuario.ToString())) clsConnect.executarSql($"delete from projeto_colaboradores where prco_pk = '{chave}'");
                if (!verifAutorProjeto) MessageBox.Show("Apenas o Autor do Projeto pode realizar esta operação!");
                carregarGridColab();
            }
        }

        private void GridAnexos_KeyDown(object sender, KeyEventArgs e)
        {
            if (GridAnexos.CurrentCell == null || GridAnexos.CurrentCell.RowIndex < 0)
                return;

            int m_Col = GridAnexos.CurrentCell.ColumnIndex;
            int m_Row = GridAnexos.CurrentCell.RowIndex;
            string arquivo = GridAnexos.Rows[m_Row].Cells[1].Value?.ToString();

            if (e.KeyCode == Keys.Delete && verifColaborador)
            {
                try
                {
                    if (!string.IsNullOrEmpty(arquivo) && File.Exists(arquivo))
                    {
                        File.Delete(arquivo);
                        MessageBox.Show("Arquivo excluído!", "Sucesso");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao excluir o arquivo: {ex.Message}", "Erro");
                }

                ListarArquivosNoGrid();
            }
        }


        #endregion

        #region Exportar dados
        private void BtnExtrairDados_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable m_Data = new DataTable();
                m_Data = clsConnect.GetDados("      select a.capr_titulo        [projeto]                      " +
                                             "            ,a.capr_descricao     [Descrição]                    " +
                                             "            ,a.capr_data_inicio   [Data de Início]               " +
                                             "            ,a.capr_data_fim      [Data Final]                   " +
                                             "            ,a.capr_endereco      [Endereço do projeto]          " +
                                             "            ,a.capr_numero        [Numero]                       " +
                                             "            ,a.capr_bairro        [Bairro]                       " +
                                             "            ,a.capr_estado        [Estado]                       " +
                                             "            ,c.caus_nome          [Voluntário]                   " +
                                             "            ,c.caus_telefone      [Voluntário - Telefone]        " +
                                             "            ,c.caus_estado        [Voluntário - Estado]          " +
                                             "            ,c.caus_bairro        [Voluntário - Bairro]          " +
                                             "            ,c.caus_numero        [Voluntário - Numero]          " +
                                             "            ,c.caus_endereco      [Voluntário - Complemento]     " +
                                             "        from cadastro_projeto a                                  " +
                                             "   left join projeto_colaboradores b                             " +
                                             "          on b.prco_capr_fk = a.capr_pk" +
                                             "         and b.prco_status in ('COLABORADOR','PARTICIPANTE')     " +
                                             "   left join cadastro_usuario c                                  " +
                                             "          on c.caus_pk = b.prco_caus_fk                          " +
                                             $"where a.capr_pk = {registroAtual}"
                                            );

                if (m_Data.Rows.Count > 0)
                {
                    string caminhoArquivo = @"C:\temp\RelatorioVoluntarios.xlsx";

                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Relatório de Voluntários");
                        worksheet.Cell(1, 1).InsertTable(m_Data);

                        worksheet.Columns().AdjustToContents();

                        workbook.SaveAs(caminhoArquivo);
                    }

                    Process.Start(new ProcessStartInfo(caminhoArquivo) { UseShellExecute = true });
                }
                else
                {
                    MessageBox.Show("Nenhum dado encontrado para exportar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
