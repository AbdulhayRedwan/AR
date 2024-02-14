using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Tourists_MasterTour : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            string _Full_Name = Session["Tourist_Full_Name"].ToString();

            lbl_User_Name.Text = _Full_Name;

        }
        catch (Exception ex)
        {
            Response.Redirect("../Login.aspx");
        }


    }
    protected void btn_Logout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("../Login.aspx");
    }
}
