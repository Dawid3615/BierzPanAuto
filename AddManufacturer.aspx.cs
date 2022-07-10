using BierzPanAuto.App_Code;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BierzPanAuto
{
    public partial class AddManufacturer : BasePage
    {
        public static String connection_string = ConfigurationManager.ConnectionStrings["BierzPanAutoDatabaseConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindManufacturerRepeater();
            }
        }

        private void BindManufacturerRepeater()
        {
            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                using (SqlCommand command_GetAllManufacturers = new SqlCommand("procGetAllManufacturers", connect_database))
                {
                    command_GetAllManufacturers.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda_GetAllManufacturers = new SqlDataAdapter(command_GetAllManufacturers))
                    {
                        DataTable dt_GetAllManufacturers = new DataTable();
                        sda_GetAllManufacturers.Fill(dt_GetAllManufacturers);
                        RepeaterManufacturers.DataSource = dt_GetAllManufacturers;
                        RepeaterManufacturers.DataBind();
                    }
                }
            }
        }

        protected void btnAddManufacturer_Click(object sender, EventArgs e)
        {
            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                SqlCommand command_AddManufacturer = new SqlCommand("INSERT INTO table_cManufacturers VALUES('" + txtbManufacturer.Text + "')", connect_database);
                connect_database.Open();
                command_AddManufacturer.ExecuteNonQuery();
                txtbManufacturer.Text = string.Empty;
            }
            BindManufacturerRepeater();
        }
    }
}