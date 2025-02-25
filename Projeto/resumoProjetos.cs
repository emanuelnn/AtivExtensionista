using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CONECTA.Classes
{
    public partial class resumoProjetos : Form
    {
        int identificacaoUsuario = 0;
        bool usuarioModerador = false;
        public resumoProjetos(int userID)
        {
            identificacaoUsuario = userID;
            InitializeComponent();
            carregarEstatistica();
            carregarCboBairro();
            carregarCboEstado();
            usuarioModerador = clsConnect.GetValor($"select CAUS_PK from cadastro_usuario where caus_pk = {identificacaoUsuario} and caus_perfil = 'MODERADOR'", "CAUS_PK") == identificacaoUsuario.ToString() ? true : false;
            BtnExtrair.Visible = usuarioModerador;
            BtnExtrair.Enabled = usuarioModerador;

        }

        #region Carregamento de Dados
        private void carregarEstatistica()
        {
            // Atualiza a quantidade de projetos
            string sqlIndicador = "SELECT COUNT(a.capr_pk) AS capr_pk FROM cadastro_projeto a " +
                                                                "left join projeto_colaboradores b " +
                                                                       "on b.prco_capr_fk = a.capr_pk " +
                                                                    "where 1 = 1 ";

            if (!string.IsNullOrEmpty(CboEstado.Text))
            {
                sqlIndicador += $" and capr_estado = '{CboEstado.Text}' ";
            }

            if (!string.IsNullOrEmpty(CboBairro.Text))
            {
                sqlIndicador += $" and capr_bairro = '{CboBairro.Text}' ";
            }

            if (!string.IsNullOrEmpty(CboTipoProjeto.Text))
            {
                if (CboTipoProjeto.Text == "Sou Colaborador") sqlIndicador += $" and b.prco_caus_fk = '{identificacaoUsuario}' and b.prco_status = 'COLABORADOR' ";

                if (CboTipoProjeto.Text == "Sou Voluntário") sqlIndicador += $" and b.prco_caus_fk = '{identificacaoUsuario}' and b.prco_status = 'PARTICIPANTE' ";
            }


            LbQtdProjetos.Text = clsConnect.GetValor(sqlIndicador, "capr_pk").ToString();

            // Query base para obter os dados
            string sql = @"select distinct
                                  a.capr_titulo       AS [Projeto],
                                  a.capr_descricao    AS [Detalhes],
                                  a.capr_data_inicio  AS [Início],
                                  a.capr_data_fim     AS [Termino],
                                  a.capr_estado       AS [Estado],
                                  a.capr_bairro       AS [Bairro]
                             from cadastro_projeto a " +
                       "left join projeto_colaboradores b " +
                              "on b.prco_capr_fk = a.capr_pk " +
                          " where 1 = 1 ";


            if (!string.IsNullOrEmpty(CboBairro.Text))
            {
                sql += $" and capr_bairro = '{CboBairro.Text}' ";
            }

            if (!string.IsNullOrEmpty(CboEstado.Text))
            {
                sql += $" and capr_estado = '{CboEstado.Text}' ";
            }

            if (!string.IsNullOrEmpty(CboTipoProjeto.Text))
            {
                if (CboTipoProjeto.Text == "Sou Colaborador") sql += $" and b.prco_caus_fk = '{identificacaoUsuario}' and b.prco_status = 'COLABORADOR' ";

                if (CboTipoProjeto.Text == "Sou Voluntário") sql += $" and b.prco_caus_fk = '{identificacaoUsuario}' and b.prco_status = 'PARTICIPANTE' ";
            }

            GridDadosGeral.DataSource = clsConnect.GetDados(sql);

            for (int i = 1; i < GridDadosGeral.ColumnCount; i++)
            {
                GridDadosGeral.AutoResizeColumn(i);
            }
        }


        private void carregarCboBairro()
        {
            CboBairro.Items.Clear();

            DataTable m_Data = new DataTable();
            string sql = $"select distinct capr_bairro from cadastro_projeto a " +
                                                 "left join projeto_colaboradores b " +
                                                        "on b.prco_capr_fk = a.capr_pk " +
                                                    " where 1 = 1 ";

            if (!string.IsNullOrEmpty(CboEstado.Text)) sql += $" and capr_estado = '{CboEstado.Text}'";

            if (CboTipoProjeto.Text == "Sou Colaborador") sql += $" and b.prco_caus_fk = '{identificacaoUsuario}' and b.prco_status = 'COLABORADOR' ";

            if (CboTipoProjeto.Text == "Sou Voluntário") sql += $" and b.prco_caus_fk = '{identificacaoUsuario}' and b.prco_status = 'PARTICIPANTE' ";

            m_Data = clsConnect.GetDados(sql);

            CboBairro.Items.Add("");
            for (int i = 0; i < m_Data.Rows.Count; i++)
            {
                CboBairro.Items.Add(m_Data.Rows[i]["capr_bairro"].ToString());
            }
        }

        private void carregarCboEstado()
        {
            CboEstado.Items.Clear();
            DataTable m_Data = new DataTable();
            string sql = $"select distinct capr_estado from cadastro_projeto a " +
                                                 "left join projeto_colaboradores b " +
                                                        "on b.prco_capr_fk = a.capr_pk " +
                                                    " where 1 = 1 ";

            if (!string.IsNullOrEmpty(CboBairro.Text)) sql += $" and capr_bairro = '{CboBairro.Text}'";

            if (CboTipoProjeto.Text == "Sou Colaborador") sql += $" and b.prco_caus_fk = '{identificacaoUsuario}' and b.prco_status = 'COLABORADOR' ";

            if (CboTipoProjeto.Text == "Sou Voluntário") sql += $" and b.prco_caus_fk = '{identificacaoUsuario}' and b.prco_status = 'PARTICIPANTE' ";

            CboEstado.Items.Add("");
            m_Data = clsConnect.GetDados(sql);


            for (int i = 0; i < m_Data.Rows.Count; i++)
            {
                CboEstado.Items.Add(m_Data.Rows[i]["capr_estado"].ToString());
            }
        }

        #endregion

        private void CboBairro_SelectedIndexChanged(object sender, EventArgs e)
        {
            carregarEstatistica();
            carregarCboEstado();
        }

        private void CboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            carregarEstatistica();
            carregarCboBairro();
        }

        private void CboTipoProjeto_SelectedIndexChanged(object sender, EventArgs e)
        {
            carregarCboBairro();
            carregarCboEstado();
            carregarEstatistica();
        }

        private void BtnExtrair_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable m_Data = new DataTable();
                m_Data = clsConnect.GetDados("      select a.capr_titulo        [projeto]                      " +
                                             "            ,d.caus_nome         [Autor]                        " +
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
                                             "          on b.prco_capr_fk = a.capr_pk                          " +
                                             "   left join cadastro_usuario c                                  " +
                                             "          on c.caus_pk = b.prco_caus_fk                          " +
                                             "   left join cadastro_usuario d                                  " +
                                             "          on d.caus_pk = a.capr_autor                            "
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
    }
}
