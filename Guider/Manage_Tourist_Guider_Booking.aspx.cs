using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Guider_Manage_Tourist_Guider_Booking : System.Web.UI.Page
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
                FillData_Tourists_Search();
                FillData_Guider_Places_Search();

                int _Guider_Session_Id = 0;
                int.TryParse(Session["Guider_Session_Id"].ToString(), out _Guider_Session_Id);

                dt = Tourist_Guider_Booking_Search_Guider(0, 0, 0, "", "", _Guider_Session_Id);

                ClearControls();
            }

        }
        catch (Exception ex)
        {
            Response.Redirect("Default.aspx");
        }
    }

    public void FillData_Tourists_Search()
    {
        ddl_Tourist_Id.DataSource = Tourists_Search();
        ddl_Tourist_Id.DataTextField = "Full_Name";
        ddl_Tourist_Id.DataValueField = "Id";
        ddl_Tourist_Id.DataBind();

    }

    private DataTable Tourists_Search()
    {
        cmd = new SqlCommand();
        SqlDataAdapter da = default(SqlDataAdapter);
        dt = new DataTable();
        try
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Tourists_Search";

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

    public void FillData_Guider_Places_Search()
    {
        Ddl_Guider_Places_Id.DataSource = Guider_Places_Search();
        Ddl_Guider_Places_Id.DataTextField = "Guider_Places";
        Ddl_Guider_Places_Id.DataValueField = "Id";
        Ddl_Guider_Places_Id.DataBind();

    }

    private DataTable Guider_Places_Search()
    {
        cmd = new SqlCommand();
        SqlDataAdapter da = default(SqlDataAdapter);
        dt = new DataTable();
        try
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Guider_Places_Search";

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

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        //عملية الاظافة

        int _Id = 0;
        int.TryParse(lbl_Id.Text, out _Id);

        int _Guider_Places_Id = 0;
        int.TryParse(Ddl_Guider_Places_Id.SelectedValue.ToString(), out _Guider_Places_Id);

        int _Guider_Session_Id = 0;
        int.TryParse(Session["Guider_Session_Id"].ToString(), out _Guider_Session_Id);

        int _Tourist_Id = 0;
        int.TryParse(ddl_Tourist_Id.SelectedValue.ToString(), out _Tourist_Id);

        if (_Id == 0)
        {

            bool x = Tourist_Guider_Booking_Save(0, _Guider_Places_Id, _Tourist_Id, txt_Date_Time.Text, txt_Notes.Text);

            if (x == true)
            {

                Tourist_Guider_Booking_Search_Guider(0, 0, 0, "", "", _Guider_Session_Id);
                ClearControls();

                lbl_SaveSuccess.Text = " Added successfully";

            }
            else
            {
                lbl_SaveSuccess.Text = " Not added";
            }

        }
        else if (_Id > 0)
        {

            bool x = Tourist_Guider_Booking_Save(_Id, _Guider_Places_Id, _Tourist_Id, txt_Date_Time.Text, txt_Notes.Text);
            if (x == true)
            {

                Tourist_Guider_Booking_Search_Guider(0, 0, 0, "", "", _Guider_Session_Id);

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

        int _Guider_Session_Id = 0;
        int.TryParse(Session["Guider_Session_Id"].ToString(), out _Guider_Session_Id);

        Tourist_Guider_Booking_Search_Guider(0, 0, 0, "", "", _Guider_Session_Id);
        ClearControls();

    }

    protected void btn_Search_Click(object sender, EventArgs e)
    {
        int _Guider_Places_Id = 0;
        int.TryParse(Ddl_Guider_Places_Id.SelectedValue.ToString(), out _Guider_Places_Id);

        int _Tourist_Id = 0;
        int.TryParse(ddl_Tourist_Id.SelectedValue.ToString(), out _Tourist_Id);


        int _Guider_Session_Id = 0;
        int.TryParse(Session["Guider_Session_Id"].ToString(), out _Guider_Session_Id);

        Tourist_Guider_Booking_Search_Guider(0, _Guider_Places_Id, _Tourist_Id, txt_Date_Time.Text, txt_Notes.Text, _Guider_Session_Id);

    }

    private void ClearControls()
    {
        lbl_Id.Text = "0";

        txt_Date_Time.Text = "";
        txt_Notes.Text = "";

        lbl_SaveSuccess.Text = "";

    }

    private DataTable Tourist_Guider_Booking_Search_Guider(int _Id, int _Guider_Places_Id, int _Tourist_Id, string _Date_Time, string _Notes, int _Guider_Id)
    {
        cmd = new SqlCommand();
        SqlDataAdapter da = default(SqlDataAdapter);
        dt = new DataTable();
        try
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Tourist_Guider_Booking_Search_Guider";
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = _Id;

            cmd.Parameters.Add("@Guider_Places_Id", SqlDbType.Int).Value = _Guider_Places_Id;
            cmd.Parameters.Add("@Tourist_Id", SqlDbType.Int).Value = _Tourist_Id;
            cmd.Parameters.Add("@Date_Time", SqlDbType.NVarChar).Value = _Date_Time;
            cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = _Notes;
            cmd.Parameters.Add("@Guider_Id", SqlDbType. Int).Value = _Guider_Id;

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            if (dt.Rows.Count == 1)
            {

                lbl_Id.Text = dt.Rows[0][0].ToString();
                Ddl_Guider_Places_Id.SelectedValue = dt.Rows[0][1].ToString();
                ddl_Tourist_Id.SelectedValue = dt.Rows[0][2].ToString();
                txt_Date_Time.Text = dt.Rows[0][3].ToString();
                txt_Notes.Text = dt.Rows[0][4].ToString();

            }
            gvTourist_Guider_Booking.DataSource = dt;
            gvTourist_Guider_Booking.DataBind();

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

    public bool Tourist_Guider_Booking_Save(int _id, int _Guider_Places_Id, int _Tourist_Id, string _Date_Time, string _Notes)
    {
        cmd = new SqlCommand();
        try
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Tourist_Guider_Booking_Save";
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = _id;
            cmd.Parameters.Add("@Guider_Places_Id", SqlDbType.Int).Value = _Guider_Places_Id;
            cmd.Parameters.Add("@Tourist_Id", SqlDbType.Int).Value = _Tourist_Id;
            cmd.Parameters.Add("@Date_Time", SqlDbType.NVarChar).Value = _Date_Time;
            cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = _Notes;

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

    private bool Tourist_Guider_Booking_Delete(int _Id)
    {
        cmd = new SqlCommand();
        try
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Tourist_Guider_Booking_Delete";
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

    protected void gvTourist_Guider_Booking_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            int _Guider_Session_Id = 0;
            int.TryParse(Session["Guider_Session_Id"].ToString(), out _Guider_Session_Id);

            gvTourist_Guider_Booking.PageIndex = e.NewPageIndex;
            Tourist_Guider_Booking_Search_Guider(0, 0, 0, "", "", _Guider_Session_Id);
            ClearControls();
        }
        catch (Exception ex)
        {

        }

    }

    protected void gvTourist_Guider_Booking_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int _Guider_Session_Id = 0;
            int.TryParse(Session["Guider_Session_Id"].ToString(), out _Guider_Session_Id);


            if (e.CommandName == "Delte")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                bool del = Tourist_Guider_Booking_Delete(id);
                if (del == true)
                {
                    Tourist_Guider_Booking_Search_Guider(0, 0, 0, "", "", _Guider_Session_Id);
                    ClearControls();
                }
            }
            else if (e.CommandName == "updte")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                Tourist_Guider_Booking_Search_Guider(id, 0, 0, "", "", _Guider_Session_Id);
            }
        }
        catch (Exception ex)
        {
            lbl_SaveSuccess.Text = "Update  Error..";
        }
    }
}