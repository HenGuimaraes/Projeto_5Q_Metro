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
    public partial class tabela : System.Web.UI.Page
    {

        ListItem item;
        int vagoes = 0;
        int a;
        string o;

        protected void Page_Load(object sender, EventArgs e)
        {

            using (SqlConnection conn = new SqlConnection("Server=tcp:tab132.database.windows.net,1433;Initial Catalog=esporte;Persist Security Info=False;User ID=mateus383@tab132;Password=123456sS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                conn.Open();
                //=====================================================================================//
                string a = "trem";
                using (SqlCommand cmd = new SqlCommand($"SELECT cod_trem,nome_trem From {a} order by cod_trem", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read() == true) //ele ira ler do 0 até o ultimo dado 
                        {

                            int valor1 = reader.GetInt32(0);
                            string valor = valor1.ToString();
                            string descricao = reader.GetString(1);
                            //pegando as informaços que foram lidas


                            item = new ListItem(descricao, valor);  //descricao é oq o usuario ve
                                                                    //valor é o id do item, "value"

                            if (IsPostBack == false)
                            {
                                trens.Items.Add(item);
                            }
                            a = trens.SelectedValue;

                            int.TryParse(a, out vagoes); // aqui ele adiciona no dropdown 

                        }
                    }

                }
            }



        }

        protected void att_Click(object sender, EventArgs e)
        {

            a++;
            if (a >= 2)
            {
                trens.Items.Clear();
            }

            int contador = 0, diminuidor = vagoes + 1;
            string[] vagois = new string[vagoes];
            string[] vagois1 = new string[vagoes];
            using (SqlConnection conn = new SqlConnection("Server=tcp:tab132.database.windows.net,1433;Initial Catalog=esporte;Persist Security Info=False;User ID=mateus383@tab132;Password=123456sS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand($"SELECT cod_vagao,nome_vagao From Vagao where cod_trem={vagoes}", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        contador = 0;

                        while (reader.Read() == true) //ele ira ler do 0 até o ultimo dado 
                        {

                            int valorvagao = reader.GetInt32(0);
                            string descricao = reader.GetString(1);

                            item = new ListItem(descricao, valorvagao.ToString());
                            vagau.Items.Add(item);
                            vagois[contador] = item.Text;
                            contador++;

                        }
                        vagao1.Text = vagois[0];
                        vagao2.Text = vagois[1];
                        vagao3.Text = vagois[2];
                        vagao4.Text = vagois[3];
                        vagao5.Text = vagois[4];
                        vagao6.Text = vagois[5];
                        vagao7.Text = vagois[6];
                        vagao8.Text = vagois[7];
                        vagao1.Visible = true;
                        vagao2.Visible = true;
                        vagao3.Visible = true;
                        vagao4.Visible = true;
                        vagao5.Visible = true;
                        vagao6.Visible = true;
                        vagao7.Visible = true;
                        vagao8.Visible = true;

                        //    cmd.ExecuteNonQuery();
                    }
                }

              //  using (SqlCommand cmd = new SqlCommand($"SELECT avg (temperatura) FROM Temperatura WHERE cod_temperatura between (SELECT MAX(cod_Temperatura) FROM temperatura) and (SELECT MAX(cod_Temperatura) FROM temperatura){-50}", conn))
              //  {
              //      using (SqlDataReader reader = cmd.ExecuteReader())
              //      {
              //
              //          int temp = reader.GetInt32(0);
              //          label1.Text = temp.ToString();
              //      }
              //      
              //  }
            }

        }

    }
}