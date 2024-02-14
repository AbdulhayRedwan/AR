using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Manage_Tourists : System.Web.UI.Page
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

                dt = Tourists_Search(0, "", "", "", "", "", "");
                ClearControls();
            }

        }
        catch (Exception ex)
        {
            Response.Redirect("Default.aspx");
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        //عملية الاظافة
        DataTable dt1 = new DataTable();

        int _Id = 0;
        int.TryParse(lbl_Id.Text, out _Id);


        if (_Id == 0)
        {
            dt1 = Tourists_Search(0, txt_Email.Text, "", "", "", "", ""); //  يتم البحث عن الايميل الي تم ادخالة للاضافه - اذا مان موجود مسبقا في القاعدة يتم رفضه


            if (dt1.Rows.Count > 0)
            {
                lbl_SaveSuccess.Text = " This account has already been registered";
            }
            else
            {
                bool x = Tourists_Save(0, txt_Email.Text, txt_Tel.Text, txt_Full_Name.Text, txt_Password.Text, ddl_Gender.SelectedValue.ToString(), txt_BOD.Text, txt_Resedency.Text);

                if (x == true)
                {

                    Tourists_Search(0, "", "", "", "", "", "");
                    ClearControls();

                    lbl_SaveSuccess.Text = " Added successfully";

                }
                else
                {
                    lbl_SaveSuccess.Text = " Not added";
                }
            }
        }
        else
        {
            bool x = Tourists_Save(_Id, txt_Email.Text, txt_Tel.Text, txt_Full_Name.Text, txt_Password.Text, ddl_Gender.SelectedValue.ToString(), txt_BOD.Text, txt_Resedency.Text);

            if (x == true)
            {

                Tourists_Search(0, "", "", "", "", "", "");

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
        Tourists_Search(0, "", "", "", "", "", "");
        ClearControls();

    }

    protected void btn_Search_Click(object sender, EventArgs e)
    {


        Tourists_Search(0, txt_Email.Text, txt_Tel.Text, txt_Full_Name.Text, txt_Password.Text, ddl_Gender.SelectedValue.ToString(), txt_Resedency.Text);
    }

    protected void gvTourists_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvTourists.PageIndex = e.NewPageIndex;
            Tourists_Search(0, "", "", "", "", "", "");
            ClearControls();
        }
        catch (Exception ex)
        {

        }
    }

    protected void gvTourists_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            if (e.CommandName == "Delte")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                bool del = Tourists_Delete(id);
                if (del == true)
                {
                    Tourists_Search(0, "", "", "", "", "", "");
                    ClearControls();
                }
            }
            else if (e.CommandName == "updte")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                Tourists_Search(id, "", "", "", "", "", "");



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
        txt_Resedency.Text = "";
        txt_Email.Text = "";
        txt_Full_Name.Text = "";
        txt_BOD.Text = "";
        txt_Password.Text = "";
        txt_Tel.Text = "";
        lbl_SaveSuccess.Text = "";

    }

    private DataTable Tourists_Search(int _Id, string _Email, string _Tel, string _Full_Name, string _Password, string _Gender, string _Resedency)
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
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = _Id;

            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = _Email;
            cmd.Parameters.Add("@Full_Name", SqlDbType.NVarChar).Value = _Full_Name;
            cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = _Gender;

            cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = _Password;
            cmd.Parameters.Add("@Tel", SqlDbType.NVarChar).Value = _Tel;
            cmd.Parameters.Add("@Resedency", SqlDbType.NVarChar).Value = _Resedency;



            da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            if (dt.Rows.Count == 1)
            {

                lbl_Id.Text = dt.Rows[0][0].ToString();

                txt_Email.Text = dt.Rows[0][1].ToString();
                txt_Full_Name.Text = dt.Rows[0][2].ToString();
                ddl_Gender.Text = dt.Rows[0][3].ToString();
                txt_Password.Text = dt.Rows[0][4].ToString();
                txt_BOD.Text = dt.Rows[0][5].ToString();
                txt_Tel.Text = dt.Rows[0][6].ToString();
                txt_Resedency.Text = dt.Rows[0][7].ToString();
            }
            gvTourists.DataSource = dt;
            gvTourists.DataBind();

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

    public bool Tourists_Save(int _id, string _Email, string _Tel, string _Full_Name, string _Password, string _Gender, string _BOD, string _Resedency)
    {
        cmd = new SqlCommand();
        try
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Tourists_Save";
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = _id;

            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = _Email;
            cmd.Parameters.Add("@Full_Name", SqlDbType.NVarChar).Value = _Full_Name;
            cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = _Gender;

            cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = _Password;
            cmd.Parameters.Add("@Tel", SqlDbType.NVarChar).Value = _Tel;
            cmd.Parameters.Add("@Resedency", SqlDbType.NVarChar).Value = _Resedency;

            cmd.Parameters.Add("@BOD", SqlDbType.NVarChar).Value = _BOD;


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

    private bool Tourists_Delete(int _Id)
    {
        cmd = new SqlCommand();
        try
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Tourists_Delete";
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