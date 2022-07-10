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

namespace BierzPanAuto
{
    public partial class AddClass : BasePage
    {
        public static String connection_string = ConfigurationManager.ConnectionStrings["BierzPanAutoDatabaseConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAllClasses();
            }
        }

        private void BindAllClasses()
        {
            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                using (SqlCommand command_GetAllClasses = new SqlCommand("procGetAllClasses", connect_database))
                {
                    command_GetAllClasses.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda_GetAllClasses = new SqlDataAdapter(command_GetAllClasses))
                    {
                        DataTable dt_GetAllClasses = new DataTable();
                        sda_GetAllClasses.Fill(dt_GetAllClasses);
                        RepeaterClasses.DataSource = dt_GetAllClasses;
                        RepeaterClasses.DataBind();
                    }
                }
            }
        }

        protected void btnAddClass_Click(object sender, EventArgs e)
        {
            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                SqlCommand command_AddClass = new SqlCommand("INSERT INTO table_cClass VALUES('" + txtbClass.Text + "')", connect_database);
                connect_database.Open();
                command_AddClass.ExecuteNonQuery();
                txtbClass.Text = string.Empty;
            }
            BindAllClasses();
        }
    }
}