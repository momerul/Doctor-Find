using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class LoginForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void Login_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection("Data Source=MOMERUL-PC;Database=Sample;Integrated Security=true");
        con.Open();

        SqlCommand scmd = new SqlCommand("Select * from PersonInfo where UserName=@UserName and Password=@Password ", con);

        scmd.Parameters.AddWithValue("@Password",txtPassword.Text);
        scmd.Parameters.AddWithValue("@UserName",txtUserName.Text);
        SqlDataAdapter da = new SqlDataAdapter(scmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        if(dt.Rows.Count>0)
        {
            Response.Redirect("~/search_deases.aspx");
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(),"alertMessage", "alert('Login Not Successfull')", true);
        }
    }
}
