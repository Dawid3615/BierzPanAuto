using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace BierzPanAuto
{
    public partial class GeneralLayoutMaster : System.Web.UI.MasterPage
    {

        public static String connection_string = ConfigurationManager.ConnectionStrings["BierzPanAutoDatabaseConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            BindTakeNumber();
            BindClasses();
            if (Session["USRPWD"] != null)
            {
                btnSignUp.Visible = false;
                btnSignIn.Visible = false;
                btnSignOut.Visible = true;
            }
            else
            {
                btnSignUp.Visible = true;
                btnSignIn.Visible = true;
                btnSignOut.Visible = false;
            }
        }

        public void BindTakeNumber()
        {
            if (Request.Cookies["TakeCarID"] != null)
            {
                string CookieCarID = Request.Cookies["TakeCarID"].Value.Split('=')[1];
                string[] CarArray = CookieCarID.Split(',');
                int CarCount = CarArray.Length;
                cCount.InnerText = CarCount.ToString();
            }
            else
            {
                cCount.InnerText = 0.ToString();
            }
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Session["USRPWD"] = null;
            Response.Redirect("~/Default.aspx");
        }

        public void BindClasses()
        {
            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                using (SqlCommand command_GetAllClasses = new SqlCommand("SELECT * FROM table_cClass", connect_database))
                {
                    command_GetAllClasses.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda_GetAllClasses = new SqlDataAdapter(command_GetAllClasses))
                    {
                        DataTable dt_GetAllClasses = new DataTable();
                        sda_GetAllClasses.Fill(dt_GetAllClasses);
                        RepeaterMenu.DataSource = dt_GetAllClasses;
                        RepeaterMenu.DataBind();
                    }
                }
            }
        }

        protected void RepeaterMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string classID = (e.Item.FindControl("hfClassID") as HiddenField).Value;
                Repeater RepeaterTiers = e.Item.FindControl("RepeaterTier") as Repeater;

                using (SqlConnection connect_database = new SqlConnection(connection_string))
                {
                    using (SqlCommand command_GetAllClasses = new SqlCommand(string.Format("SELECT * FROM table_cTier WHERE ClassID='{0}'", classID), connect_database))
                    {
                        command_GetAllClasses.CommandType = CommandType.Text;
                        using (SqlDataAdapter sda_GetAllClasses = new SqlDataAdapter(command_GetAllClasses))
                        {
                            DataTable dt_GetAllClasses = new DataTable();
                            sda_GetAllClasses.Fill(dt_GetAllClasses);
                            RepeaterTiers.DataSource = dt_GetAllClasses;
                            RepeaterTiers.DataBind();
                        }
                    }
                }
            }
        }
    }
}