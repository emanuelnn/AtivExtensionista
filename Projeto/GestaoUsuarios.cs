using CONECTA.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CONECTA
{
    public partial class GestaoUsuarios : Form
    {
        int identificacaoUsuario = 0;
        bool verifModerador = false;

        public GestaoUsuarios(int UserID)
        {
            InitializeComponent();
            identificacaoUsuario = UserID;
            verifModerador = clsConnect.GetValor($"Select caus_perfil from cadastro_usuario where caus_pk = {identificacaoUsuario} and caus_perfil = 'MODERADOR'", "caus_perfil") != "" ? true : false;
            PanelAdmin.Visible = verifModerador;
            dadosDoUsuario();
            carregarGrid();
        }

        private void dadosDoUsuario()
        {
            DataTable m_Data = new DataTable();
            m_Data = clsConnect.GetDados($"select * from cadastro_usuario where caus_pk = '{identificacaoUsuario}'");

            TextNome.Text = m_Data.Rows[0]["caus_nome"].ToString();
            TextCep.Text = m_Data.Rows[0]["caus_cep"].ToString();
            TextEstado.Text = m_Data.Rows[0]["caus_estado"].ToString();
            TextBairro.Text = m_Data.Rows[0]["caus_bairro"].ToString();
            TextNumero.Text = m_Data.Rows[0]["caus_numero"].ToString();
            TextEndereco.Text = m_Data.Rows[0]["caus_endereco"].ToString();
            TextSenha.Text = clsConnect.DescriptografarSenha(m_Data.Rows[0]["caus_senha"].ToString());
        }

        private void carregarGrid()
        {
            DataGridUsuarios.DataSource = clsConnect.GetDados("Select * from cadastro_usuario");
        }

        private void DataGridUsuarios_KeyDown(object sender, KeyEventArgs e)
        {
            int m_Col = DataGridUsuarios.CurrentCell.ColumnIndex;
            int m_Row = DataGridUsuarios.CurrentCell.RowIndex;


            if (e.KeyCode == Keys.Delete)
            {
                clsConnect.GenDeletarDados("CADASTRO_USUARIO", "CAUS_PK", DataGridUsuarios.Rows[m_Row].Cells[0].Value.ToString());
                carregarGrid();
            }
        }

        private void BtnTornarModerador_Click(object sender, EventArgs e)
        {
            int m_Col = DataGridUsuarios.CurrentCell.ColumnIndex;
            int m_Row = DataGridUsuarios.CurrentCell.RowIndex;

            clsConnect.executarSql($"Update cadastro_usuario set caus_perfil = 'MODERADOR' where caus_pk = '{DataGridUsuarios.Rows[m_Row].Cells[0].Value.ToString()}'");
            carregarGrid();
        }

        private void BtnRemoverModerador_Click(object sender, EventArgs e)
        {
            int m_Col = DataGridUsuarios.CurrentCell.ColumnIndex;
            int m_Row = DataGridUsuarios.CurrentCell.RowIndex;

            clsConnect.executarSql($"Update cadastro_usuario set caus_perfil = 'PERFIL' where caus_pk = '{DataGridUsuarios.Rows[m_Row].Cells[0].Value.ToString()}'");
            carregarGrid();
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            clsConnect.GenAtualizarDados("CADASTRO_USUARIO", "caus_nome", TextNome.Text, "caus_pk", identificacaoUsuario.ToString());
            clsConnect.GenAtualizarDados("CADASTRO_USUARIO", "caus_cep", TextCep.Text, "caus_pk", identificacaoUsuario.ToString());
            clsConnect.GenAtualizarDados("CADASTRO_USUARIO", "caus_estado", TextEstado.Text, "caus_pk", identificacaoUsuario.ToString());
            clsConnect.GenAtualizarDados("CADASTRO_USUARIO", "caus_bairro", TextBairro.Text, "caus_pk", identificacaoUsuario.ToString());
            clsConnect.GenAtualizarDados("CADASTRO_USUARIO", "caus_numero", TextNumero.Text, "caus_pk", identificacaoUsuario.ToString());
            clsConnect.GenAtualizarDados("CADASTRO_USUARIO", "caus_endereco", TextEndereco.Text, "caus_pk", identificacaoUsuario.ToString());
            clsConnect.GenAtualizarDados("CADASTRO_USUARIO", "caus_senha", clsConnect.CriptografarSenha(TextSenha.Text), "caus_pk", identificacaoUsuario.ToString());
            clsConnect.GenAtualizarDados("CADASTRO_USUARIO", "caus_telefone", TextTelefone.Text, "caus_pk", identificacaoUsuario.ToString());

            dadosDoUsuario();
            carregarGrid();
        }
    }
}
