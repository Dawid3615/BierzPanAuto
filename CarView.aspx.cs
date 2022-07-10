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
    public partial class CarView : BasePage
    {
        public static String connection_string = ConfigurationManager.ConnectionStrings["BierzPanAutoDatabaseConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["CarID"] != null)
            {
                if (!IsPostBack)
                {
                    BindCarImagesRepeaater();
                    BindCarInformation();
                }
            }
            else
            {
                Response.Redirect("~/Cars.aspx");
            }
        }

        private void BindCarInformation()
        {
            Int64 CarID = Convert.ToInt64(Request.QueryString["CarID"]);

            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                using (SqlCommand command_GetCarInfo = new SqlCommand("SELECT A.*, C.*, D.*, E.*, F.*, G.*, H.* FROM table_Cars A INNER JOIN table_cEngines C ON C.EngineID = A.EngineID INNER JOIN table_cEnginePosition D ON D.EnginePositionID = A.EnginePositionID INNER JOIN table_cGearbox E ON E.GearboxID = A.GearboxID INNER JOIN table_cGarage F ON F.GarageID = A.GarageID INNER JOIN table_cDrive G ON G.DriveID = A.DriveID INNER JOIN table_cColors H ON H.ColorID = A.ColorID WHERE CarID=" + CarID + "", connect_database))
                {
                    command_GetCarInfo.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda_GetCarInfo = new SqlDataAdapter(command_GetCarInfo))
                    {
                        DataTable dt_GetCarInfo = new DataTable();
                        sda_GetCarInfo.Fill(dt_GetCarInfo);
                        RepeaterCar.DataSource = dt_GetCarInfo;
                        RepeaterCar.DataBind();
                    }
                }
            }
        }

        private void BindCarImagesRepeaater()
        {
            Int64 CarID = Convert.ToInt64(Request.QueryString["CarID"]);

            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                using (SqlCommand command_GetCarImages = new SqlCommand("SELECT * FROM table_cImages WHERE CarID=" + CarID + "", connect_database))
                {
                    command_GetCarImages.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda_GetCarImages = new SqlDataAdapter(command_GetCarImages))
                    {
                        DataTable dt_GetCarImages = new DataTable();
                        sda_GetCarImages.Fill(dt_GetCarImages);
                        RepeaterImages.DataSource = dt_GetCarImages;
                        RepeaterImages.DataBind();
                    }
                }
            }
        }

        protected string GetActiveClass(int ItemIndex)
        {
            if (ItemIndex == 0)
            {
                return "active";
            }
            else
            {
                return "";
            }
        }

        protected void RepeaterCar_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string ManufacturerID = (e.Item.FindControl("hfManufacturer") as HiddenField).Value;
                string ModelID = (e.Item.FindControl("hfModel") as HiddenField).Value;
                string GenerationID = (e.Item.FindControl("hfGeneration") as HiddenField).Value;
                string ClassID = (e.Item.FindControl("hfClass") as HiddenField).Value;

                RadioButtonList rblTier = e.Item.FindControl("rbtnlstClass") as RadioButtonList;

                using (SqlConnection connect_database = new SqlConnection(connection_string))
                {
                    using (SqlCommand command_GetTiers = new SqlCommand("SELECT * FROM table_cTier WHERE ClassID=" + ClassID + "", connect_database))
                    {
                        command_GetTiers.CommandType = CommandType.Text;
                        using (SqlDataAdapter sda_GetTiers = new SqlDataAdapter(command_GetTiers))
                        {
                            DataTable dt_GetTiers = new DataTable();
                            sda_GetTiers.Fill(dt_GetTiers);
                            rblTier.DataSource = dt_GetTiers;
                            rblTier.DataTextField = "TierName";
                            rblTier.DataValueField = "TierID";
                            rblTier.DataBind();
                        }
                    }
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string SelectedTier = string.Empty;
            foreach (RepeaterItem item in RepeaterCar.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    var rbList = item.FindControl("rbtnlstClass") as RadioButtonList;
                    SelectedTier = rbList.SelectedValue;
                }
            }

            if (SelectedTier != "")
            {
                Int64 CarID = Convert.ToInt64(Request.QueryString["CarID"]);

                if (Request.Cookies["TakeCarID"] != null)
                {
                    string CookieCarID = Request.Cookies["TakeCarID"].Value.Split('=')[1];
                    CookieCarID = CookieCarID + "," + CarID + "-" + SelectedTier;

                    HttpCookie TakenCars = new HttpCookie("TakeCarID");
                    TakenCars.Values["TakeCarID"] = CookieCarID;
                    TakenCars.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(TakenCars);
                }
                else
                {
                    HttpCookie TakenCars = new HttpCookie("TakeCarID");
                    TakenCars.Values["TakeCarID"] = CarID.ToString() + "-" + SelectedTier;
                    TakenCars.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(TakenCars);
                }
                Response.Redirect("~/CarView.aspx?CarID=" + CarID);
            }
            else
            {
                foreach (RepeaterItem item in RepeaterCar.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        PageUtility.MessageBox(this, "Proszę wybrać poziom");
                    }
                }
            }
        }
    }
}