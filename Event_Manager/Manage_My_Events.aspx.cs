using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Event_Manager_Manage_My_Events : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["App_conniction"].ConnectionString);

            if (!IsPostBack)
            {

                int _Event_Manager_Session_Id = 0;
                int.TryParse(Session["Event_Manager_Session_Id"].ToString(), out _Event_Manager_Session_Id);
                
                FillData_Tourit_Places_Search();

                dt = Events_Search(0, _Event_Manager_Session_Id, 0, "", "", "", "", 0);
                ClearControls();
            }

        }
        catch (Exception ex)
        {
            Response.Redirect("Default.aspx");
        }
    }

 

    private DataTable Tourit_Places_Search()
    {
        cmd = new SqlCommand();
        SqlDataAdapter da = default(SqlDataAdapter);
        dt = new DataTable();
        try
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Tourit_Places_Search";

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);



        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }
        return dt;
    }

    public void FillData_Tourit_Places_Search()
    {
        Ddl_Tourist_Place_Id.DataSource = Tourit_Places_Search();
        Ddl_Tourist_Place_Id.DataTextField = "Name";
        Ddl_Tourist_Place_Id.DataValueField = "Id";
        Ddl_Tourist_Place_Id.DataBind();

    }

   
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        //عملية الاظافة
        DataTable dt1 = new DataTable();

        int _Id = 0;
        int.TryParse(lbl_Id.Text, out _Id);

        int _Event_Manager_Session_Id = 0;
        int.TryParse(Session["Event_Manager_Session_Id"].ToString(), out _Event_Manager_Session_Id);


        int _Tourist_Place_Id = 0;
        int.TryParse(Ddl_Tourist_Place_Id.SelectedValue.ToString(), out _Tourist_Place_Id);


        int _Tickit_Price = 0;
        int.TryParse(txt_Tickit_Price.Text, out _Tickit_Price);


        if (_Id == 0 && FileUpload1.HasFile == true)
        {

            string _img1 = "UpLoad/" + DateTime.Now.Minute.ToString() + FileUpload1.FileName;
            FileUpload1.SaveAs(Server.MapPath("../Admin/UpLoad/") + DateTime.Now.Minute.ToString() + FileUpload1.FileName);
 

            bool x = Events_Save(0, _Event_Manager_Session_Id, _Tourist_Place_Id, txt_Name.Text, txt_Description.Text, txt_Date_Times.Text, txt_Conditions.Text, _Tickit_Price, _img1);


            if (x == true)
            {

                Events_Search(0, _Event_Manager_Session_Id, 0, "", "", "", "", 0);
                ClearControls();

                lbl_SaveSuccess.Text = " Added successfully";

            }
            else
            {
                lbl_SaveSuccess.Text = " Not added";
            }

        }
        else if (_Id > 0 && FileUpload1.HasFile == true)
        {

            string _img1 = "UpLoad/" + DateTime.Now.Minute.ToString() + FileUpload1.FileName;
            FileUpload1.SaveAs(Server.MapPath("../Admin/UpLoad/") + DateTime.Now.Minute.ToString() + FileUpload1.FileName);




            bool x = Events_Save(_Id, _Event_Manager_Session_Id, _Tourist_Place_Id, txt_Name.Text, txt_Description.Text, txt_Date_Times.Text, txt_Conditions.Text, _Tickit_Price, _img1);

            if (x == true)
            {

                Events_Search(0, _Event_Manager_Session_Id, 0, "", "", "", "", 0);

                ClearControls();
                lbl_SaveSuccess.Text = " Edited successfully";

            }
            else
            {
                lbl_SaveSuccess.Text = " Has not been Edited  ";
            }
        }
        else if (_Id > 0 && FileUpload1.HasFile == false)
        {

            string _img1 = Image1.ImageUrl.ToString();


            bool x = Events_Save(_Id, _Event_Manager_Session_Id, _Tourist_Place_Id, txt_Name.Text, txt_Description.Text, txt_Date_Times.Text, txt_Conditions.Text, _Tickit_Price, _img1);

            if (x == true)
            {

                Events_Search(0, _Event_Manager_Session_Id, 0, "", "", "", "", 0);

                ClearControls();
                lbl_SaveSuccess.Text = " Edited successfully";

            }
            else
            {
                lbl_SaveSuccess.Text = " Has not been Edited  ";
            }

        }

    }

    protected void btn_Clear_Click(object sender, EventArgs e)
    {
        Events_Search(0, 0, 0, "", "", "", "", 0);
        ClearControls();

    }

    protected void btn_Search_Click(object sender, EventArgs e)
    {
        int _Event_Manager_Session_Id = 0;
        int.TryParse(Session["Event_Manager_Session_Id"].ToString(), out _Event_Manager_Session_Id);


        int _Tourist_Place_Id = 0;
        int.TryParse(Ddl_Tourist_Place_Id.SelectedValue.ToString(), out _Tourist_Place_Id);

        int _Tickit_Price = 0;
        int.TryParse(txt_Tickit_Price.Text, out _Tickit_Price);

        Events_Search(0, _Event_Manager_Session_Id, _Tourist_Place_Id, txt_Name.Text, txt_Description.Text, txt_Date_Times.Text, txt_Conditions.Text, _Tickit_Price);
    }

    protected void gvEvents_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            int _Event_Manager_Session_Id = 0;
            int.TryParse(Session["Event_Manager_Session_Id"].ToString(), out _Event_Manager_Session_Id);


            gvEvents.PageIndex = e.NewPageIndex;
            Events_Search(0, _Event_Manager_Session_Id, 0, "", "", "", "", 0);
            ClearControls();
        }
        catch (Exception ex)
        {

        }
    }

    protected void gvEvents_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int _Event_Manager_Session_Id = 0;
            int.TryParse(Session["Event_Manager_Session_Id"].ToString(), out _Event_Manager_Session_Id);


            if (e.CommandName == "Delte")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                bool del = Events_Delete(id);
                if (del == true)
                {
                    Events_Search(0, _Event_Manager_Session_Id, 0, "", "", "", "", 0);
                    ClearControls();
                }
            }
            else if (e.CommandName == "updte")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                Events_Search(id, _Event_Manager_Session_Id, 0, "", "", "", "", 0);



            }
        }
        catch (Exception ex)
        {
            lbl_SaveSuccess.Text = "Update  Error..";
        }

    }

    private void ClearControls()
    {
        lbl_Id.Text = "0";
        txt_Conditions.Text = "";
        txt_Description.Text = "";
        txt_Name.Text = "";
        Image1.Visible = false;
        txt_Tickit_Price.Text = "";
        lbl_SaveSuccess.Text = "";

    }

    private DataTable Events_Search(int _Id, int _Event_Manager_Id, int _Tourist_Place_Id, string _Name, string _Description, string _Date_Times, string _Conditions, int _Tickit_Price)
    {
        cmd = new SqlCommand();
        SqlDataAdapter da = default(SqlDataAdapter);
        dt = new DataTable();
        try
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Events_Search";
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = _Id;
            cmd.Parameters.Add("@Event_Manager_Id", SqlDbType.Int).Value = _Event_Manager_Id;
            cmd.Parameters.Add("@Tourist_Place_Id", SqlDbType.Int).Value = _Tourist_Place_Id;
            cmd.Parameters.Add("@Tickit_Price", SqlDbType.Int).Value = _Tickit_Price;

            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = _Name;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = _Description;


            cmd.Parameters.Add("@Conditions", SqlDbType.NVarChar).Value = _Conditions;
            cmd.Parameters.Add("@Date_Times", SqlDbType.NVarChar).Value = _Date_Times;





            da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            if (dt.Rows.Count == 1)
            {

                Image1.Visible = true;


                lbl_Id.Text = dt.Rows[0][0].ToString();
               // Ddl_Event_Manager_Id.SelectedValue = dt.Rows[0][1].ToString();
                Ddl_Tourist_Place_Id.SelectedValue = dt.Rows[0][2].ToString();
                txt_Tickit_Price.Text = dt.Rows[0][3].ToString();
                txt_Name.Text = dt.Rows[0][4].ToString();
                txt_Description.Text = dt.Rows[0][5].ToString();
                Image1.ImageUrl = "../Admin/"+dt.Rows[0][6].ToString();
                txt_Conditions.Text = dt.Rows[0][7].ToString();
                txt_Date_Times.Text = dt.Rows[0][8].ToString();





            }
            gvEvents.DataSource = dt;
            gvEvents.DataBind();

        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }
        return dt;
    }

    public bool Events_Save(int _id, int _Event_Manager_Id, int _Tourist_Place_Id, string _Name, string _Description, string _Date_Times, string _Conditions, int _Tickit_Price, string _Img1)
    {
        cmd = new SqlCommand();
        try
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Events_Save";
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = _id;
            cmd.Parameters.Add("@Event_Manager_Id", SqlDbType.Int).Value = _Event_Manager_Id;
            cmd.Parameters.Add("@Tourist_Place_Id", SqlDbType.Int).Value = _Tourist_Place_Id;
            cmd.Parameters.Add("@Tickit_Price", SqlDbType.Int).Value = _Tickit_Price;

            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = _Name;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = _Description;
            cmd.Parameters.Add("@Conditions", SqlDbType.NVarChar).Value = _Conditions;
            cmd.Parameters.Add("@Date_Times", SqlDbType.NVarChar).Value = _Date_Times;
            cmd.Parameters.Add("@Img1", SqlDbType.NVarChar).Value = _Img1;


            if (cmd.ExecuteNonQuery() > 0)
            {
                con.Close();
                return false;
            }
            else
            {
                con.Close();
                return true;

            }

        }
        catch (Exception ex)
        {
            con.Close();
            return false;

        }
    }

    private bool Events_Delete(int _Id)
    {
        cmd = new SqlCommand();
        try
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Events_Delete";
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = _Id;

            if (cmd.ExecuteNonQuery() != 0)
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }

        }
        catch (Exception ex)
        {
            con.Close();
            return false;
        }
    }

}