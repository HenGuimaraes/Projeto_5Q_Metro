using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

namespace site
{
    public partial class Home2 : System.Web.UI.Page
    {
        int index;
        int contador = 0;
        int numeradorvalidador = 0;
        //contador necessario para nao zerar o vetor, deve ficar fora dos protegidos
        ListItem item;


        //SqlConnection conn = new SqlConnection(@"Server=tcp:tab132.database.windows.net,1433;Initial Catalog=esporte;Persist Security Info=False;User ID=mateus383;Password=123456sS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        SqlConnection conn = new SqlConnection("Server=tcp:ozen.database.windows.net,1433;Initial Catalog=DB_aula1;Persist Security Info=False;User ID=flad8;Password=D4DN9zc1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

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





            //using (SqlConnection conn = new SqlConnection("Server=tcp:tab132.database.windows.net,1433;Initial Catalog=esporte;Persist Security Info=False;User ID=mateus383@tab132;Password=123456sS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            //{
            //    conn.Open();
            //    //=====================================================================================//
            //    using (SqlCommand cmd = new SqlCommand("SELECT cod_trem,nome_trem From Trem order by cod_trem", conn))
            //    {
            //        using (SqlDataReader reader = cmd.ExecuteReader())
            //        {

            //            while (reader.Read() == true) //ele ira ler do 0 até o ultimo dado 
            //            {

            //                int valor = reader.GetInt32(0);
            //                string valor1 = valor.ToString();
            //                string descricao = reader.GetString(1);
            //                //pegando as informaços que foram lidas
            //                item = new ListItem(descricao, valor1);  //descricao é oq o usuario ve
            //                //valor é o id do item, "value"

            //                trens.Items.Add(item); // aqui ele adiciona no dropdown 
            //                                       // aqui ele ira ler os codigos que estao no banco de dados e registrar no dropdown

            //            }
            //        }

            //    }
            //}








            //Esse IF faz com que o Load só rode na primeira vez que a página é carregada
            if (IsPostBack == true)
            {
                txtSenha.Attributes["value"] = txtSenha.Text;
                txtSenha.Attributes["value"] = txtConfirmarSenha.Text;
                return;
            }

            //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showDropDownMenu()", true);

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

                            if (login == txtLogin.Text)
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
                                            codigoSql.Parameters.AddWithValue("@cargo", dropDownList.SelectedIndex);
                                            codigoSql.ExecuteNonQuery();
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



        //tabela de vagoes

        //protected void registrotrem_Click(object sender, EventArgs e)
        //{
        //    if (Trem.Text.Length == 0)
        //    {
        //        Trem.Text = "coloque um nome";
        //    }// valida se o campo esta em branco


        //    using (SqlConnection conn = new SqlConnection("Server=tcp:tab132.database.windows.net,1433;Initial Catalog=esporte;Persist Security Info=False;User ID=mateus383@tab132;Password=123456sS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
        //    {
        //        conn.Open();

        //        using (SqlCommand cmd = new SqlCommand("SELECT nome_trem from trem", conn))
        //        {
        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                //Obtém os registros, um por vez
        //                while (reader.Read() == true)
        //                {

        //                    string validacao;
        //                    validacao = reader.GetString(0);

        //                    if (validacao == Trem.Text)
        //                    {

        //                        Trem.Text = "o trem ja existe tente outro";
        //                        return;
        //                    }// aqui valida se o vagao ja tem nomeação igual

        //                }
        //            }
        //        }
        //        //=====================================================================================//
        //        using (SqlCommand cmd = new SqlCommand("INSERT INTO Trem VALUES (@linha,@nome_trem)", conn))
        //        {
        //            cmd.Parameters.AddWithValue("@linha", "amarela");
        //            cmd.Parameters.AddWithValue("@nome_trem", Trem.Text.Trim());
        //            //registra o trem
        //            cmd.ExecuteNonQuery();
        //        }
        //    }

        //}

        //protected void registrovagao_Click(object sender, EventArgs e)

        //{
        //    if (nomevagao.Text.Length == 0 || quantidade.Text.Length == 0)
        //    {
        //        nomevagao.Text = "preencha todos os campos";
        //        return;
        //    }// validando campo vazio

        //    int quantidadeDeVagao;
        //    if (int.TryParse(quantidade.Text, out quantidadeDeVagao) == false)
        //    {
        //        nomevagao.Text = "coloque um numero";

        //        // O return encerra a execução por aqui
        //        return;
        //    }

        //    if (quantidadeDeVagao > 9)
        //    {
        //        nomevagao.Text = "muitos vagoes";
        //        return;
        //    }//aqui valida se ele exagerou nos vagoes

        //    while (quantidadeDeVagao > 0)
        //    {
        //        int codtrem;
        //        string opcoesDeTrem = item.Value; //seleciona o ID do dropdown
        //        if (int.TryParse(opcoesDeTrem, out codtrem) == false) // transforma o ID do drowpdown em int
        //        {
        //            // Campo não contém um número inteiro!

        //            // O return encerra a execução por aqui
        //            return;
        //        }
        //        if (trens.SelectedValue == "0")
        //        {
        //            nomevagao.Text = "preencha um trem";
        //            return;
        //        }// aqui valida se ele preencheu o dropdown

        //        using (SqlConnection conn = new SqlConnection("Server=tcp:tab132.database.windows.net,1433;Initial Catalog=esporte;Persist Security Info=False;User ID=mateus383@tab132;Password=123456sS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
        //        {
        //            conn.Open();
        //            using (SqlCommand cmd = new SqlCommand("SELECT nome_vagao from Vagao", conn))
        //            {
        //                using (SqlDataReader reader = cmd.ExecuteReader())
        //                {
        //                    //Obtém os registros, um por vez
        //                    while (reader.Read() == true)
        //                    {


        //                        numeradorvalidador++;

        //                        nomevagao.Text.ToString();
        //                        string[] validator = new string[10 + numeradorvalidador];
        //                        validator[numeradorvalidador] = nomevagao.Text;

        //                        if (reader.GetString(0) == validator[numeradorvalidador] + " " + numeradorvalidador)
        //                        {// aqui estou igualando ele ao banco de dados, ja que a string se transforma

        //                            nomevagao.Text = "o trem ja existe tente outro";
        //                            return;
        //                        }// aqui valida se o vagao ja tem nomeação igual

        //                    }
        //                }
        //            }

        //            using (SqlCommand cmd = new SqlCommand("INSERT INTO Vagao VALUES (@cod_trem,@nome_vagao)", conn))
        //            {

        //                contador++;
        //                string[] nomesVagoes = new string[50 + contador];

        //                nomesVagoes[contador] = nomevagao.Text;

        //                nomesVagoes[contador] = nomesVagoes[contador] + " " + contador;
        //                cmd.Parameters.AddWithValue("@cod_trem", codtrem);
        //                //seleciona o trem pelo dropdown
        //                cmd.Parameters.AddWithValue("@nome_vagao", nomesVagoes[contador]);
        //                //gera o nome do vagao, e se for registrado ira começar o vetor

        //                quantidadeDeVagao = quantidadeDeVagao - 1;

        //                cmd.ExecuteNonQuery();
        //            }//conta a quantidade de vagoes que foram feitos e classifica: trem1,trem2...trem7
        //        }
        //    }
        //}




        [WebMethod]
        public static double TemperaturaAtual()
        {

            //SqlConnection conn = new SqlConnection(@"Server=tcp:tab132.database.windows.net,1433;Initial Catalog=esporte;Persist Security Info=False;User ID=mateus383;Password=123456sS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlConnection conn = new SqlConnection("Server=tcp:ozen.database.windows.net,1433;Initial Catalog=DB_aula1;Persist Security Info=False;User ID=flad8;Password=D4DN9zc1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            using (conn)
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT temperatura FROM Temperatura WHERE cod_temperatura = (SELECT MAX(cod_Temperatura) FROM temperatura)", conn))
                {

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read() == true)
                        {
                            return double.Parse(dr["temperatura"].ToString());
                        }
                        else
                        {
                            return 0;
                        }
                    }

                }

            }
        }
    }
}