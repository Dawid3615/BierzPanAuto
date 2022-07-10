using BierzPanAuto.App_Code;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace BierzPanAuto
{
    public partial class AddModel : BasePage
    {
        public static String connection_string = ConfigurationManager.ConnectionStrings["BierzPanAutoDatabaseConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMainManufacturer();
                BindModelRepeaater();
            }
        }

        private void BindModelRepeaater()
        {
            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                using (SqlCommand command_GetAllModels = new SqlCommand("procGetAllModels", connect_database))
                {
                    command_GetAllModels.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda_GetAllModels = new SqlDataAdapter(command_GetAllModels))
                    {
                        DataTable dt_GetAllModels = new DataTable();
                        sda_GetAllModels.Fill(dt_GetAllModels);
                        RepeaterModels.DataSource = dt_GetAllModels;
                        RepeaterModels.DataBind();
                    }
                }
            }
        }

        private void BindMainManufacturer()
        {
            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                SqlCommand command_GetManufacturers = new SqlCommand("SELECT * FROM table_cManufacturers", connect_database);
                connect_database.Open();
                SqlDataAdapter sda_GetManufacturers = new SqlDataAdapter(command_GetManufacturers);
                DataTable dt_GetManufacturers = new DataTable();
                sda_GetManufacturers.Fill(dt_GetManufacturers);

                if (dt_GetManufacturers.Rows.Count != 0)
                {
                    ddlManufacturer.DataSource = dt_GetManufacturers;
                    ddlManufacturer.DataTextField = "ManufacturerName";
                    ddlManufacturer.DataValueField = "ManufacturerID";
                    ddlManufacturer.DataBind();
                    ddlManufacturer.Items.Insert(0, new ListItem("-- Wybierz markę --", "0"));
                }
            }
        }

        protected void btnAddModel_Click(object sender, EventArgs e)
        {
            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                SqlCommand command_AddModel = new SqlCommand("INSERT INTO table_cModels VALUES('" + txtbModelName.Text + "','" + ddlManufacturer.SelectedItem.Value + "')", connect_database);
                connect_database.Open();
                command_AddModel.ExecuteNonQuery();
                txtbModelName.Text = string.Empty;
                ddlManufacturer.ClearSelection();
                ddlManufacturer.Items.FindByValue("0").Selected = true;
            }
            BindModelRepeaater();
        }
    }
}