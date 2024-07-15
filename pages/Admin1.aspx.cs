using System;
using System.Data;
using System.Data.SqlClient;

namespace pet_shelter.pages
{
    public partial class Admin1 : System.Web.UI.Page
    {
        const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= |DataDirectory|\Data.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["currentPage"] = "Admin1";

            if (!(bool)Session["isAdmin"])
                Response.Redirect("error/pug.html");

            const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= |DataDirectory|\Data.mdf;Integrated Security=True";
            SqlConnection conection = new SqlConnection(connectionString);

            string command = $"select * from userData";
            SqlDataAdapter adapter = new SqlDataAdapter(command, connectionString);
            DataTable usersdt = new DataTable();
            adapter.Fill(usersdt);

            string userTable = GetUserHtmlTableFromDataTable(usersdt);
            DivUserTable.InnerHtml = userTable;


            command = $"select * from animalData";
            adapter = new SqlDataAdapter(command, connectionString);
            DataTable animalsdt = new DataTable();
            adapter.Fill(animalsdt);

            string animalsTable = GetHtmlTableFromDataTable(animalsdt);
            DivAnimalsTable.InnerHtml = animalsTable;
        }

        static string GetUserHtmlTableFromDataTable(DataTable dt)
        {
            string htmlTable = "<table class='dataT' border=1>";

            htmlTable += "<tr>";
            for (int colIndex = 0; colIndex < dt.Columns.Count; colIndex++)
            {
                htmlTable += "<>";
                htmlTable += dt.Columns[colIndex].ColumnName;
                htmlTable += "</th>";
            }
            htmlTable += "</tr>";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                htmlTable += "<tr>";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (j == 10)
                    {
                        string str;
                        if (dt.Rows[i][j] == DBNull.Value || (bool)dt.Rows[i][j] == false)
                            str = "User";
                        else
                            str = "Admin";

                        htmlTable += "<td>";
                        htmlTable += str;
                        htmlTable += "</td>";
                    }
                    else
                    {
                        htmlTable += "<td>";
                        htmlTable += dt.Rows[i][j];
                        htmlTable += "</td>";
                    }

                }
                htmlTable += "</tr>";
            }
            htmlTable += "</table>";

            return htmlTable;
        }

        static string GetHtmlTableFromDataTable(DataTable dt)
        {
            string htmlTable = "<table class='dataT' border=1>";

            htmlTable += "<tr>";
            for (int colIndex = 0; colIndex < dt.Columns.Count; colIndex++)
            {
                htmlTable += "<th>";
                htmlTable += dt.Columns[colIndex].ColumnName;
                htmlTable += "</th>";
            }
            htmlTable += "</tr>";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                htmlTable += "<tr>";
                for (int j = 0; j < dt.Columns.Count; j++)
                {                   
                    htmlTable += "<td>";
                    htmlTable += dt.Rows[i][j];
                    htmlTable += "</td>";
                }
                htmlTable += "</tr>";
            }
            htmlTable += "</table>";

            return htmlTable;
        }

        protected void SubmitUpdateUsers_ServerClick(object sender, EventArgs e)
        {
            SqlConnection conection = new SqlConnection(connectionString);

            int id = int.Parse(updateIdUsers.Value);
            string username = updateUsernameUsers.Value;
            string password = updatePasswordUsers.Value;
            bool isAdmin = false;
            if (updateIsAdminUsers.Checked)
                isAdmin = true;


            string commandStr;
            SqlCommand cmd;
            int n;

            if (username == "")
            {
                string sqlCommand = $"update userData set isAdmin='{isAdmin}', password='{password}' where Id='{id}'";

                cmd = new SqlCommand(sqlCommand, conection);
                conection.Open();
                n = cmd.ExecuteNonQuery();
                conection.Close();
                updateResultIdUsers.InnerHtml = $"Result: {n.ToString()}";
                Response.Redirect("Admin1.aspx");
            }
            else
            {
                commandStr = $"select count(*) from userData where username='{username}'";
                cmd = new SqlCommand(commandStr, conection);
                conection.Open();

                n = (int)cmd.ExecuteScalar();
                if (n > 0)
                {
                    updateResultIdUsers.InnerHtml = $"This username is taken, pls try a different username";
                }
                else
                {
                    string sqlCommand = $"update userData set username='{username}', isAdmin='{isAdmin}', password='{password}' where Id='{id}'";

                    cmd = new SqlCommand(sqlCommand, conection);
                    conection.Open();
                    n = cmd.ExecuteNonQuery();
                    conection.Close();
                    updateResultIdUsers.InnerHtml = $"Result: {n.ToString()}";
                    Response.Redirect("Admin1.aspx");
                }
            }
            
        }

        protected void SubmitDeleteUsers_ServerClick(object sender, EventArgs e)
        {
            SqlConnection conection = new SqlConnection(connectionString);
            string sqlCommand = $"delete from userData where username='{deleteUsernameUsers.Value}'";
            SqlCommand cmd = new SqlCommand(sqlCommand, conection);
            conection.Open();
            int n = cmd.ExecuteNonQuery();
            conection.Close();
            deleteResultIdUsers.InnerHtml = $"Result: {n.ToString()}";
            Response.Redirect("Admin1.aspx");
        }

        protected void SubmitUpdateAnimals_ServerClick(object sender, EventArgs e)
        {
            SqlConnection conection = new SqlConnection(connectionString);

            int id = int.Parse(updateIdAnimals.Value);
            string name = updateNameAnimals.Value;
            string applicant = updateApplicantAnimals.Value;

            string commandStr;
            SqlCommand cmd;
            int n;

            conection.Open();

            if (name == "")
            {
                string sqlCommand = $"update animalData set applicant='{applicant}' where Id='{id}'";

                cmd = new SqlCommand(sqlCommand, conection);
                n = cmd.ExecuteNonQuery();
                updateResultIdUsers.InnerHtml = $"Result: {n.ToString()}";
                conection.Close();
                Response.Redirect("Admin1.aspx");
            }
            else
            {

                commandStr = $"select count(*) from animalData where name='{name}'";
                cmd = new SqlCommand(commandStr, conection);

                n = (int)cmd.ExecuteScalar();
                if (n > 0)
                {
                    updateResultIdAnimals.InnerHtml = $"This name is taken, pls try a different username";
                }
                else
                {
                    commandStr = $"update animalData set name='{name}', applicant='{applicant}' where Id='{id}'";

                    cmd = new SqlCommand(commandStr, conection);
                    n = cmd.ExecuteNonQuery();
                    updateResultIdAnimals.InnerHtml = $"Result: {n.ToString()}";
                    conection.Close();
                    Response.Redirect("Admin1.aspx");
                }
            }

        }

        protected void SubmitDeleteAnimals_ServerClick(object sender, EventArgs e)
        {
            SqlConnection conection = new SqlConnection(connectionString);
            string sqlCommand = $"delete from animalData where name='{deleteUsernameAnimals.Value}'";
            SqlCommand cmd = new SqlCommand(sqlCommand, conection);
            conection.Open();
            int n = cmd.ExecuteNonQuery();
            conection.Close();
            deleteResultIdUsers.InnerHtml = $"Result: {n.ToString()}";
            Response.Redirect("Admin1.aspx");
        }
    }
}