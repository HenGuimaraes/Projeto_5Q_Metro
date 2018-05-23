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
        //======================================================================================//
        protected void Page_Load(object sender, EventArgs e)
        {
            btnlabel.Visible = false;
            Label2.Visible = false;

            // aqui voce apaga as mensagens de erros
        }
        //======================================================================================//
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {

            if (btnSenha.Text != btnSenha1.Text)
            {
                btnlabel.Visible = true;
                return;
            }
            // confirma se as senhas batem
            if (string.IsNullOrWhiteSpace(btnnome.Text) || string.IsNullOrWhiteSpace(btnSenha.Text)
                || string.IsNullOrWhiteSpace(btnSenha1.Text) || (DropDownList1.SelectedValue == "0")
                || string.IsNullOrWhiteSpace(login.Text))
            {
                Label2.Visible = true;
                return;
            }// obriga o usuario a preencher todos os espaços



            using (SqlConnection conn = new SqlConnection("Server=tcp:tab132.database.windows.net,1433;Initial Catalog=esporte;Persist Security Info=False;User ID=mateus383@tab132;Password=123456sS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT login from usuario", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        //Obtém os registros, um por vez    
                        while (reader.Read() == true)
                        {

                            string validacao;
                            validacao = reader.GetString(0);

                            if (validacao == login.Text)
                            {

                                login.Text = "o login ja existe tente outro";
                                return;
                            }// aqui valida se o vagao ja tem nomeação igual

                        }
                    }
                }


                //=====================================================================================//
                using (SqlCommand cmd = new SqlCommand("INSERT INTO usuario VALUES (@login, @senha, @Nome, @cargo)", conn))
                {
                    cmd.Parameters.AddWithValue("@login", login.Text);
                    cmd.Parameters.AddWithValue("@senha", btnSenha.Text);
                    cmd.Parameters.AddWithValue("@Nome", btnnome.Text);

                    cmd.Parameters.AddWithValue("@cargo", DropDownList1.SelectedValue);
                    cmd.ExecuteNonQuery();
                }
            }
            // aqui é o codigo pra integrar o registro com o banco de dados

        }
    }
}
