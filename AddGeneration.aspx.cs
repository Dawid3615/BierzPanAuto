using BierzPanAuto.App_Code;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace BierzPanAuto
{
    public partial class AddGeneration : BasePage
    {
        public static String connection_string = ConfigurationManager.ConnectionStrings["BierzPanAutoDatabaseConnectionString"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindManufacturer();
                BindSubModelRepeater();
                ddlModel.Enabled = false;
            }
        }

        private void BindSubModelRepeater()
        {
            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                using (SqlCommand command_GetAllGenerations = new SqlCommand("procGetAllGenerations", connect_database))
                {
                    command_GetAllGenerations.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda_GetAllGenerations = new SqlDataAdapter(command_GetAllGenerations))
                    {
                        DataTable dt_GetAllGenerations = new DataTable();
                        sda_GetAllGenerations.Fill(dt_GetAllGenerations);
                        RepeaterGenerations.DataSource = dt_GetAllGenerations;
                        RepeaterGenerations.DataBind();
                    }
                }
            }
        }

        private void BindManufacturer()
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

        protected void btnAddGeneration_Click(object sender, EventArgs e)
        {
            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                SqlCommand command_AddGeneration = new SqlCommand("INSERT INTO table_cGenerations VALUES('" + txtbGenerationName.Text + "','" + ddlModel.SelectedItem.Value + "','" + ddlManufacturer.SelectedItem.Value + "')", connect_database);
                connect_database.Open();
                command_AddGeneration.ExecuteNonQuery();
                txtbGenerationName.Text = string.Empty;
                ddlManufacturer.ClearSelection();
                ddlManufacturer.Items.FindByValue("0").Selected = true;
                ddlModel.ClearSelection();
                ddlModel.Items.FindByValue("0").Selected = true;
            }
            BindSubModelRepeater();
        }

        protected void ddlManufacturer_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ManufacturerID = Convert.ToInt32(ddlManufacturer.SelectedItem.Value);
            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                SqlCommand command_GetModels = new SqlCommand("SELECT * FROM table_cModels WHERE ManufacturerID='" + ddlManufacturer.SelectedItem.Value + "'", connect_database);
                connect_database.Open();
                SqlDataAdapter sda_GetModels = new SqlDataAdapter(command_GetModels);
                DataTable dt_GetModels = new DataTable();
                sda_GetModels.Fill(dt_GetModels);

                if (dt_GetModels.Rows.Count != 0)
                {
                    ddlModel.DataSource = dt_GetModels;
                    ddlModel.DataTextField = "ModelName";
                    ddlModel.DataValueField = "ModelID";
                    ddlModel.DataBind();
                    ddlModel.Items.Insert(0, new ListItem("-- Wybierz model --", "0"));
                    ddlModel.Enabled = true;
                }
            }
        }
    }
}