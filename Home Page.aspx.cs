using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home_Page : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        Random A = new Random();
        int i = A.Next(1, 8);
        Image1.ImageUrl = "~/Images/" + i.ToString() +".jpg";
    }
}
