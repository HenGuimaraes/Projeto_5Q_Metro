using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace site
{
    public partial class Registro : System.Web.UI.Page
    {
        int index;
        SqlConnection conn = new SqlConnection("Server = tcp:ozen.database.windows.net,1433; Initial Catalog = DB_aula1; Persist Security Info = False; User ID = flad8; Password = D4DN9zc1; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");

        /*
         * DataBind() - vincula o DataSource com o dropDownList, ou seja, agora que ele tinha os valores
         * graças ao DataSource, eu uso o DataBind pra inserir eles no DropDownList, através de dois campos
         * de referência: DataTextField="cargo_nome" que serviu para passar o texto vindo do banco de dados;
         *                DataValueField="cod_cargo" que serviu para informar o valor daquele campo.
         * Os valores dos campos de referência tem que referênciar as colunas que você ta chamando,
         * ou seja, valor com mesmo nome das colunas.
         */
        protected void Page_Load(object sender, EventArgs e)

        {
            //Esse IF faz com que o Load só rode na primeira vez que a página é carregada
            if(IsPostBack == true)
            {
                txtSenha.Attributes["value"] = txtSenha.Text;
                txtSenha.Attributes["value"] = txtConfirmarSenha.Text;
                return;
            }

            //Escondendo a label do erro, vai aparecer só quando tiver ERRO
            lblErro.Visible = false;

            //Preenchendo o dropDownList com os cargos do banco de dados.
            using (conn)
            {
                conn.Open();

                using (SqlCommand codigoSql = new SqlCommand("SELECT cod_cargo, nome_cargo FROM Cargo;", conn))
                {
                    dropDownList.Items.Insert(0, "Selecione o cargo");//Inserindo um novo item, nome autoexplicativo.

                    using (SqlDataReader dr = codigoSql.ExecuteReader())
                    {
                        dropDownList.DataSource = dr;//Informa onde esta o bloco de dados para preencher o dropDown
                        dropDownList.DataValueField = "cod_cargo";
                        dropDownList.DataTextField = "nome_cargo";
                        dropDownList.DataBind();
                    }
                }
            }
        }
       
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            

            if (txtNome.Text != "" && txtLogin.Text != "" && txtSenha.Text != "" && txtConfirmarSenha.Text != ""
               && dropDownList.SelectedIndex != 0)
            {
                if (string.IsNullOrWhiteSpace(txtLogin.Text) || string.IsNullOrWhiteSpace(txtSenha.Text)
                    || string.IsNullOrWhiteSpace(txtConfirmarSenha.Text))
                {
                    lblErro.Text = "Não é permitido espaços nos campos de Login e Senhas";
                    lblErro.Visible = true;
                    return;
                }
                else
                {
                    using (conn)
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand("SELECT login FROM usuario WHERE login = @login;", conn))
                        {
                            cmd.Parameters.AddWithValue("@login", txtLogin.Text);
                            String login = Convert.ToString(cmd.ExecuteScalar());
                            
                            if(login == txtLogin.Text)
                            {
                                lblErro.Text = "Não é possivel cadastrar, o login digitado já existe!!";
                                lblErro.Visible = true;
                                return;
                            }
                            else
                            {
                                if (txtSenha.Text == txtConfirmarSenha.Text)
                                {
                                    using (conn)
                                    {
                                        using (SqlCommand codigoSql = new SqlCommand(@"INSERT INTO usuario (nome, login, senha, cod_cargo) 
                                                           VALUES (@nome, @login, @senha, @cargo)", conn))
                                        {
                                            codigoSql.Parameters.AddWithValue("@nome", txtNome.Text);
                                            codigoSql.Parameters.AddWithValue("@login", txtLogin.Text);
                                            codigoSql.Parameters.AddWithValue("@senha", txtSenha.Text);
                                            codigoSql.Parameters.AddWithValue("@cargo", index);
                                            codigoSql.ExecuteNonQuery();

                                            txtNome.Text = "";
                                            txtLogin.Text = "";
                                            txtSenha.Text = "";
                                            txtConfirmarSenha.Text = "";
                                            dropDownList.SelectedIndex = 0;
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    lblErro.Text = "As senhas não estão iguais";
                                    lblErro.Visible = true;
                                    return;
                                }
                            }
                        }

                    }
                }
            }
            else
            {
                lblErro.Text = "Preencha todos os campos!!";
                lblErro.Visible = true;
                return;
            }
        }
    }
}
