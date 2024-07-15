using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pet_shelter.pages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= |DataDirectory|\Data.mdf;Integrated Security=True";

            string username = (string)Session["user"];

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string commandStr = $"select * from userData where username='{username}'";
            connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(commandStr, connectionString);
            DataTable dt = new DataTable();
            adapter.Fill(dt);


        }
    }
}