using BierzPanAuto.App_Code;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using static BierzPanAuto.Global;

namespace BierzPanAuto
{
    public partial class AdminHome : BasePage
    {
        public static String connection_string = ConfigurationManager.ConnectionStrings["BierzPanAutoDatabaseConnectionString"].ConnectionString;

        String UserIDValue;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindManufacturerRepeater();
                BindModelRepeaater();
                BindRepeaterColors();
                BindSubModelRepeater();
                BindUsersRepeater();
                BindAllClasses();
                BindRepeaterTiers();
                BindGarageRepeater();
                //BindAllCars();
            }
        }

        //private void BindAllCars()
        //{
        //    using (SqlConnection connect_database = new SqlConnection(connection_string))
        //    {
        //        using (SqlCommand command_GetAllCars = new SqlCommand("procGetAllCars", connect_database))
        //        {
        //            command_GetAllCars.CommandType = CommandType.StoredProcedure;
        //            using (SqlDataAdapter sda_GetAllCars = new SqlDataAdapter(command_GetAllCars))
        //            {
        //                DataTable dt_GetAllCars = new DataTable();
        //                sda_GetAllCars.Fill(dt_GetAllCars);
        //                RepeaterCars.DataSource = dt_GetAllCars;
        //                RepeaterCars.DataBind();
        //            }
        //        }
        //    }
        //}

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
        private void BindUsersRepeater()
        {
            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                using (SqlCommand command_GetAllUsers = new SqlCommand("procGetAllUsers", connect_database))
                {
                    command_GetAllUsers.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda_GetAllUsers = new SqlDataAdapter(command_GetAllUsers))
                    {
                        DataTable dt_GetAllUsers = new DataTable();
                        sda_GetAllUsers.Fill(dt_GetAllUsers);
                        RepeaterUsers.DataSource = dt_GetAllUsers;
                        RepeaterUsers.DataBind();
                    }
                }
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
        private void BindRepeaterTiers()
        {
            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                using (SqlCommand command_GetAllTiers = new SqlCommand("procGetAllTiers", connect_database))
                {
                    command_GetAllTiers.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda_GetAllTiers = new SqlDataAdapter(command_GetAllTiers))
                    {
                        DataTable dt_GetAllTiers = new DataTable();
                        sda_GetAllTiers.Fill(dt_GetAllTiers);
                        RepeaterTiers.DataSource = dt_GetAllTiers;
                        RepeaterTiers.DataBind();
                    }
                }
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

        // Usuwanie 
        protected void btnUserDelete_Click(object sender, EventArgs e) // usuwanie użytkowników
        {
            RepeaterItem Itn = (sender as Button).Parent as RepeaterItem;
            Label Ids = ((Label)Itn.FindControl("lblUserID")) as Label;

            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                SqlCommand command_DeleteUser = new SqlCommand("DELETE FROM table_Users WHERE UserID=" + Ids.Text, connect_database);
                connect_database.Open();
                command_DeleteUser.ExecuteNonQuery();
                connect_database.Close();
                PageUtility.MessageBox(this, "Usunięto użytkownika");
                BindUsersRepeater();
            }
        }

        protected void btnClassDelete_Click(object sender, EventArgs e) // usuwanie klas
        {
            RepeaterItem Itn = (sender as Button).Parent as RepeaterItem;
            Label Ids = ((Label)Itn.FindControl("lblClassID")) as Label;

            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                SqlCommand command_DeleteClass = new SqlCommand("DELETE FROM table_cClass WHERE ClassID=" + Ids.Text, connect_database);
                connect_database.Open();
                command_DeleteClass.ExecuteNonQuery();
                connect_database.Close();
                PageUtility.MessageBox(this, "Usunięto klasę");
                BindUsersRepeater();
            }
        }

        protected void btnManufacturerDelete_Click(object sender, EventArgs e) // usuwanie marek
        {
            RepeaterItem Itn = (sender as Button).Parent as RepeaterItem;
            Label Ids = ((Label)Itn.FindControl("lblManufacturerID")) as Label;

            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                SqlCommand command_DeleteManufacturer = new SqlCommand("DELETE FROM table_cManufacturers WHERE ManufacturerID=" + Ids.Text, connect_database);
                connect_database.Open();
                command_DeleteManufacturer.ExecuteNonQuery();
                connect_database.Close();
                PageUtility.MessageBox(this, "Usunięto markę");
                BindUsersRepeater();
            }
        }

        protected void btnModelDelete_Click(object sender, EventArgs e) // usuwanie modeli
        {
            RepeaterItem Itn = (sender as Button).Parent as RepeaterItem;
            Label Ids = ((Label)Itn.FindControl("lblModelID")) as Label;

            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                SqlCommand command_DeleteModel = new SqlCommand("DELETE FROM table_cModels WHERE ModelID=" + Ids.Text, connect_database);
                connect_database.Open();
                command_DeleteModel.ExecuteNonQuery();
                connect_database.Close();
                PageUtility.MessageBox(this, "Usunięto model");
                BindUsersRepeater();
            }
        }

        protected void btnGenerationDelete_Click(object sender, EventArgs e) // usuwanie generacji
        {
            RepeaterItem Itn = (sender as Button).Parent as RepeaterItem;
            Label Ids = ((Label)Itn.FindControl("lblGenerationID")) as Label;

            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                SqlCommand command_DeleteGeneration = new SqlCommand("DELETE FROM table_cGenerations WHERE GenerationID=" + Ids.Text, connect_database);
                connect_database.Open();
                command_DeleteGeneration.ExecuteNonQuery();
                connect_database.Close();
                PageUtility.MessageBox(this, "Usunięto generację");
                BindUsersRepeater();
            }
        }

        protected void btnColorDelete_Click(object sender, EventArgs e) // usuwanie koloru
        {
            RepeaterItem Itn = (sender as Button).Parent as RepeaterItem;
            Label Ids = ((Label)Itn.FindControl("lblColorID")) as Label;

            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                SqlCommand command_DeleteColor = new SqlCommand("DELETE FROM table_cColors WHERE ColorID=" + Ids.Text, connect_database);
                connect_database.Open();
                command_DeleteColor.ExecuteNonQuery();
                connect_database.Close();
                PageUtility.MessageBox(this, "Usunięto kolor");
                BindUsersRepeater();
            }
        }

        protected void btnTierDelete_Click(object sender, EventArgs e) // usuwanie poziomu
        {
            RepeaterItem Itn = (sender as Button).Parent as RepeaterItem;
            Label Ids = ((Label)Itn.FindControl("lblTierID")) as Label;

            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                SqlCommand command_DeleteTier = new SqlCommand("DELETE FROM table_cTier WHERE TierID=" + Ids.Text, connect_database);
                connect_database.Open();
                command_DeleteTier.ExecuteNonQuery();
                connect_database.Close();
                PageUtility.MessageBox(this, "Usunięto poziom");
                BindUsersRepeater();
            }
        }

        protected void btnGarageDelete_Click(object sender, EventArgs e) // usuwanie garażowania
        {
            RepeaterItem Itn = (sender as Button).Parent as RepeaterItem;
            Label Ids = ((Label)Itn.FindControl("lblGarageID")) as Label;

            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                SqlCommand command_DeleteGarage = new SqlCommand("DELETE FROM table_cGarage WHERE GarageID=" + Ids.Text, connect_database);
                connect_database.Open();
                command_DeleteGarage.ExecuteNonQuery();
                connect_database.Close();
                PageUtility.MessageBox(this, "Usunięto garazowanie");
                BindUsersRepeater();
            }
        }

        protected void btnCarDelete_Click(object sender, EventArgs e) // usuwanie samochodu
        {
            RepeaterItem Itn = (sender as Button).Parent as RepeaterItem;
            Label Ids = ((Label)Itn.FindControl("lblCarID")) as Label;

            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                SqlCommand command_DeleteCar = new SqlCommand("DELETE FROM table_Cars WHERE CarID=" + Ids.Text, connect_database);
                connect_database.Open();
                command_DeleteCar.ExecuteNonQuery();
                connect_database.Close();
                PageUtility.MessageBox(this, "Usunięto samochód");
                BindUsersRepeater();
            }
        }
    }
}