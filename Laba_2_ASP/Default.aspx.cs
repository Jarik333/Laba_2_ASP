using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_PreRender(object sender, EventArgs e)
    {
        string strSQLConnection = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        SqlConnection sqlCon = new SqlConnection(strSQLConnection);


        sqlCon.Open();
        SqlCommand cmd_SQL = new SqlCommand("Select * From dbo.Phones_Test", sqlCon);
        cmd_SQL.CommandType = CommandType.Text;
        
        SqlDataReader rdr_SQL = cmd_SQL.ExecuteReader();
        while (rdr_SQL.Read())
        { // Считывание полей записи:
            rdr_SQL.GetString(1);
            rdr_SQL.GetString(2);
            rdr_SQL.GetString(3);

        }
        rdr_SQL.Close();
        GridView1.DataBind();

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        string strSQLConnection = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        
        SqlConnection sqlCon = new SqlConnection(strSQLConnection);
        
        
            sqlCon.Open();
            SqlCommand cmd_SQL = new SqlCommand("INSERT INTO dbo.Phones_Test (name,number, adr) VALUES(' " + TextBox1.Text + " ', ' " + TextBox2.Text + " ', ' " + TextBox3.Text + " ')", sqlCon);
            cmd_SQL.CommandType = CommandType.Text;
            cmd_SQL.ExecuteNonQuery();
         sqlCon.Close(); 
    }
}