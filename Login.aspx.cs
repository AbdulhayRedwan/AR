using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(); //  شبك المشروع بقاعدة البانات
    SqlCommand cmd = new SqlCommand(); //  شبك المشروع بقاعدة البانات
    DataTable dt = new DataTable(); //  شبك المشروع بقاعدة البانات

    protected void Page_Load(object sender, EventArgs e)
    {
        try // منطقه يكتب بداخلها الكود ولمعرفة اذا كان اخطاء بداخلة ومعرفة نوع الخطا 
        {
            // App_conniction متغير للتاكد من انه تم الشبك على قاعدة البيانات ولا يوجد مشاكل 
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["App_conniction"].ConnectionString);//  شبك المشروع بقاعدة البانات

            if (!IsPostBack)
            {
                int _admin_ID = 0;
                int.TryParse(Session["Admin_Session_Id"].ToString(), out _admin_ID);

                if (_admin_ID != 0)
                {
                    Response.Redirect("Admin_Main_Page.aspx");// الذهاب الى اسم الششاشه 


                }


            }

        }
        catch (Exception ex)//   ومعرفة نوع الخطا 
        {

        }

    }


    // العملية الخاصة بتسجيل الدخول 
    public bool Admin_Search_login_Bool(int _Id, string _Email, string _Password)   // ادخل المتغيرات على اسم العملية 
    {
        cmd = new SqlCommand(); //  للوصول الى ستورد برسيجر
        SqlDataAdapter da = default(SqlDataAdapter);//  للوصول الى ستورد برسيجر
        DataTable dt = new DataTable();//  تخزين البيانات الراجعة من الققاعدة
        try
        {
            con.Open();//  فتح القاعدة
            cmd.Connection = con; //  فتح القاعدة
            cmd.CommandType = CommandType.StoredProcedure; //  StoredProcedure نوع العملية 
            cmd.CommandText = "Login";//  للوصول الى ستورد برسيجر
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = _Id;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = _Email; //  ارسل قيمة الايميل للسترود برسيجر
            cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = _Password; //  ارسل قيمة الباسورد للسترود برسيجر
            da = new SqlDataAdapter(cmd);  // bool قيمة الراجعة من الستورد برسيجر نعم او لا 
            da.Fill(dt);//  قيمة الراجعة من الستورد برسيجر


        }
        catch (Exception ex)
        {
            return false;
        }
        finally
        {
            con.Close(); //  اغلاق القاعدة
        }
        return true;
    }


    // العملية الخاصة بتسجيل الدخول 
    public DataTable Admin_Search_login_DT(int _Id, string _Email, string _Password)
    {
        cmd = new SqlCommand();
        SqlDataAdapter da = default(SqlDataAdapter);
        dt = new DataTable();
        try
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Login";

            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = _Id;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = _Email; //  ارسل قيمة الايميل للسترود برسيجر
            cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = _Password; //  ارسل قيمة الباسورد للسترود برسيجر


            da = new SqlDataAdapter(cmd);
            da.Fill(dt); // DataTable بترجع بيانات الصف
        }
        catch (Exception ex)
        {
            return dt;
        }
        finally
        {
            con.Close();
        }
        return dt;
    }





    public void login()
    {

        DataTable dt = new DataTable();


        int _Id = 0;
        int.TryParse(RadioButtonList1.SelectedValue.ToString(), out _Id);



        if (Admin_Search_login_Bool(_Id, txt_Email.Text, txt_Password.Text) == true) // جملة شرط اذا كانت نتيجة الدخول نعم يتم الذهاب الى الصفحة المذكور اسمها بالداخل
            dt = Admin_Search_login_DT(_Id, txt_Email.Text, txt_Password.Text); // خزن في متغير اسمه دي تي بيانات الصف


        if (_Id == 1 && dt.Rows.Count > 0)
        {

            Session["Admin_Session_Id"] = dt.Rows[0][0].ToString();// متغير لرقم المستخدم 
            Session["Admin_Full_Name"] = dt.Rows[0][2].ToString();// متغير لاسم المستخدم 

            Response.Redirect("Admin/Admin_Default.aspx");// الذهاب الى اسم الششاشه 

        }
        else if (_Id == 2 && dt.Rows.Count > 0)
        {
            Session["Event_Manager_Session_Id"] = dt.Rows[0][0].ToString();// متغير لرقم المستخدم 
            Session["Event_Manager_Full_Name"] = dt.Rows[0][3].ToString();// متغير لاسم المستخدم 

            Response.Redirect("Event_Manager/Event_Manager_Default.aspx");// الذهاب الى اسم الششاشه 

        }
        else if (_Id == 3 && dt.Rows.Count > 0)
        {
            Session["Guider_Session_Id"] = dt.Rows[0][0].ToString();// متغير لرقم المستخدم 
            Session["Guider_Full_Name"] = dt.Rows[0][2].ToString();// متغير لاسم المستخدم 

            Response.Redirect("Guider/MasterGuider_Default.aspx");// الذهاب الى اسم الششاشه 

        }
        else if (_Id == 4 && dt.Rows.Count > 0)
        {
            Session["Tourist_Session_Id"] = dt.Rows[0][0].ToString();// متغير لرقم المستخدم 
            Session["Tourist_Full_Name"] = dt.Rows[0][2].ToString();// متغير لاسم المستخدم 

         //   Response.Redirect("Tourists/Tour_Services.aspx");// الذهاب الى اسم الششاشه 
            Response.Redirect("Visitors/Trips.aspx");// الذهاب الى اسم الششاشه 
        } 
        else
        {
            lbl_msg.Text = "Failed to login";

        }

    }

    protected void btn_Login_Click(object sender, EventArgs e)
    {
        login(); // زر تسجيل الدخول الذي استدعى المثود
    }


}