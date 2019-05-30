using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class search_deases : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection("Data Source=MOMERUL-PC;Database=Sample;Integrated Security=true");
        string str = @"SELECT * FROM deasea WHERE symptoms LIKE @search";
        con.Open();
        SqlCommand xp = new SqlCommand(str, con);
        xp.Parameters.AddWithValue("@search", "%" + txtsymptoms.Text.ToString().Max() + "%");



        xp.ExecuteNonQuery();

        if (txtsymptoms.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter symptoms')", true);
        }
        else
        {

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = xp;
            DataSet ds = new DataSet();
            da.Fill(ds, "symptoms");
            GridView1.DataSource =ds;
            GridView1.DataBind();
        }

       
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/doctorFind.aspx");
    }
}
