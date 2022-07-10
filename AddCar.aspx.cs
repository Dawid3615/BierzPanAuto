using BierzPanAuto.App_Code;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;

namespace BierzPanAuto
{
    public partial class AddCar : BasePage
    {
        public static String connection_string = ConfigurationManager.ConnectionStrings["BierzPanAutoDatabaseConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCarModel.Enabled = false;
                ddlCarGeneration.Enabled = false;
                ddlPaint.Enabled = false;
                ddlCarClass.Enabled = false;
                BindManufacturers();
                BindEngine();
                BindGearbox();
                BindDrive();
                BindDetails();
                BindClass();
                BindEnginePosition();
                BindGarage();
            }
        }

        private void BindGarage()
        {
            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                SqlCommand command_GetGarage = new SqlCommand("SELECT * FROM table_cGarage", connect_database);
                connect_database.Open();
                SqlDataAdapter sda_GetGarage = new SqlDataAdapter(command_GetGarage);
                DataTable dt_GetGarage = new DataTable();
                sda_GetGarage.Fill(dt_GetGarage);

                if (dt_GetGarage.Rows.Count != 0)
                {
                    ddlGarage.DataSource = dt_GetGarage;
                    ddlGarage.DataTextField = "GarageName";
                    ddlGarage.DataValueField = "GarageID";
                    ddlGarage.DataBind();
                    ddlGarage.Items.Insert(0, new ListItem("-- Wybierz typ garażowania --", "0"));
                }
            }
        }

        private void BindEnginePosition()
        {
            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                SqlCommand command_GetEnginePosition = new SqlCommand("SELECT * FROM table_cEnginePosition", connect_database);
                connect_database.Open();
                SqlDataAdapter sda_GetEnginePosition = new SqlDataAdapter(command_GetEnginePosition);
                DataTable dt_GetEnginePosition = new DataTable();
                sda_GetEnginePosition.Fill(dt_GetEnginePosition);

                if (dt_GetEnginePosition.Rows.Count != 0)
                {
                    ddlEnginePosition.DataSource = dt_GetEnginePosition;
                    ddlEnginePosition.DataTextField = "EnginePosition";
                    ddlEnginePosition.DataValueField = "EnginePositionID";
                    ddlEnginePosition.DataBind();
                    ddlEnginePosition.Items.Insert(0, new ListItem("-- Wybierz pozycję silnika --", "0"));
                }
            }
        }

        private void BindClass()
        {
            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                SqlCommand command_GetClass = new SqlCommand("SELECT * FROM table_cClass", connect_database);
                connect_database.Open();
                SqlDataAdapter sda_GetClass = new SqlDataAdapter(command_GetClass);
                DataTable dt_GetClass = new DataTable();
                sda_GetClass.Fill(dt_GetClass);

                if (dt_GetClass.Rows.Count != 0)
                {
                    ddlCarClass.DataSource = dt_GetClass;
                    ddlCarClass.DataTextField = "ClassName";
                    ddlCarClass.DataValueField = "ClassID";
                    ddlCarClass.DataBind();
                    ddlCarClass.Items.Insert(0, new ListItem("-- Wybierz klasę samochodu --", "0"));
                }
            }
        }

        private void BindDetails()
        {
            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                SqlCommand command_GetDetails = new SqlCommand("SELECT * FROM table_cDetails ORDER BY DetailName ASC", connect_database);
                connect_database.Open();
                SqlDataAdapter sda_GetDetails = new SqlDataAdapter(command_GetDetails);
                DataTable dt_GetDetails = new DataTable();
                sda_GetDetails.Fill(dt_GetDetails);

                if (dt_GetDetails.Rows.Count != 0)
                {
                    chkblDetails.DataSource = dt_GetDetails;
                    chkblDetails.DataTextField = "DetailName";
                    chkblDetails.DataValueField = "DetailID";
                    chkblDetails.DataBind();
                }
            }
        }

        private void BindDrive()
        {
            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                SqlCommand command_GetDrive = new SqlCommand("SELECT * FROM table_cDrive", connect_database);
                connect_database.Open();
                SqlDataAdapter sda_GetDrive = new SqlDataAdapter(command_GetDrive);
                DataTable dt_GetDrive = new DataTable();
                sda_GetDrive.Fill(dt_GetDrive);

                if (dt_GetDrive.Rows.Count != 0)
                {
                    ddlDrive.DataSource = dt_GetDrive;
                    ddlDrive.DataTextField = "DriveName";
                    ddlDrive.DataValueField = "DriveID";
                    ddlDrive.DataBind();
                    ddlDrive.Items.Insert(0, new ListItem("-- Wybierz rodzaj napędu --", "0"));
                }
            }
        }

        private void BindGearbox()
        {
            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                SqlCommand command_GetGearbox = new SqlCommand("SELECT * FROM table_cGearbox", connect_database);
                connect_database.Open();
                SqlDataAdapter sda_GetGearbox = new SqlDataAdapter(command_GetGearbox);
                DataTable dt_GetGearbox = new DataTable();
                sda_GetGearbox.Fill(dt_GetGearbox);

                if (dt_GetGearbox.Rows.Count != 0)
                {
                    ddlGearbox.DataSource = dt_GetGearbox;
                    ddlGearbox.DataTextField = "GearboxName";
                    ddlGearbox.DataValueField = "GearboxID";
                    ddlGearbox.DataBind();
                    ddlGearbox.Items.Insert(0, new ListItem("-- Wybierz rodzaj skrzynii biegów --", "0"));
                }
            }
        }

        private void BindEngine()
        {
            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                SqlCommand command_GetEngine = new SqlCommand("SELECT * FROM table_cEngines", connect_database);
                connect_database.Open();
                SqlDataAdapter sda_GetEngine = new SqlDataAdapter(command_GetEngine);
                DataTable dt_GetEngine = new DataTable();
                sda_GetEngine.Fill(dt_GetEngine);

                if (dt_GetEngine.Rows.Count != 0)
                {
                    ddlEngineType.DataSource = dt_GetEngine;
                    ddlEngineType.DataTextField = "EngineName";
                    ddlEngineType.DataValueField = "EngineID";
                    ddlEngineType.DataBind();
                    ddlEngineType.Items.Insert(0, new ListItem("-- Wybierz rodzaj silnika --", "0"));
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

        protected void btnAddCar_Click(object sender, EventArgs e)
        {
            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                SqlCommand command_AddCar = new SqlCommand("procInsertCars", connect_database);
                command_AddCar.CommandType = CommandType.StoredProcedure;
                command_AddCar.Parameters.AddWithValue("@Name", txtbCarName.Text);
                command_AddCar.Parameters.AddWithValue("@Price", txtbCarPrice.Text);
                command_AddCar.Parameters.AddWithValue("@SellPrice", txtbCarSellPrice.Text);
                command_AddCar.Parameters.AddWithValue("@ManufacturerID", ddlCarManufacturer.SelectedItem.Value);
                command_AddCar.Parameters.AddWithValue("@ModelID", ddlCarModel.SelectedItem.Value);
                command_AddCar.Parameters.AddWithValue("@GenerationID", ddlCarGeneration.SelectedItem.Value);
                command_AddCar.Parameters.AddWithValue("@ClassID", ddlCarClass.SelectedItem.Value);
                command_AddCar.Parameters.AddWithValue("@Description", txtbCarDesc.Text);
                command_AddCar.Parameters.AddWithValue("@Details", txtbCarDetail.Text);
                command_AddCar.Parameters.AddWithValue("@Access", txtbAccess.Text);
                command_AddCar.Parameters.AddWithValue("@GarageID", ddlGarage.SelectedItem.Value);
                command_AddCar.Parameters.AddWithValue("@Capacity", txtbCapacity.Text);
                command_AddCar.Parameters.AddWithValue("@EngineID", ddlEngineType.SelectedItem.Value);
                command_AddCar.Parameters.AddWithValue("@EnginePositionID", ddlEnginePosition.SelectedItem.Value);
                command_AddCar.Parameters.AddWithValue("@GearNumber", txtbGears.Text);
                command_AddCar.Parameters.AddWithValue("@GearboxID", ddlGearbox.SelectedItem.Value);
                command_AddCar.Parameters.AddWithValue("@DriveID", ddlDrive.SelectedItem.Value);
                command_AddCar.Parameters.AddWithValue("@ColorID", ddlPaint.SelectedItem.Value);
                if (chkbFreeWeekend.Checked == true)
                {
                    command_AddCar.Parameters.AddWithValue("@FreeWeekend", 1.ToString());
                }
                else
                {
                    command_AddCar.Parameters.AddWithValue("@FreeWeekend", 0.ToString());
                }
                if (chkbPledgetCar.Checked == true)
                {
                    command_AddCar.Parameters.AddWithValue("@PledgetCar", 1.ToString());
                }
                else
                {
                    command_AddCar.Parameters.AddWithValue("@PledgetCar", 0.ToString());
                }
                if (chkbLimitedDistance.Checked == true)
                {
                    command_AddCar.Parameters.AddWithValue("@LimitedDistance", 1.ToString());
                }
                else
                {
                    command_AddCar.Parameters.AddWithValue("@LimitedDistance", 0.ToString());
                }
                connect_database.Open();
                Int64 CarID = Convert.ToInt64(command_AddCar.ExecuteScalar());

                // Insert Tier Quantity
                for (int i = 0; i < chkclTier.Items.Count; i++)
                {
                    if (chkclTier.Items[i].Selected == true)
                    {
                        Int64 TierID = Convert.ToInt64(chkclTier.Items[i].Value);
                        int Quantity = Convert.ToInt32(txtbQuantity.Text);

                        SqlCommand command_InsertTQuant = new SqlCommand("INSERT INTO table_cTierQuantity VALUES('" + CarID + "','" + TierID + "','" + Quantity + "')", connect_database);
                        command_InsertTQuant.ExecuteNonQuery();
                    }
                }

                // Insert/Upload images
                if (fuCarImage01.HasFile)
                {
                    string SavePath = Server.MapPath("~/img/CarImages/") + CarID;
                    if (!Directory.Exists(SavePath))
                    {
                        Directory.CreateDirectory(SavePath);
                    }
                    string Extention = Path.GetExtension(fuCarImage01.PostedFile.FileName);
                    fuCarImage01.SaveAs(SavePath + "\\" + txtbCarName.Text.ToString().Trim() + "01" + Extention);

                    SqlCommand command_Image01 = new SqlCommand("INSERT INTO table_cImages VALUES('" + CarID + "','" + txtbCarName.Text.ToString().Trim() + "01" + "','" + Extention + "')", connect_database);
                    command_Image01.ExecuteNonQuery();
                }

                if (fuCarImage02.HasFile)
                {
                    string SavePath = Server.MapPath("~/img/CarImages/") + CarID;
                    if (!Directory.Exists(SavePath))
                    {
                        Directory.CreateDirectory(SavePath);
                    }
                    string Extention = Path.GetExtension(fuCarImage02.PostedFile.FileName);
                    fuCarImage02.SaveAs(SavePath + "\\" + txtbCarName.Text.ToString().Trim() + "02" + Extention);

                    SqlCommand command_Image02 = new SqlCommand("INSERT INTO table_cImages VALUES('" + CarID + "','" + txtbCarName.Text.ToString().Trim() + "02" + "','" + Extention + "')", connect_database);
                    command_Image02.ExecuteNonQuery();
                }

                if (fuCarImage03.HasFile)
                {
                    string SavePath = Server.MapPath("~/img/CarImages/") + CarID;
                    if (!Directory.Exists(SavePath))
                    {
                        Directory.CreateDirectory(SavePath);
                    }
                    string Extention = Path.GetExtension(fuCarImage03.PostedFile.FileName);
                    fuCarImage03.SaveAs(SavePath + "\\" + txtbCarName.Text.ToString().Trim() + "03" + Extention);

                    SqlCommand command_Image03 = new SqlCommand("INSERT INTO table_cImages VALUES('" + CarID + "','" + txtbCarName.Text.ToString().Trim() + "03" + "','" + Extention + "')", connect_database);
                    command_Image03.ExecuteNonQuery();
                }

                if (fuCarImage04.HasFile)
                {
                    string SavePath = Server.MapPath("~/img/CarImages/") + CarID;
                    if (!Directory.Exists(SavePath))
                    {
                        Directory.CreateDirectory(SavePath);
                    }
                    string Extention = Path.GetExtension(fuCarImage04.PostedFile.FileName);
                    fuCarImage04.SaveAs(SavePath + "\\" + txtbCarName.Text.ToString().Trim() + "04" + Extention);

                    SqlCommand command_Image04 = new SqlCommand("INSERT INTO table_cImages VALUES('" + CarID + "','" + txtbCarName.Text.ToString().Trim() + "04" + "','" + Extention + "')", connect_database);
                    command_Image04.ExecuteNonQuery();
                }

                if (fuCarImage05.HasFile)
                {
                    string SavePath = Server.MapPath("~/img/CarImages/") + CarID;
                    if (!Directory.Exists(SavePath))
                    {
                        Directory.CreateDirectory(SavePath);
                    }
                    string Extention = Path.GetExtension(fuCarImage05.PostedFile.FileName);
                    fuCarImage05.SaveAs(SavePath + "\\" + txtbCarName.Text.ToString().Trim() + "05" + Extention);

                    SqlCommand command_Image05 = new SqlCommand("INSERT INTO table_cImages VALUES('" + CarID + "','" + txtbCarName.Text.ToString().Trim() + "05" + "','" + Extention + "')", connect_database);
                    command_Image05.ExecuteNonQuery();
                }

                if (fuCarImage06.HasFile)
                {
                    string SavePath = Server.MapPath("~/img/CarImages/") + CarID;
                    if (!Directory.Exists(SavePath))
                    {
                        Directory.CreateDirectory(SavePath);
                    }
                    string Extention = Path.GetExtension(fuCarImage06.PostedFile.FileName);
                    fuCarImage06.SaveAs(SavePath + "\\" + txtbCarName.Text.ToString().Trim() + "06" + Extention);

                    SqlCommand command_Image06 = new SqlCommand("INSERT INTO table_cImages VALUES('" + CarID + "','" + txtbCarName.Text.ToString().Trim() + "06" + "','" + Extention + "')", connect_database);
                    command_Image06.ExecuteNonQuery();
                }


                // clear form start
                txtbCarName.Text = string.Empty;
                txtbCarPrice.Text = string.Empty;
                txtbCarSellPrice.Text = string.Empty;
                ddlCarManufacturer.ClearSelection();
                ddlCarManufacturer.Items.FindByValue("0").Selected = true;
                ddlCarModel.ClearSelection();
                ddlCarModel.Items.FindByValue("0").Selected = true;
                ddlCarGeneration.ClearSelection();
                ddlCarGeneration.Items.FindByValue("0").Selected = true;
                ddlCarClass.ClearSelection();
                ddlCarClass.Items.FindByValue("0").Selected = true;
                txtbCarDesc.Text = string.Empty;
                txtbCarDetail.Text = string.Empty;
                chkblDetails.ClearSelection();
                txtbAccess.Text = string.Empty;
                txtbQuantity.Text = string.Empty;
                ddlGarage.ClearSelection();
                ddlGarage.Items.FindByValue("0").Selected = true;
                txtbCapacity.Text = string.Empty;
                ddlEngineType.ClearSelection();
                ddlEngineType.Items.FindByValue("0").Selected = true;
                ddlEnginePosition.ClearSelection();
                ddlEnginePosition.Items.FindByValue("0").Selected = true;
                txtbGears.Text = string.Empty;
                ddlGearbox.ClearSelection();
                ddlGearbox.Items.FindByValue("0").Selected = true;
                ddlDrive.ClearSelection();
                ddlDrive.Items.FindByValue("0").Selected = true;
                ddlPaint.ClearSelection();
                ddlPaint.Items.FindByValue("0").Selected = true;
            }
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

        protected void ddlCarGeneration_SelectedIndexChanged(object sender, EventArgs e)
        {
            int GenerationID = Convert.ToInt32(ddlCarModel.SelectedItem.Value);
            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                SqlCommand command_GetColors = new SqlCommand("SELECT * FROM table_cColors WHERE GenerationID='" + ddlCarGeneration.SelectedItem.Value + "'", connect_database);
                connect_database.Open();
                SqlDataAdapter sda_GetColors = new SqlDataAdapter(command_GetColors);
                DataTable dt_GetColors = new DataTable();
                sda_GetColors.Fill(dt_GetColors);

                if (dt_GetColors.Rows.Count != 0)
                {
                    ddlPaint.DataSource = dt_GetColors;
                    ddlPaint.DataTextField = "ColorName";
                    ddlPaint.DataValueField = "ColorID";
                    ddlPaint.DataBind();
                    ddlPaint.Items.Insert(0, new ListItem("-- Wybierz kolor --", "0"));
                    ddlPaint.Enabled = true;
                    ddlCarClass.Enabled = true;
                }
            }
        }

        protected void btnSaveDet_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chkblDetails.Items.Count; i++)
            {
                if (chkblDetails.Items[i].Selected)
                {
                    txtbCarDetail.Text += chkblDetails.Items[i].Text + ",";
                }
            }
        }

        protected void ddlCarClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                SqlCommand command_GetClasses = new SqlCommand("SELECT * FROM table_cTier WHERE ClassID='" + ddlCarClass.SelectedItem.Value + "'", connect_database);
                connect_database.Open();
                SqlDataAdapter sda_GetClasses = new SqlDataAdapter(command_GetClasses);
                DataTable dt_GetClasses = new DataTable();
                sda_GetClasses.Fill(dt_GetClasses);

                if (dt_GetClasses.Rows.Count != 0)
                {
                    chkclTier.DataSource = dt_GetClasses;
                    chkclTier.DataTextField = "TierName";
                    chkclTier.DataValueField = "TierID";
                    chkclTier.DataBind();
                }
            }
        }
    }
}