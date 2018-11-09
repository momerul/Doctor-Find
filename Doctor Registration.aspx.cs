using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Doctor_Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        int result = 0;
        SqlConnection con = new SqlConnection("Data Source=MOMERUL-PC;Database=Sample;Integrated Security=true");
        con.Open();
        SqlCommand scmd = new SqlCommand("Insert into Doctor_Info(Name,Gender,Degree,Experiences,Specialist,Fee,Hospital,Hospital_Address,Date,Mobile) values(@Name,@Gender,@Degree,@Experiences,@Specialist,@Fee,@Hospital,@Hospital_Address,@Date,@Mobile)", con);

        
        scmd.Parameters.AddWithValue("@Name",txtName.Text);
        scmd.Parameters.AddWithValue("@Gender",RadioButtonList1.Text);
        scmd.Parameters.AddWithValue("@Degree",txtDegree.Text);
        scmd.Parameters.AddWithValue("@Experiences", txtExperience.Text.ToString());
        scmd.Parameters.AddWithValue("@Specialist", txtSpecialist.Text);
        scmd.Parameters.AddWithValue("@Fee", txtFee.Text.ToString());
        scmd.Parameters.AddWithValue("@Hospital", txtHospital.Text);
        scmd.Parameters.AddWithValue("@Hospital_Address", txtHospitalAddress.Text);
        scmd.Parameters.AddWithValue("@Date", txtDate.Text.ToString());
        scmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
        

        result = scmd.ExecuteNonQuery();

        if (result == 1)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
            
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Not Successfully')", true);
        }

        txtDate.Text = string.Empty;
        txtDegree.Text = string.Empty;
        txtExperience.Text = string.Empty;
        txtSpecialist.Text = string.Empty;
        txtFee.Text = string.Empty;
        txtHospital.Text = string.Empty;
        txtHospitalAddress.Text = string.Empty;
        txtName.Text = string.Empty;
        txtMobile.Text = string.Empty;
        RadioButtonList1.Text = string.Empty;
    }
}