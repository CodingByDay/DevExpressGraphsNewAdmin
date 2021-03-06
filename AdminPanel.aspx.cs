using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace peptak
{
    public partial class AdminPanel : System.Web.UI.Page
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private List<String> companiesData = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                fillCompanies();



            } else
            {

            }
        }

        private void fillCompanies()
        {
            try
            {
                conn = new SqlConnection("server=10.100.100.25\\SPLAHOST;Database=graphs;Integrated Security=false;User ID=petpakn;Password=net123321!;");
                conn.Open();
                // Create SqlCommand to select pwd field from users table given supplied userName.
                cmd = new SqlCommand("Select * from companies", conn); /// Intepolation or the F string. C# > 5.0       
                // Execute command and fetch pwd field into lookupPassword string.
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    companiesData.Add(sdr["company_name"].ToString());

                }
                companiesView.DataSource = companiesData;
                companiesView.DataBind();


                cmd.Dispose();
                conn.Close();


            }
            catch (Exception ex)
            {

            }
        }





    }
}