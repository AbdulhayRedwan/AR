using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Manage_Tourit_Places : System.Web.UI.Page
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
                FillData_City_Search();
                FillData_Tourism_Types_Search();

                dt = Tourit_Places_Search(0, 0, 0, "", "", "", "", "", "", "");
                ClearControls();
            }

        }
        catch (Exception ex)
        {
            Response.Redirect("Default.aspx");
        }
    }

    public void FillData_City_Search()
    {
        Ddl_City_Id.DataSource = Country_Cities_Search();
        Ddl_City_Id.DataTextField = "Name";
        Ddl_City_Id.DataValueField = "Id";
        Ddl_City_Id.DataBind();

    }

    private DataTable Country_Cities_Search()
    {
        cmd = new SqlCommand();
        SqlDataAdapter da = default(SqlDataAdapter);
        dt = new DataTable();
        try
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Country_Cities_Search";

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

    public void FillData_Tourism_Types_Search()
    {
        Ddl_Tourism_Type_Id.DataSource = Tourism_Types_Search();
        Ddl_Tourism_Type_Id.DataTextField = "Name";
        Ddl_Tourism_Type_Id.DataValueField = "Id";
        Ddl_Tourism_Type_Id.DataBind();

    }

    private DataTable Tourism_Types_Search()
    {
        cmd = new SqlCommand();
        SqlDataAdapter da = default(SqlDataAdapter);
        dt = new DataTable();
        try
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Tourism_Types_Search";

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
        DataTable dt1 = new DataTable();

        int _Id = 0;
        int.TryParse(lbl_Id.Text, out _Id);

        int _City_Id = 0;
        int.TryParse(Ddl_City_Id.SelectedValue.ToString(), out _City_Id);


        int _Tourism_Type_Id = 0;
        int.TryParse(Ddl_Tourism_Type_Id.SelectedValue.ToString(), out _Tourism_Type_Id);


        if (_Id == 0 && FileUpload1.HasFile == true && FileUpload2.HasFile == true && FileUpload3.HasFile == true && FileUpload4.HasFile == true)
        {

            string _img1 = "UpLoad/" + DateTime.Now.Minute.ToString() + FileUpload1.FileName;
            FileUpload1.SaveAs(Server.MapPath("./UpLoad/") + DateTime.Now.Minute.ToString() + FileUpload1.FileName);

            string _img2 = "UpLoad/" + DateTime.Now.Minute.ToString() + FileUpload2.FileName;
            FileUpload2.SaveAs(Server.MapPath("./UpLoad/") + DateTime.Now.Minute.ToString() + FileUpload2.FileName);

            string _img3 = "UpLoad/" + DateTime.Now.Minute.ToString() + FileUpload3.FileName;
            FileUpload3.SaveAs(Server.MapPath("./UpLoad/") + DateTime.Now.Minute.ToString() + FileUpload3.FileName);

            string _img4 = "UpLoad/" + DateTime.Now.Minute.ToString() + FileUpload4.FileName;
            FileUpload4.SaveAs(Server.MapPath("./UpLoad/") + DateTime.Now.Minute.ToString() + FileUpload4.FileName);


            bool x = Tourit_Places_Save(0, _City_Id, _Tourism_Type_Id, txt_Name.Text, txt_Opining_Hours.Text, txt_Description.Text, txt_Conditions.Text, txt_Location.Text, txt_Visitor_Counts.Text, txt_Tickits_Prices.Text, _img1, _img2, _img3, _img4);



            if (x == true)
            {

                Tourit_Places_Search(0, 0, 0, "", "", "", "", "", "", "");
                ClearControls();

                lbl_SaveSuccess.Text = " Added successfully";

            }
            else
            {
                lbl_SaveSuccess.Text = " Not added";
            }

        }
        else if (_Id > 0 && FileUpload1.HasFile == true && FileUpload2.HasFile == true && FileUpload3.HasFile == true && FileUpload4.HasFile == true)
        {

            string _img1 = "UpLoad/" + DateTime.Now.Minute.ToString() + FileUpload1.FileName;
            FileUpload1.SaveAs(Server.MapPath("./UpLoad/") + DateTime.Now.Minute.ToString() + FileUpload1.FileName);

            string _img2 = "UpLoad/" + DateTime.Now.Minute.ToString() + FileUpload2.FileName;
            FileUpload2.SaveAs(Server.MapPath("./UpLoad/") + DateTime.Now.Minute.ToString() + FileUpload2.FileName);

            string _img3 = "UpLoad/" + DateTime.Now.Minute.ToString() + FileUpload3.FileName;
            FileUpload3.SaveAs(Server.MapPath("./UpLoad/") + DateTime.Now.Minute.ToString() + FileUpload3.FileName);

            string _img4 = "UpLoad/" + DateTime.Now.Minute.ToString() + FileUpload4.FileName;
            FileUpload4.SaveAs(Server.MapPath("./UpLoad/") + DateTime.Now.Minute.ToString() + FileUpload4.FileName);


            bool x = Tourit_Places_Save(_Id, _City_Id, _Tourism_Type_Id, txt_Name.Text, txt_Opining_Hours.Text, txt_Description.Text, txt_Conditions.Text, txt_Location.Text, txt_Visitor_Counts.Text, txt_Tickits_Prices.Text, _img1, _img2, _img3, _img4);

            if (x == true)
            {

                Tourit_Places_Search(0, 0, 0, "", "", "", "", "", "", "");

                ClearControls();
                lbl_SaveSuccess.Text = " Edited successfully";

            }
            else
            {
                lbl_SaveSuccess.Text = " Has not been Edited  ";
            }
        }
        else if (_Id > 0 && FileUpload1.HasFile == false && FileUpload2.HasFile == false && FileUpload3.HasFile == false && FileUpload4.HasFile == false)
        {

            string _img1 = Image1.ImageUrl.ToString();

            string _img2 = Image2.ImageUrl.ToString();

            string _img3 = Image3.ImageUrl.ToString();

            string _img4 = Image4.ImageUrl.ToString();


            bool x = Tourit_Places_Save(_Id, _City_Id, _Tourism_Type_Id, txt_Name.Text, txt_Opining_Hours.Text, txt_Description.Text, txt_Conditions.Text, txt_Location.Text, txt_Visitor_Counts.Text, txt_Tickits_Prices.Text, _img1, _img2, _img3, _img4);

            if (x == true)
            {

                Tourit_Places_Search(0, 0, 0, "", "", "", "", "", "", "");

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
        Tourit_Places_Search(0, 0, 0, "", "", "", "", "", "", "");
        ClearControls();

    }

    protected void btn_Search_Click(object sender, EventArgs e)
    {
        int _City_Id = 0;
        int.TryParse(Ddl_City_Id.SelectedValue.ToString(), out _City_Id);


        int _Tourism_Type_Id = 0;
        int.TryParse(Ddl_Tourism_Type_Id.SelectedValue.ToString(), out _Tourism_Type_Id);


        Tourit_Places_Search(0, _City_Id, _Tourism_Type_Id, txt_Name.Text, txt_Opining_Hours.Text, txt_Description.Text, txt_Conditions.Text, txt_Location.Text, txt_Visitor_Counts.Text, txt_Tickits_Prices.Text);
    }

    protected void gvTourit_Places_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvTourit_Places.PageIndex = e.NewPageIndex;
            Tourit_Places_Search(0, 0, 0, "", "", "", "", "", "", "");
            ClearControls();
        }
        catch (Exception ex)
        {

        }
    }

    protected void gvTourit_Places_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            if (e.CommandName == "Delte")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                bool del = Tourit_Places_Delete(id);
                if (del == true)
                {
                    Tourit_Places_Search(0, 0, 0, "", "", "", "", "", "", "");
                    ClearControls();
                }
            }
            else if (e.CommandName == "updte")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                Tourit_Places_Search(id, 0, 0, "", "", "", "", "", "", "");



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
        txt_Location.Text = "";
        txt_Name.Text = "";
        txt_Opining_Hours.Text = "";
        txt_Tickits_Prices.Text = "";
        txt_Visitor_Counts.Text = "";

        Image1.Visible = false;
        Image2.Visible = false;
        Image3.Visible = false;
        Image4.Visible = false;

        lbl_SaveSuccess.Text = "";

    }

    private DataTable Tourit_Places_Search(int _Id, int _City_Id, int _Tourism_Type_Id, string _Name, string _Opining_Hours, string _Description, string _Conditions, string _Location, string _Visitor_Counts, string _Tickits_Prices)
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
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = _Id;
            cmd.Parameters.Add("@City_Id", SqlDbType.Int).Value = _City_Id;
            cmd.Parameters.Add("@Tourism_Type_Id", SqlDbType.Int).Value = _Tourism_Type_Id;

            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = _Name;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = _Description;
            cmd.Parameters.Add("@Location", SqlDbType.NVarChar).Value = _Location;

            cmd.Parameters.Add("@Conditions", SqlDbType.NVarChar).Value = _Conditions;
            cmd.Parameters.Add("@Opining_Hours", SqlDbType.NVarChar).Value = _Opining_Hours;
            cmd.Parameters.Add("@Visitor_Counts", SqlDbType.NVarChar).Value = _Visitor_Counts;
            cmd.Parameters.Add("@Tickits_Prices", SqlDbType.NVarChar).Value = _Tickits_Prices;




            da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            if (dt.Rows.Count == 1)
            {

                Image1.Visible = true;
                Image2.Visible = true;
                Image3.Visible = true;
                Image4.Visible = true;

                lbl_Id.Text = dt.Rows[0][0].ToString();
                Ddl_City_Id.SelectedValue = dt.Rows[0][1].ToString();
                Ddl_Tourism_Type_Id.SelectedValue = dt.Rows[0][2].ToString();

                txt_Name.Text = dt.Rows[0][3].ToString();
                txt_Description.Text = dt.Rows[0][4].ToString();
                Image1.ImageUrl = dt.Rows[0][5].ToString();
                Image2.ImageUrl = dt.Rows[0][6].ToString();
                Image3.ImageUrl = dt.Rows[0][7].ToString();
                Image4.ImageUrl = dt.Rows[0][8].ToString();

                txt_Location.Text = dt.Rows[0][9].ToString();
                txt_Conditions.Text = dt.Rows[0][10].ToString();

                txt_Opining_Hours.Text = dt.Rows[0][11].ToString();
                txt_Visitor_Counts.Text = dt.Rows[0][12].ToString();
                txt_Tickits_Prices.Text = dt.Rows[0][13].ToString();


            }
            gvTourit_Places.DataSource = dt;
            gvTourit_Places.DataBind();

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

    public bool Tourit_Places_Save(int _id, int _City_Id, int _Tourism_Type_Id, string _Name, string _Opining_Hours, string _Description, string _Conditions, string _Location, string _Visitor_Counts, string _Tickits_Prices, string _Img1, string _Img2, string _Img3, string _Img4)
    {
        cmd = new SqlCommand();
        try
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Tourit_Places_Save";
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = _id;
            cmd.Parameters.Add("@City_Id", SqlDbType.Int).Value = _City_Id;
            cmd.Parameters.Add("@Tourism_Type_Id", SqlDbType.Int).Value = _Tourism_Type_Id;

            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = _Name;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = _Description;
            cmd.Parameters.Add("@Location", SqlDbType.NVarChar).Value = _Location;

            cmd.Parameters.Add("@Conditions", SqlDbType.NVarChar).Value = _Conditions;
            cmd.Parameters.Add("@Opining_Hours", SqlDbType.NVarChar).Value = _Opining_Hours;
            cmd.Parameters.Add("@Visitor_Counts", SqlDbType.NVarChar).Value = _Visitor_Counts;
            cmd.Parameters.Add("@Tickits_Prices", SqlDbType.NVarChar).Value = _Tickits_Prices;


            cmd.Parameters.Add("@Img1", SqlDbType.NVarChar).Value = _Img1;
            cmd.Parameters.Add("@Img2", SqlDbType.NVarChar).Value = _Img2;
            cmd.Parameters.Add("@Img3", SqlDbType.NVarChar).Value = _Img3;
            cmd.Parameters.Add("@Img4", SqlDbType.NVarChar).Value = _Img4;



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

    private bool Tourit_Places_Delete(int _Id)
    {
        cmd = new SqlCommand();
        try
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Tourit_Places_Delete";
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