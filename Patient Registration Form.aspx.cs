using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Patient_Registration_Form : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int result = 0;
        SqlConnection con = new SqlConnection("Data Source=MOMERUL-PC;Database=Sample;Integrated Security=true");
        con.Open();
        SqlCommand scmd = new SqlCommand("Insert into PersonInfo(UserName,Age,Address,Password,Gender,Mobile) values(@UserName,@Age,@Address,@Password,@Gender,@Mobile)", con);

        scmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
        scmd.Parameters.AddWithValue("@Age", txtAge.Text);
        scmd.Parameters.AddWithValue("@Address", txtAddress.Text);
        scmd.Parameters.AddWithValue("@Password", txtPassword.Text);
        scmd.Parameters.AddWithValue("@Gender", RadioButtonList1.Text);
        scmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);

        result = scmd.ExecuteNonQuery();
        if(result==1)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);

        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Not Successfully')", true);
        } 

        txtUserName.Text = string.Empty;
        txtAge.Text = string.Empty;
        txtAddress.Text = string.Empty;
        RadioButtonList1.Text = string.Empty;
        txtPassword.Text = string.Empty;
        txtMobile.Text = string.Empty;
    }
}