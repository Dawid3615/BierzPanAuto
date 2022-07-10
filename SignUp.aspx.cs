using BierzPanAuto.App_Code;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static BierzPanAuto.Global;

namespace BierzPanAuto
{
    public partial class SignUp : BasePage
    {
        public static String connection_string = ConfigurationManager.ConnectionStrings["BierzPanAutoDatabaseConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            if (txtbUsername.Text != "" && txtbPassword.Text != "" && txtbPasswordConfirm.Text != "" && txtbFirstName.Text != "" && txtbLastName.Text != "" && txtbEmail.Text != "")
            {
                if (txtbPassword.Text == txtbPasswordConfirm.Text)
                {
                    using (SqlConnection connect_database = new SqlConnection(connection_string))
                    {
                        SqlCommand command_AddUser = new SqlCommand("INSERT INTO table_Users VALUES('" + txtbUsername.Text + "','" + txtbPassword.Text + "','" + txtbEmail.Text + "','" + txtbFirstName.Text + "','" + txtbLastName.Text + "','user')", connect_database);
                        connect_database.Open();
                        command_AddUser.ExecuteNonQuery();
                        PageUtility.MessageBox(this, "Rejestracja przebiegła pomyślnie !");
                        Response.Redirect("~/SignIn.aspx");
                    }
                }
                else
                {
                    //lblMessages.ForeColor = Color.Red;
                    //lblMessages.Text = "Hasła nie pasują do siebie";
                    PageUtility.MessageBox(this, "Hasła nie pasują do siebie !");
                }
            }
            else
            {
                //lblMessages.ForeColor = Color.Red;
                //lblMessages.Text = "Wszystkie pola są obowiązkowe !";
                PageUtility.MessageBox(this, "Wszystkie pola są obowiązkowe !");
            }
        }
    }
}