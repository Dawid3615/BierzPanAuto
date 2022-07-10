using BierzPanAuto.App_Code;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace BierzPanAuto
{
    public partial class AddColor : BasePage
    {
        public static String connection_string = ConfigurationManager.ConnectionStrings["BierzPanAutoDatabaseConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindManufacturers();
                BindColors();
                BindPaintTypes();
                BindRepeaterColors();
                ddlCarModel.Enabled = false;
                ddlCarGeneration.Enabled = false;
            }
        }

        private void BindRepeaterColors()
        {
            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                using (SqlCommand command_GetAllColors = new SqlCommand("procGetAllColors", connect_database))
                {
                    command_GetAllColors.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda_GetAllColors = new SqlDataAdapter(command_GetAllColors))
                    {
                        DataTable dt_GetAllColors = new DataTable();
                        sda_GetAllColors.Fill(dt_GetAllColors);
                        RepeaterColors.DataSource = dt_GetAllColors;
                        RepeaterColors.DataBind();
                    }
                }
            }
        }

        private void BindPaintTypes()
        {
            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                SqlCommand command_PaintTypes = new SqlCommand("SELECT * FROM table_cPaintType", connect_database);
                connect_database.Open();
                SqlDataAdapter sda_PaintTypes = new SqlDataAdapter(command_PaintTypes);
                DataTable dt_PaintTypes = new DataTable();
                sda_PaintTypes.Fill(dt_PaintTypes);

                if (dt_PaintTypes.Rows.Count != 0)
                {
                    ddlPaintType.DataSource = dt_PaintTypes;
                    ddlPaintType.DataTextField = "PaintTypeName";
                    ddlPaintType.DataValueField = "PaintTypeID";
                    ddlPaintType.DataBind();
                    ddlPaintType.Items.Insert(0, new ListItem("-- Wybierz typ lakieru --", "0"));
                }
            }
        }

        private void BindColors()
        {
            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                SqlCommand command_BaseColors = new SqlCommand("SELECT * FROM table_cBasePaint", connect_database);
                connect_database.Open();
                SqlDataAdapter sda_BaseColors = new SqlDataAdapter(command_BaseColors);
                DataTable dt_BaseColors = new DataTable();
                sda_BaseColors.Fill(dt_BaseColors);

                if (dt_BaseColors.Rows.Count != 0)
                {
                    ddlBasePaint.DataSource = dt_BaseColors;
                    ddlBasePaint.DataTextField = "BasePaintName";
                    ddlBasePaint.DataValueField = "BasePaintID";
                    ddlBasePaint.DataBind();
                    ddlBasePaint.Items.Insert(0, new ListItem("-- Wybierz kolor --", "0"));
                }
            }
        }

        private void BindManufacturers()
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
                    ddlCarManufacturer.DataSource = dt_GetManufacturers;
                    ddlCarManufacturer.DataTextField = "ManufacturerName";
                    ddlCarManufacturer.DataValueField = "ManufacturerID";
                    ddlCarManufacturer.DataBind();
                    ddlCarManufacturer.Items.Insert(0, new ListItem("-- Wybierz markę --", "0"));
                }
            }
        }

        protected void btnAddColor_Click(object sender, EventArgs e)
        {
            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                SqlCommand command_AddColor = new SqlCommand("INSERT INTO table_cColors VALUES('" + txtbName.Text + "','" + txtbPaintPrewiev.Text + "','" + ddlBasePaint.SelectedItem.Value + "','" + ddlPaintType.SelectedItem.Value + "','" + ddlCarManufacturer.SelectedItem.Value + "','" + ddlCarModel.SelectedItem.Value + "','" + ddlCarGeneration.SelectedItem.Value + "')", connect_database);
                connect_database.Open();
                command_AddColor.ExecuteNonQuery();
                txtbName.Text = string.Empty;
                txtbPaintPrewiev.Text = string.Empty;
                ddlBasePaint.ClearSelection();
                ddlBasePaint.Items.FindByValue("0").Selected = true;
                ddlCarManufacturer.ClearSelection();
                ddlCarManufacturer.Items.FindByValue("0").Selected = true;
                ddlCarModel.ClearSelection();
                ddlCarModel.Items.FindByValue("0").Selected = true;
                ddlCarGeneration.ClearSelection();
                ddlCarGeneration.Items.FindByValue("0").Selected = true;
                ddlPaintType.ClearSelection();
                ddlPaintType.Items.FindByValue("0").Selected = true;
            }
            BindRepeaterColors();
        }

        protected void ddlCarManufacturer_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ManufacturerID = Convert.ToInt32(ddlCarManufacturer.SelectedItem.Value);
            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                SqlCommand command_GetModels = new SqlCommand("SELECT * FROM table_cModels WHERE ManufacturerID='" + ddlCarManufacturer.SelectedItem.Value + "'", connect_database);
                connect_database.Open();
                SqlDataAdapter sda_GetModels = new SqlDataAdapter(command_GetModels);
                DataTable dt_GetModels = new DataTable();
                sda_GetModels.Fill(dt_GetModels);

                if (dt_GetModels.Rows.Count != 0)
                {
                    ddlCarModel.DataSource = dt_GetModels;
                    ddlCarModel.DataTextField = "ModelName";
                    ddlCarModel.DataValueField = "ModelID";
                    ddlCarModel.DataBind();
                    ddlCarModel.Items.Insert(0, new ListItem("-- Wybierz model --", "0"));
                    ddlCarModel.Enabled = true;
                }
            }
        }

        protected void ddlCarModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ModelID = Convert.ToInt32(ddlCarModel.SelectedItem.Value);
            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                SqlCommand command_GetGenerations = new SqlCommand("SELECT * FROM table_cGenerations WHERE ModelID='" + ddlCarModel.SelectedItem.Value + "'", connect_database);
                connect_database.Open();
                SqlDataAdapter sda_GetGenerations = new SqlDataAdapter(command_GetGenerations);
                DataTable dt_GetGenerations = new DataTable();
                sda_GetGenerations.Fill(dt_GetGenerations);

                if (dt_GetGenerations.Rows.Count != 0)
                {
                    ddlCarGeneration.DataSource = dt_GetGenerations;
                    ddlCarGeneration.DataTextField = "GenerationName";
                    ddlCarGeneration.DataValueField = "GenerationID";
                    ddlCarGeneration.DataBind();
                    ddlCarGeneration.Items.Insert(0, new ListItem("-- Wybierz generację --", "0"));
                    ddlCarGeneration.Enabled = true;
                }
            }
        }
    }
}