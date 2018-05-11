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
    public partial class pagina1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ulong b = 0;
            int a = 0;
            while (a > 3)
            {
                using (SqlConnection conn = new SqlConnection("Server=tcp:tab132.database.windows.net,1433;Initial Catalog=esporte;Persist Security Info=False;User ID=mateus383@tab132;Password=123456sS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    conn.Open();
                    //=====================================================================================//
                    using (SqlCommand cmd = new SqlCommand("Select temperatura from Temperatura", conn))
                    {


                        aaa.Text = cmd.ExecuteReader().ToString();


                        while (b < 744073709551615)
                        {
                            b = b + 1;
                        }
                        a = a + 1;
                    }
                }
            }
        }
    }
}