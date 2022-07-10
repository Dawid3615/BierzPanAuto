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
    public partial class AddGarage : BasePage
    {
        public static String connection_string = ConfigurationManager.ConnectionStrings["BierzPanAutoDatabaseConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGarageRepeater();
            }
        }

        private void BindGarageRepeater()
        {
            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                using (SqlCommand command_GetAllGarages = new SqlCommand("procGetAllGarages", connect_database))
                {
                    command_GetAllGarages.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda_GetAllGarages = new SqlDataAdapter(command_GetAllGarages))
                    {
                        DataTable dt_GetAllGarages = new DataTable();
                        sda_GetAllGarages.Fill(dt_GetAllGarages);
                        RepeaterGarages.DataSource = dt_GetAllGarages;
                        RepeaterGarages.DataBind();
                    }
                }
            }
        }

        protected void btnAddGarage_Click(object sender, EventArgs e)
        {
            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                SqlCommand command_AddGarage = new SqlCommand("INSERT INTO table_cGarage VALUES('" + txtbGarage.Text + "')", connect_database);
                connect_database.Open();
                command_AddGarage.ExecuteNonQuery();
                txtbGarage.Text = string.Empty;
            }
            BindGarageRepeater();
        }

        protected void btnDelGarage_Click(object sender, EventArgs e)
        {
            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                int _garageID = 0;
                SqlCommand command_DeleteGarage = new SqlCommand("DELETE FROM table_cGarage WHERE GarageID='" + _garageID + "'", connect_database);
                connect_database.Open();
                command_DeleteGarage.ExecuteNonQuery();
            }
        }
    }
}