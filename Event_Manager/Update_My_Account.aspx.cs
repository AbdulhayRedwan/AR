using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Event_Manager_Update_My_Account : System.Web.UI.Page
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
                FillData_Admin_Search();


                int _Event_Manager_Session_Id=0;
                int.TryParse(Session["Event_Manager_Session_Id"].ToString(), out _Event_Manager_Session_Id);
                
                 
                dt = Event_Manager_Search(_Event_Manager_Session_Id, "", "", "", "", "", "", 0);
           
            }

        }
        catch (Exception ex)
        {
            Response.Redirect("Default.aspx");
        }
    }




      
    public void FillData_Admin_Search()
    {
        Ddl_Admin_Id.DataSource = Admin_Search();
        Ddl_Admin_Id.DataTextField = "Full_Name";
        Ddl_Admin_Id.DataValueField = "Id";
        Ddl_Admin_Id.DataBind();

    }

    private DataTable Admin_Search()
    {
        cmd = new SqlCommand();
        SqlDataAdapter da = default(SqlDataAdapter);
        dt = new DataTable();
        try
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Admin_Search";

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
         DataTable dt1 = new DataTable();

    

        int _Admin_Id = 0;
        int.TryParse(Ddl_Admin_Id.SelectedValue.ToString(), out _Admin_Id);

        int _Event_Manager_Session_Id = 0;
        int.TryParse(Session["Event_Manager_Session_Id"].ToString(), out _Event_Manager_Session_Id);


        if (_Event_Manager_Session_Id > 0)
        {
            bool x = Event_Manager_Save(_Event_Manager_Session_Id, txt_Email.Text, txt_Tel.Text, txt_Full_Name.Text, txt_Password.Text, ddl_Gender.SelectedValue.ToString(), txt_BOD.Text, txt_Address.Text, _Admin_Id);

            if (x == true)
            {

                Event_Manager_Search(_Event_Manager_Session_Id, "", "", "", "", "", "", 0);

              
                lbl_SaveSuccess.Text = " Edited successfully";

            }
            else
            {
                lbl_SaveSuccess.Text = " Has not been Edited  ";
            }
        }

    }
 
 


    private void ClearControls()
    {
        lbl_Id.Text = "0";
        txt_Address.Text = "";
        txt_Email.Text = "";
        txt_Full_Name.Text = "";
        txt_BOD.Text = "";
        txt_Password.Text = "";
        txt_Tel.Text = "";
        lbl_SaveSuccess.Text = "";

    }

    private DataTable Event_Manager_Search(int _Id, string _Email, string _Tel, string _Full_Name, string _Password, string _Gender, string _Address, int _Admin_Id)
    {
        cmd = new SqlCommand();
        SqlDataAdapter da = default(SqlDataAdapter);
        dt = new DataTable();
        try
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Event_Manager_Search";
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = _Id;
            cmd.Parameters.Add("@Admin_Id", SqlDbType.Int).Value = _Admin_Id;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = _Email;
            cmd.Parameters.Add("@Full_Name", SqlDbType.NVarChar).Value = _Full_Name;
            cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = _Gender;

            cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = _Password;
            cmd.Parameters.Add("@Tel", SqlDbType.NVarChar).Value = _Tel;
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = _Address;



            da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            if (dt.Rows.Count == 1)
            {

                lbl_Id.Text = dt.Rows[0][0].ToString();
                Ddl_Admin_Id.SelectedValue = dt.Rows[0][1].ToString();
                txt_Email.Text = dt.Rows[0][2].ToString();
                txt_Full_Name.Text = dt.Rows[0][3].ToString();
                ddl_Gender.Text = dt.Rows[0][4].ToString();
                txt_Password.Text = dt.Rows[0][5].ToString();
                txt_BOD.Text = dt.Rows[0][6].ToString();
                txt_Tel.Text = dt.Rows[0][7].ToString();
                txt_Address.Text = dt.Rows[0][8].ToString();
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

    public bool Event_Manager_Save(int _id, string _Email, string _Tel, string _Full_Name, string _Password, string _Gender, string _BOD, string _Address, int _Admin_Id)
    {
        cmd = new SqlCommand();
        try
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Event_Manager_Save";
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = _id;
            cmd.Parameters.Add("@Admin_Id", SqlDbType.Int).Value = _Admin_Id;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = _Email;
            cmd.Parameters.Add("@Full_Name", SqlDbType.NVarChar).Value = _Full_Name;
            cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = _Gender;

            cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = _Password;
            cmd.Parameters.Add("@Tel", SqlDbType.NVarChar).Value = _Tel;
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = _Address;

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