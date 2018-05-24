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
                return;
            }

            //Escondendo a label do erro, vai aparecer só quando tiver ERRO
            lblErro.Visible = false;

            //Preenchendo o dropDownList com os cargos do banco de dados.
            using (SqlConnection conString = new SqlConnection("Server=tcp:ozen.database.windows.net,1433;Initial Catalog=DB_aula1;Persist Security Info=False;User ID=flad8;Password=D4DN9zc1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                conString.Open();

                using (SqlCommand codigoSql = new SqlCommand("SELECT cod_cargo, nome_cargo FROM Cargo;", conString))
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
               && index != 0)
            {
                if (string.IsNullOrWhiteSpace(txtLogin.Text) || string.IsNullOrWhiteSpace(txtSenha.Text)
                    || string.IsNullOrWhiteSpace(txtConfirmarSenha.Text))
                {
                    lblErro.Text = "Não é permitido espaços nos campos de Login e Senhas";
                    lblErro.Visible = true;
                }
                else
                {
                    if (txtSenha.Text == txtConfirmarSenha.Text)
                    {
                        using (SqlConnection conn = new SqlConnection("Server = tcp:ozen.database.windows.net,1433; Initial Catalog = DB_aula1; Persist Security Info = False; User ID = flad8; Password = D4DN9zc1; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;"))
                        {
                            conn.Open();

                            using (SqlCommand cmd = new SqlCommand(@"INSERT INTO usuario (nome, login, senha, cod_cargo) 
                                                           VALUES (@nome, @login, @senha, @cargo)", conn))
                            {
                                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                                cmd.Parameters.AddWithValue("@login", txtLogin.Text);
                                cmd.Parameters.AddWithValue("@senha", txtSenha.Text);
                                cmd.Parameters.AddWithValue("@cargo", index);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    else
                    {
                        lblErro.Text = "As senhas não estão iguais";
                        lblErro.Visible = true;
                    }
                }
            }
            else
            {
                lblErro.Text = "Preencha todos os campos!!";
                lblErro.Visible = true;
            }
        }

        //Evento de quando você seleciona algo do dropDownList
        protected void dropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Captura o indice quando selecionado o item
            index = dropDownList.SelectedIndex;
        }
    }
}
