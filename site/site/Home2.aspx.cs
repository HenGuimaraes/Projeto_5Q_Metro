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
                                            codigoSql.Parameters.AddWithValue("@cargo", dropDownList.SelectedValue);
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

        //public static double maximo()
        //{
        //    int medea = 0;
        //    int a = 0;

        //    using (SqlConnection conn = new SqlConnection(@"Server=tcp:tab132.database.windows.net,1433;Initial Catalog=esporte;Persist Security Info=False;User ID=mateus383;Password=123456sS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = new SqlCommand("SELECT MAX ( cod_temperatura) FROM Temperatura", conn))
        //        {
        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                while (dr.Read() == true)
        //                {
        //                    a = dr.GetInt32(0);
        //                    medea = a - 60;
        //                    //aqui eu fiz um algoritimo pra ele pegar a ultima temperatura dada,
        //                    // e a ultima a 60 segundos atras
        //                }
        //            }
        //        }

        //        using (SqlCommand cmd = new SqlCommand($"SELECT max(temperatura) FROM Temperatura WHERE cod_temperatura between {medea} and {a}", conn))
        //        {
        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                if (dr.Read() == true)
        //                {
        //                    return dr.GetDouble(0);
        //                    //continuação do que ue falei acima, ele vai verificar as temperaturas entre a ultima
        //                    //temperatura dada e a ultima 60segundos atras, e vai pegar o maximo entre elas
        //                }
        //                else { return 0; }
        //            }
        //        }
        //    }
        //}

        //public static double minimo()
        //{// metodo pra pegar a temp minima
        //    int medea = 0;
        //    int a = 0;

        //    using (SqlConnection conn = new SqlConnection(@"Server=tcp:tab132.database.windows.net,1433;Initial Catalog=esporte;Persist Security Info=False;User ID=mateus383;Password=123456sS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = new SqlCommand("SELECT MAX ( cod_temperatura) FROM Temperatura", conn))
        //        {
        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                while (dr.Read() == true)
        //                {
        //                    a = dr.GetInt32(0);
        //                    medea = a - 60;
        //                    //aqui eu fiz um algoritimo pra ele pegar a ultima temperatura dada,
        //                    // e a ultima a 60 segundos atras
        //                }
        //            }
        //        }

        //        using (SqlCommand cmd = new SqlCommand($"SELECT min(temperatura) FROM Temperatura WHERE cod_temperatura between {medea} and {a}", conn))
        //        {
        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                if (dr.Read() == true)
        //                {
        //                    return dr.GetDouble(0);
        //                    //continuação do que ue falei acima, ele vai verificar as temperaturas entre a ultima
        //                    //temperatura dada e a ultima 60segundos atras, e vai pegar o minimo entre elas
        //                }
        //                else { return 0; }
        //            }
        //        }
        //    }
        //}

        //public static double Media()
        //{
        //    int medea = 0;
        //    int a = 0;

        //    using (SqlConnection conn = new SqlConnection(@"Server=tcp:tab132.database.windows.net,1433;Initial Catalog=esporte;Persist Security Info=False;User ID=mateus383;Password=123456sS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = new SqlCommand("SELECT MAX ( cod_temperatura) FROM Temperatura", conn))
        //        {
        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                while (dr.Read() == true)
        //                {
        //                    a = dr.GetInt32(0);
        //                    medea = a - 60;
        //                    //aqui eu fiz um algoritimo pra ele pegar a ultima temperatura dada,
        //                    // e a ultima a 60 segundos atras
        //                }
        //            }
        //        }

        //        using (SqlCommand cmd = new SqlCommand($"SELECT round(avg(temperatura),2) FROM Temperatura WHERE cod_temperatura between {medea} and {a}", conn))
        //        {
        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                if (dr.Read() == true)
        //                {
        //                    return dr.GetDouble(0);
        //                    //aqui o comando vai dar diretamente a media entre a ultima temperatura dada e a ultima a 60
        //                    //segundos atras, e logo em seguida ele só ira deixar 2 casas pós virgula
        //                }
        //                else { return 0; }
        //            }
        //        }
        //    }
        //}

        //public static double Mediana()
        //{

        //    double xa = 0, b = 0, medea = 0;

        //    using (SqlConnection conn = new SqlConnection(@"Server=tcp:tab132.database.windows.net,1433;Initial Catalog=esporte;Persist Security Info=False;User ID=mateus383;Password=123456sS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = new SqlCommand("SELECT MAX (cod_temperatura) FROM Temperatura", conn))
        //        {
        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                while (dr.Read() == true)
        //                {
        //                    xa = dr.GetInt32(0) - 30;
        //                    //como só iremos pegar a temperatura de 1 em 1 minuto, ou seja, a cada 60 segundos
        //                    // eu coloquei pra pegar a mediana direto.


        //                }
        //            }
        //        }

        //        using (SqlCommand cmd = new SqlCommand($"SELECT temperatura FROM Temperatura WHERE cod_temperatura = {xa}", conn))
        //        {
        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                if (dr.Read() == true)
        //                {
        //                    medea = dr.GetDouble(0);
        //                    // aqui ele vai pegar a temperatura mediana 
        //                }
        //                else { cmd.ExecuteNonQuery(); return 1001; }
        //            }
        //        }

        //        using (SqlCommand cmd = new SqlCommand($"SELECT temperatura FROM Temperatura WHERE cod_temperatura = {xa + 1}", conn))
        //        {
        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                if (dr.Read() == true)
        //                {
        //                    b = dr.GetDouble(0);
        //                    // e aqui ele vai pegar a mediana 31, que como é numero par ele ira
        //                    // fazer o 30+31 (que é o meio do 60 mas é par entao o meio é duplo)

        //                }
        //                else
        //                {
        //                    return 1001;
        //                }
        //            }
        //        }
        //        return (medea + b) / 2;
        //        // esse é o calculo da mediana par
        //    }
        //}

        protected void timer_Tick(object sender, EventArgs e)
        {
            // aqui é onde ele vai envocar os metodos e retornar os valores que eu quero
            //label1.Text = Media().ToString() + "Cº";
            //label2.Text = Mediana().ToString() + "Cº";
            //label3.Text = maximo().ToString() + "Cº";
            //label4.Text = minimo().ToString() + "Cº";
        }
    }
}