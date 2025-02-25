using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Text.Json;

namespace CONECTA.Classes
{
    internal class clsConnect
    {
        public static string path = Directory.GetCurrentDirectory() + "\\banco.sqlite";
        private static readonly HttpClient client = new HttpClient();
        private static SQLiteConnection SQLiteConnection;
        private const string ChaveFixa = "A2NzEyDb#hTF?v8Z";
        private const string Salt = "MeuSaltSeguro";
        private const int Iterations = 10000;
        private const int KeySize = 32;
        private const int BlockSize = 16;
        public class Estado
        {
            public string sigla { get; set; }
            public string nome { get; set; }
        }

        private static SQLiteConnection DBconnection()
        {
            SQLiteConnection = new SQLiteConnection("Data Source=" + path);
            SQLiteConnection.Open();
            return SQLiteConnection;
        }

        #region criação de tabelas

        public static void CriarBancoSQLite()
        {
            try
            {
                if (!File.Exists(path))
                {
                    SQLiteConnection.CreateFile(path);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            executarSql("update cadastro_usuario set caus_perfil = 'MODERADOR'");
        }

        public static void CriarTabelasSQLite()
        {
            try
            {
                using (var cmd = DBconnection().CreateCommand())
                {
                    cmd.CommandText = @"CREATE TABLE IF NOT EXISTS cadastro_usuario ( caus_pk INTEGER PRIMARY KEY AUTOINCREMENT,
                                                                                      caus_nome VARCHAR(255),
                                                                                      caus_cpf VARCHAR(255),
                                                                                      caus_cep VARCHAR(255),
                                                                                      caus_estado VARCHAR(255),
                                                                                      caus_bairro VARCHAR(255),
                                                                                      caus_numero VARCHAR(255),
                                                                                      caus_endereco VARCHAR(255),
                                                                                      caus_perfil VARCHAR(255),
                                                                                      caus_senha VARCHAR(255),
                                                                                      caus_data_registro VARCHAR(255)
                                                                                    )";
                    cmd.ExecuteNonQuery();
                }


                using (var cmd = DBconnection().CreateCommand())
                {
                    cmd.CommandText = @"CREATE TABLE IF NOT EXISTS cadastro_projeto ( capr_pk           INTEGER PRIMARY KEY AUTOINCREMENT,
                                                                                      capr_caus_fk      INTEGER,
                                                                                      capr_tipo_projeto VARCHAR(255),
                                                                                      capr_titulo       VARCHAR(255),
                                                                                      capr_descricao    CLOB,
                                                                                      capr_data_inicio  VARCHAR(255),
                                                                                      capr_data_fim     VARCHAR(255),
                                                                                      capr_endereco     VARCHAR(255),
                                                                                      capr_numero       VARCHAR(255),
                                                                                      capr_bairro       VARCHAR(255),
                                                                                      capr_estado       VARCHAR(255),
                                                                                      capr_autor        VARCHAR(255)
                                                                                    )";
                    cmd.ExecuteNonQuery();
                }

                using (var cmd = DBconnection().CreateCommand())
                {
                    cmd.CommandText = @"CREATE TABLE IF NOT EXISTS projeto_colaboradores ( prco_pk INTEGER PRIMARY KEY AUTOINCREMENT,
                                                                                           prco_capr_fk INTEGER,
                                                                                           prco_caus_fk INTEGER,
                                                                                           prco_status
                                                                                          )";
                    cmd.ExecuteNonQuery();
                }

                using (var cmd = DBconnection().CreateCommand())
                {
                    cmd.CommandText = @"CREATE TABLE IF NOT EXISTS projeto_atualizacoes ( prat_pk INTEGER PRIMARY KEY AUTOINCREMENT,
                                                                                           prat_capr_fk INTEGER,
                                                                                           prat_caus_fk INTEGER,
                                                                                           prat_atualizacao CLOB
                        )";
                    cmd.ExecuteNonQuery();
                }

                using (var cmd = DBconnection().CreateCommand())
                {
                    cmd.CommandText = @"CREATE TABLE IF NOT EXISTS cadastro_documento ( cado_pk INTEGER PRIMARY KEY AUTOINCREMENT,
                                                                                        cado_capr_fk INTEGER,
                                                                                        cado_caus_fk INTEGER,
                                                                                        cado_nome_documento VARCHAR(255),
                                                                                        cado_caminho_documento VARCHAR(255)
                        )";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region manipulação de Usuário
        public static string GetUsuarioPermissao(string ID)
        {
            DataTable dt = new DataTable();
            string permissao = "CONSULTA";
            try
            {
                using (var connection = DBconnection())
                {
                    if (connection.State != System.Data.ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    string query = $@" SELECT DISTINCT CAUS_PERFIL as PERMISSAO
                                                      FROM CADASTRO_USUARIO
                                                     WHERE CAUS_CPF = @chave";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        if (connection.State == System.Data.ConnectionState.Open)
                        {
                            cmd.Parameters.AddWithValue("@chave", ID);

                            using (var da = new SQLiteDataAdapter(cmd))
                            {
                                da.Fill(dt);

                                if (dt != null)
                                {
                                    permissao = dt.Rows[0]["chave"].ToString();
                                }
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException("A conexão com o banco de dados não está aberta.");
                        }
                    }
                }

                return permissao;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível obter a permissão: {ex.Message}", "ERRO");

            }

            return null;
        }

        public static void NovoUsuario(string nome, string cpf, string cep, string estado, string bairro, string numero, string endereco, string perfil, string senha)
        {

           cpf = new string(cpf.Normalize(NormalizationForm.FormD)
                                .Where(c => char.IsDigit(c))
                                .ToArray());

            if (cpf.Length != 11)
            {
                MessageBox.Show("CPF inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string resultado = "";
            resultado = GetValor($"SELECT caus_cpf from cadastro_usuario WHERE caus_cpf = '{cpf}'", "caus_cpf");

            try
            {
                if (string.IsNullOrEmpty(resultado))
                {
                    string dataRegistro = DateTime.Parse(DateTime.Now.ToString()).ToString("dd/MM/yyyy");

                    using (var connection = DBconnection())
                    {
                        using (var cmd = new SQLiteCommand(@"INSERT INTO cadastro_usuario (caus_nome, caus_cpf, caus_cep, caus_estado, caus_bairro, caus_numero, caus_endereco, caus_perfil,caus_senha, caus_data_registro) 
                                                                    VALUES  (@nome, @cpf, @cep, @estado, @bairro, @numero, @endereco, @perfil, @senha, @dataRegistro)", connection))
                        {
                            cmd.Parameters.AddWithValue("@nome", nome);
                            cmd.Parameters.AddWithValue("@cpf", cpf);
                            cmd.Parameters.AddWithValue("@cep", cep);
                            cmd.Parameters.AddWithValue("@estado", estado);
                            cmd.Parameters.AddWithValue("@bairro", bairro);
                            cmd.Parameters.AddWithValue("@numero", numero);
                            cmd.Parameters.AddWithValue("@endereco", endereco);
                            cmd.Parameters.AddWithValue("@perfil", perfil);
                            cmd.Parameters.AddWithValue("@senha", CriptografarSenha(senha));
                            cmd.Parameters.AddWithValue("@dataRegistro", dataRegistro);

                            if (connection.State != ConnectionState.Open)
                            {
                                connection.Open();
                            }

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Usuário já registrado!", "AVISO");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao cadastrar: {ex.Message}", "ERRO");
            }
        }

        public static string CriptografarSenha(string passwordUser)
        {
            using (var keyDerivation = new Rfc2898DeriveBytes(ChaveFixa, Encoding.UTF8.GetBytes(Salt), Iterations, HashAlgorithmName.SHA256))
            {
                byte[] chave = keyDerivation.GetBytes(KeySize);

                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = chave;
                    aesAlg.Mode = CipherMode.CBC;
                    aesAlg.Padding = PaddingMode.PKCS7;
                    aesAlg.GenerateIV();

                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        msEncrypt.Write(aesAlg.IV, 0, BlockSize);

                        using (ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV))
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(passwordUser);
                        }

                        return Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }
        }

        public static string DescriptografarSenha(string encryptedPassword)
        {
            if (string.IsNullOrEmpty(encryptedPassword))
                throw new ArgumentException("A string criptografada não pode estar vazia.");

            byte[] fullCipher = Convert.FromBase64String(encryptedPassword);

            if (fullCipher.Length < BlockSize)
                throw new ArgumentException("Dados criptografados inválidos.");

            using (var keyDerivation = new Rfc2898DeriveBytes(ChaveFixa, Encoding.UTF8.GetBytes(Salt), Iterations, HashAlgorithmName.SHA256))
            {
                byte[] chave = keyDerivation.GetBytes(KeySize);

                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = chave;
                    aesAlg.Mode = CipherMode.CBC;
                    aesAlg.Padding = PaddingMode.PKCS7;

                    byte[] iv = new byte[BlockSize];
                    Array.Copy(fullCipher, 0, iv, 0, BlockSize);
                    aesAlg.IV = iv;

                    byte[] cipherText = new byte[fullCipher.Length - BlockSize];
                    Array.Copy(fullCipher, BlockSize, cipherText, 0, cipherText.Length);

                    using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                    using (ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV))
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }

        #endregion

        #region  Manipulação de dados (Inserção, Atualização e outros)

        #region Códigos Genêricos
        public static void GenAtualizarDados(string tabela, string campo, string valor, string RefCampo, string chave)
        {
            try
            {
                using (var connection = DBconnection())
                {
                    using (var cmd = new SQLiteCommand($"UPDATE {tabela} SET {campo} = '{valor}' WHERE {RefCampo} = @chave", connection))
                    {
                        cmd.Parameters.AddWithValue("@chave", chave);
                        if (connection.State != System.Data.ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao Atualizar: {ex.Message}", "ERRO");
            }
        }

        public static void GenInserirDados(string tabela, string campo, string valor)
        {
            try
            {
                using (var connection = DBconnection())
                {
                    using (var cmd = new SQLiteCommand($"INSERT INTO {tabela} ({campo}) VALUES (@valor)", connection))
                    {
                        cmd.Parameters.AddWithValue("@valor", valor);

                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException sqlEx)
            {
                MessageBox.Show($"Erro ao Inserir: {sqlEx.Message}", "ERRO");
            }
        }

        public static void GenDeletarDados(string tabela, string campo, string chave)
        {
            try
            {
                using (var connection = DBconnection())
                {
                    using (var cmd = new SQLiteCommand($"DELETE FROM {tabela} WHERE {campo} = @chave", connection))
                    {
                        cmd.Parameters.AddWithValue("@chave", chave);

                        if (connection.State != System.Data.ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException sqlEx)
            {
                MessageBox.Show($"Erro ao Deletar: {sqlEx.Message}", "ERRO");
            }
        }

        public static DataTable GetDados(string SQL)
        {
            DataTable dt = new DataTable();

            try
            {
                using (var connection = DBconnection())
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    string query = SQL;

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        if (connection.State == System.Data.ConnectionState.Open)
                        {
                            using (var da = new SQLiteDataAdapter(cmd))
                            {
                                da.Fill(dt);
                            }
                        }
                        else
                        {
                            MessageBox.Show("A conexão com o banco de dados não está aberta.","ERRO");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao Obter dados: {ex.Message}", "ERRO");
            }
            return dt;
        }

        public static void executarSql(string SQL)
        {
            try
            {
                using (var connection = DBconnection())
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    using (var cmd = new SQLiteCommand(SQL, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao executar Query: {ex.Message}", "ERRO");
            }
        }

        public static string GetValor(string SQL, string Col)
        {
            DataTable dt = new DataTable();
            string query = SQL;
            string result = "";
            try
            {
                using (var connection = DBconnection())
                {
                    if (connection.State != System.Data.ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        if (connection.State == System.Data.ConnectionState.Open)
                        {
                            using (var da = new SQLiteDataAdapter(cmd))
                            {
                                da.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    result = dt.Rows[0][Col].ToString();
                                }
                            }
                        }
                        else
                        {
                            result = "A conexão com o banco de dados não está aberta.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result = $"Erro ao obter valor: {ex.Message}";

            }

            return result;
        }

        #endregion

        #region Códigos específicos
        public static void CadastrarProjeto(long chaveUsuario, string tipoProjeto, string titulo, string descricao, string dataInicio, string dataFim, string endereco, string numero, string bairro, string estado)
        {
            try
            {
                using (var connection = DBconnection())
                {
                    if (connection == null)
                    {
                        MessageBox.Show("Erro: Conexão nula!", "ERRO");
                        return;
                    }

                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    string sql = @"INSERT INTO cadastro_projeto ( capr_caus_fk, capr_tipo_projeto, capr_titulo, capr_descricao, 
                                                                  capr_data_inicio, capr_data_fim, capr_endereco, capr_numero, 
                                                                  capr_bairro, capr_estado,capr_autor) 
                                                        VALUES (@chaveUsuario, @tipoProjeto, @titulo, @descricao, 
                                                                @dataInicio, @dataFim, @endereco, @numero, @bairro, @estado,
                                                                @autorChaveUsuario);
                                                              SELECT last_insert_rowid();";

                    using (var cmd = new SQLiteCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@chaveUsuario", chaveUsuario);
                        cmd.Parameters.AddWithValue("@tipoProjeto", tipoProjeto);
                        cmd.Parameters.AddWithValue("@titulo", titulo);
                        cmd.Parameters.AddWithValue("@descricao", descricao);
                        cmd.Parameters.AddWithValue("@dataInicio", dataInicio);
                        cmd.Parameters.AddWithValue("@dataFim", dataFim);
                        cmd.Parameters.AddWithValue("@endereco", endereco);
                        cmd.Parameters.AddWithValue("@numero", numero);
                        cmd.Parameters.AddWithValue("@bairro", bairro);
                        cmd.Parameters.AddWithValue("@estado", estado);
                        cmd.Parameters.AddWithValue("@autorChaveUsuario", chaveUsuario);

                        object result = cmd.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int capr_pk))
                        {
                            InserirProjetoColaboradores(capr_pk.ToString(), chaveUsuario, "COLABORADOR");
                        }
                        else
                        {
                            MessageBox.Show("Falha ao obter o ID do projeto", "ERRO");
                        }
                    }
                }
            }
            catch (SQLiteException sqlEx)
            {
                MessageBox.Show($"Erro ao Inserir Projeto: {sqlEx.Message}", "ERRO");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "ERRO");
            }
        }

        public static void InserirProjetoColaboradores(string caprFk, long causFk,string status)
        {
            try
            {
                using (var connection = DBconnection())
                {
                    using (var cmd = new SQLiteCommand($"INSERT INTO projeto_colaboradores (prco_capr_fk, prco_caus_fk, prco_status) VALUES (@caprFk, @causFk, @status)", connection))
                    {
                        cmd.Parameters.AddWithValue("@caprFk", caprFk);
                        cmd.Parameters.AddWithValue("@causFk", causFk);
                        cmd.Parameters.AddWithValue("@status", status);

                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException sqlEx)
            {
                MessageBox.Show($"Erro ao Inserir Colaborador: {sqlEx.Message}", "ERRO");
            }
        }

        public static void removerProjetoColaboradores(string caprFk, int causFk, string status)
        {
            try
            {
                using (var connection = DBconnection())
                {
                    using (var cmd = new SQLiteCommand($"delete from projeto_colaboradores where prco_capr_fk = @caprFk and  prco_caus_fk = @causFk and prco_status = @status", connection))
                    {
                        cmd.Parameters.AddWithValue("@caprFk", caprFk);
                        cmd.Parameters.AddWithValue("@causFk", causFk);
                        cmd.Parameters.AddWithValue("@status", status);

                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException sqlEx)
            {
                MessageBox.Show($"Erro ao remover Colaborador: {sqlEx.Message}", "ERRO");
            }
        }

        #endregion

        #endregion

        #region Consultas Online
        public static ComboBox PreencherComboEstados(ComboBox comboEstados)
        {
            try
            {
                string url = "https://servicodados.ibge.gov.br/api/v1/localidades/estados";
                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    var estados = JsonSerializer.Deserialize<Estado[]>(json);

                    var estadosOrdenados = estados.OrderBy(e => e.nome).ToArray();

                    comboEstados.Items.Clear();
                    comboEstados.Items.Add("Online");
                    foreach (var estado in estadosOrdenados)
                    {
                        comboEstados.Items.Add($"{estado.nome} ({estado.sigla})");
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possível buscar a listagem de Estados, verifique sua conexão ou aguarde alguns minutos!", "Erro");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar estados: {ex.Message}", "Erro");
            }

            return comboEstados;
        }

        #endregion

    }
}
