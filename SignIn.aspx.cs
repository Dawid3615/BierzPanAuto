using BierzPanAuto.App_Code;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static BierzPanAuto.Global;

namespace BierzPanAuto
{
    public partial class SignIn : BasePage
    {
        public static String connection_string = ConfigurationManager.ConnectionStrings["BierzPanAutoDatabaseConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["USERNAME"] != null /*&& Request.Cookies["EMAIL"] != null*/ && Request.Cookies["PASSWORD"] != null)
                {
                    txtbUsernameEmail.Text = Request.Cookies["USERNAME"].Value;
                    //txtbUsernameEmail.Text = Request.Cookies["EMAIL"].Value;
                    txtbPassword.Attributes["value"] = Request.Cookies["PASSWORD"].Value;
                    chkbRememberMe.Checked = true;
                }
            }
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                SqlCommand command_GetUser = new SqlCommand("SELECT * FROM table_Users WHERE Username='" + txtbUsernameEmail.Text + "'OR Email='" + txtbUsernameEmail.Text + "' AND Password='" + txtbPassword.Text + "'", connect_database);
                connect_database.Open();
                SqlDataAdapter sda_GetUser = new SqlDataAdapter(command_GetUser);
                DataTable dt_GetUser = new DataTable();
                sda_GetUser.Fill(dt_GetUser);

                if (dt_GetUser.Rows.Count != 0)
                {
                    Session["USERID"] = dt_GetUser.Rows[0]["UserID"].ToString();
                    Session["USEREMAIL"] = dt_GetUser.Rows[0]["Email"].ToString();

                    if (chkbRememberMe.Checked)
                    {
                        Response.Cookies["USERNAME"].Value = txtbUsernameEmail.Text;
                        //Response.Cookies["EMAIL"].Value = txtbUsernameEmail.Text;
                        Response.Cookies["PASSWORD"].Value = txtbPassword.Text;

                        Response.Cookies["USERNAME"].Expires = DateTime.Now.AddDays(15);
                        //Response.Cookies["EMAIL"].Expires = DateTime.Now.AddDays(15);
                        Response.Cookies["PASSWORD"].Expires = DateTime.Now.AddDays(15);

                    }
                    else
                    {
                        Response.Cookies["USERNAME"].Expires = DateTime.Now.AddDays(-1);
                        //Response.Cookies["EMAIL"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["PASSWORD"].Expires = DateTime.Now.AddDays(-1);
                    }
                    string UserType;
                    UserType = dt_GetUser.Rows[0][6].ToString().Trim();

                    if (UserType == "user")
                    {
                        Session["USRPWD"] = txtbUsernameEmail.Text;
                        if (Request.QueryString["rurl"] != null)
                        {
                            if (Request.QueryString["rurl"] == "take")
                            {
                                Response.Redirect("~/Take.aspx");
                            }
                        }
                        else
                        {
                            Response.Redirect("~/UserHome.aspx");
                        }
                    }
                    if (UserType == "admin")
                    {
                        Session["USRPWD"] = txtbUsernameEmail.Text;
                        Response.Redirect("~/AdminHome.aspx");
                    }
                }
                else
                {
                    PageUtility.MessageBox(this, "Nieprawidłowa nazwa użytkownika lub hasło !");
                }
            }
        }
    }
}