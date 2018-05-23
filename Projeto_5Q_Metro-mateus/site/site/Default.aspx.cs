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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblInvalido.Visible = false;
            txtLogin.Focus();
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Server=tcp:tab132.database.windows.net,1433;Initial Catalog=esporte;Persist Security Info=False;User ID=mateus383@tab132;Password=123456sS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                conn.Open();
















                using (SqlCommand cmd = new SqlCommand("SELECT login, senha, cargo FROM Usuario WHERE login = @login AND senha = @senha", conn))
                {


               
                    

                            
                        if (txtLogin.Text != "" && txtSenha.Text != "")
                        {

                        cmd.Parameters.AddWithValue("@login", txtLogin.Text);
                        cmd.Parameters.AddWithValue("@senha", txtSenha.Text);

                            //Com o dataReader eu consigo guardar a consulta em uma variavel
                            SqlDataReader dr = cmd.ExecuteReader();
                          
                            //Leia a consulta
                            dr.Read();
                            int codCargo = dr.GetInt32(2);

                            if (dr.HasRows)
                            {
                                if (codCargo == 1)
                                {
                                    Response.Redirect("http://localhost:2616/Home.aspx");
                                }
                                else
                                {
                                    Response.Redirect("http://localhost:2616/Home2.aspx");
                                }
                            }
                            else
                            {
                                lblInvalido.Text = "Login ou senha inválidos, digite novamente!";
                                lblInvalido.Visible = true;
                            }
                        }
                        else
                        {
                            lblInvalido.Text = "Preencha todos os campos";
                            lblInvalido.Visible = true;
                        }
                    
                }
            }
        }
    }
}
