using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Tourists_Update_My_Account : System.Web.UI.Page
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

                int _Tourist_Session_Id = 0;
                int.TryParse(Session["Tourist_Session_Id"].ToString(), out _Tourist_Session_Id);

                lbl_Id.Text = _Tourist_Session_Id.ToString();

                dt = Tourists_Search(_Tourist_Session_Id, "", "", "", "", "", "");
               
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


        if (_Id > 0)
        { 
            bool x = Tourists_Save(_Id, txt_Email.Text, txt_Tel.Text, txt_Full_Name.Text, txt_Password.Text, ddl_Gender.SelectedValue.ToString(), txt_BOD.Text, txt_Resedency.Text);

            if (x == true)
            {

                Tourists_Search(0, "", "", "", "", "", "");

              
                lbl_SaveSuccess.Text = " Edited successfully";

            }
            else
            {
                lbl_SaveSuccess.Text = " Has not been Edited  ";
            }
        }

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

  
}