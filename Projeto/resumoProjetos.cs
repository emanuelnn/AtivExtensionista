using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public resumoProjetos(int userID)
        {
            identificacaoUsuario = userID;
            InitializeComponent();
            carregarEstatistica();
            carregarCboBairro();
            carregarCboEstado();


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

    }
}
