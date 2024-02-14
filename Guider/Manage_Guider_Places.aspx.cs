using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Guider_Manage_Guider_Places : System.Web.UI.Page
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

                int _Guider_Session_Id = 0;
                int.TryParse(Session["Guider_Session_Id"].ToString(), out _Guider_Session_Id);

                
                FillData_Tourit_Places_Search();

                dt = Guider_Places_Search(0, _Guider_Session_Id, 0, "", "");
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

        int _Guider_Session_Id = 0;
        int.TryParse(Session["Guider_Session_Id"].ToString(), out _Guider_Session_Id);



        int _Tourist_Place_Id = 0;
        int.TryParse(Ddl_Tourist_Place_Id.SelectedValue.ToString(), out _Tourist_Place_Id);



        if (_Id == 0)
        {

            bool x = Guider_Places_Save(0, _Guider_Session_Id, _Tourist_Place_Id, txt_Details.Text, txt_Price_Hour.Text);

            if (x == true)
            {

                Guider_Places_Search(0, _Guider_Session_Id, 0, "", "");
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



            bool x = Guider_Places_Save(_Id, _Guider_Session_Id, _Tourist_Place_Id, txt_Details.Text, txt_Price_Hour.Text);
            if (x == true)
            {

                Guider_Places_Search(0, _Guider_Session_Id, 0, "", "");

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



        Guider_Places_Search(0, _Guider_Session_Id, 0, "", "");
        ClearControls();

    }

    protected void btn_Search_Click(object sender, EventArgs e)
    {
        int _Guider_Session_Id = 0;
        int.TryParse(Session["Guider_Session_Id"].ToString(), out _Guider_Session_Id);


        int _Tourist_Place_Id = 0;
        int.TryParse(Ddl_Tourist_Place_Id.SelectedValue.ToString(), out _Tourist_Place_Id);



        Guider_Places_Search(0, _Guider_Session_Id, _Tourist_Place_Id, txt_Details.Text, txt_Price_Hour.Text);
    }

    protected void gvGuider_Places_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            int _Guider_Session_Id = 0;
            int.TryParse(Session["Guider_Session_Id"].ToString(), out _Guider_Session_Id);

            gvGuider_Places.PageIndex = e.NewPageIndex;
            Guider_Places_Search(0, _Guider_Session_Id, 0, "", "");
            ClearControls();
        }
        catch (Exception ex)
        {

        }
    }

    protected void gvGuider_Places_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int _Guider_Session_Id = 0;
            int.TryParse(Session["Guider_Session_Id"].ToString(), out _Guider_Session_Id);


            if (e.CommandName == "Delte")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                bool del = Guider_Places_Delete(id);
                if (del == true)
                {
                    Guider_Places_Search(0, _Guider_Session_Id, 0, "", "");
                    ClearControls();
                }
            }
            else if (e.CommandName == "updte")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                Guider_Places_Search(id, _Guider_Session_Id, 0, "", "");



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

        txt_Price_Hour.Text = "";
        txt_Details.Text = "";

        lbl_SaveSuccess.Text = "";

    }

    private DataTable Guider_Places_Search(int _Id, int _Guider_Id, int _Tourist_Place_Id, string _Details, string _Price_Hour)
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
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = _Id;
            cmd.Parameters.Add("@Guider_Id", SqlDbType.Int).Value = _Guider_Id;
            cmd.Parameters.Add("@Tourist_Place_Id", SqlDbType.Int).Value = _Tourist_Place_Id;
            cmd.Parameters.Add("@Details", SqlDbType.NVarChar).Value = _Details;
            cmd.Parameters.Add("@Price_Hour", SqlDbType.NVarChar).Value = _Price_Hour;




            da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            if (dt.Rows.Count == 1)
            {


                lbl_Id.Text = dt.Rows[0][0].ToString();
              //  Ddl_Guider_Id.SelectedValue = dt.Rows[0][2].ToString();
                Ddl_Tourist_Place_Id.SelectedValue = dt.Rows[0][1].ToString();
                txt_Details.Text = dt.Rows[0][3].ToString();
                txt_Price_Hour.Text = dt.Rows[0][4].ToString();




            }
            gvGuider_Places.DataSource = dt;
            gvGuider_Places.DataBind();

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

    public bool Guider_Places_Save(int _id, int _Guider_Id, int _Tourist_Place_Id, string _Details, string _Price_Hour)
    {
        cmd = new SqlCommand();
        try
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Guider_Places_Save";
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = _id;
            cmd.Parameters.Add("@Guider_Id", SqlDbType.Int).Value = _Guider_Id;
            cmd.Parameters.Add("@Tourist_Place_Id", SqlDbType.Int).Value = _Tourist_Place_Id;
            cmd.Parameters.Add("@Details", SqlDbType.NVarChar).Value = _Details;
            cmd.Parameters.Add("@Price_Hour", SqlDbType.NVarChar).Value = _Price_Hour;





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

    private bool Guider_Places_Delete(int _Id)
    {
        cmd = new SqlCommand();
        try
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Guider_Places_Delete";
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