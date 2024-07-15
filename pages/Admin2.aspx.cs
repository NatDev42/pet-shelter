using System;
using System.Data;
using System.Data.SqlClient;

namespace pet_shelter.pages
{
    public partial class Admin2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["currentPage"] = "Admin2";

            if (!(bool)Session["isAdmin"])
                Response.Redirect("error/pug.html");


            const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= |DataDirectory|\Data.mdf;Integrated Security=True";

            string command = $"select * from entries";
            SqlDataAdapter adapter = new SqlDataAdapter(command, connectionString);
            DataTable dt = new DataTable();

            adapter.Fill(dt);

            int entriesAll = (int)dt.Rows[0]["Entries"];
            int entriesIncGuests = (int)dt.Rows[0]["EntriesIncludingGuests"];

            EntriesId.InnerHtml = "Total Entries of All Time (Not Including Guests):" + entriesAll.ToString();
            EntriesIncGuestsId.InnerHtml = "Total Entries of All Time (Including Guests):" + entriesIncGuests.ToString();
        }
    }
}