using BierzPanAuto.App_Code;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using static BierzPanAuto.Global;

namespace BierzPanAuto
{
    public partial class RecoverPassword : BasePage
    {
        public static String connection_string = ConfigurationManager.ConnectionStrings["BierzPanAutoDatabaseConnectionString"].ConnectionString;
        String GUIDValue;
        DataTable dt_FindRequest = new DataTable();
        int UserID;


        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                GUIDValue = Request.QueryString["UserID"];
                if (GUIDValue != null)
                {
                    SqlCommand command_FindRequests = new SqlCommand("SELECT * FROM table_ForgotPasswordRequests WHERE RecoverID='" + GUIDValue + "'", connect_database);
                    connect_database.Open();
                    SqlDataAdapter sda_FindRequest = new SqlDataAdapter(command_FindRequests);
                    sda_FindRequest.Fill(dt_FindRequest);
                    if (dt_FindRequest.Rows.Count != 0)
                    {
                        UserID = Convert.ToInt32(dt_FindRequest.Rows[0][1]);
                    }
                    else
                    {
                        PageUtility.MessageBox(this, "Twój link do resetowania hasła stracił ważność lub jest nieprawidłowy !");
                    }
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }

            if (!IsPostBack)
            {
                if (dt_FindRequest.Rows.Count != 0)
                {
                    txtbPassword.Visible = true;
                    txtbRetypePassword.Visible = true;
                    lblPassword.Visible = true;
                    lblRetypePassword.Visible = true;
                    btnPasswordReset.Visible = true;
                }
                else
                {
                    PageUtility.MessageBox(this, "Twój link do resetowania hasła stracił ważność lub jest nieprawidłowy !");
                }
            }
        }

        protected void btnPasswordReset_Click(object sender, EventArgs e)
        {
            if (txtbPassword.Text != "" && txtbRetypePassword.Text != "" && txtbPassword.Text == txtbRetypePassword.Text)
            {
                using (SqlConnection connect_database = new SqlConnection(connection_string))
                {
                    SqlCommand command_UpdatePassword = new SqlCommand("UPDATE table_Users SET Password='" + txtbPassword.Text + "' WHERE UserID='" + UserID + "'", connect_database);
                    connect_database.Open();
                    command_UpdatePassword.ExecuteNonQuery();
                    SqlCommand command_DeleteRequest = new SqlCommand("DELETE FROM table_ForgotPasswordRequests WHERE UserID='" + UserID + "'", connect_database);
                    command_DeleteRequest.ExecuteNonQuery();
                    Response.Redirect("~/SignIn.aspx");
                }
            }
        }
    }
}