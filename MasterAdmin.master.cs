using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterAdmin : System.Web.UI.MasterPage
{
     protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            string _Full_Name = Session["Admin_Full_Name"].ToString();

            lbl_Admin_Name.Text = _Full_Name;

        }
        catch (Exception ex)
        {
            Response.Redirect("../Login.aspx"); 
        }
    

    }
  
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("../Login.aspx"); 
    }
}
