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
    public partial class Cars : BasePage
    {
        public static String connection_string = ConfigurationManager.ConnectionStrings["BierzPanAutoDatabaseConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCarsRepeater();
            }
        }

        private void BindCarsRepeater()
        {
            Int64 ClassID = Request.QueryString["class"] == null ? 0 : Convert.ToInt64(Request.QueryString["class"]);
            Int64 TierID = Request.QueryString["tier"] == null ? 0 : Convert.ToInt64(Request.QueryString["tier"]);

            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                using (SqlCommand command_ShowAllCars = new SqlCommand("procShowAllCars", connect_database))
                {
                    command_ShowAllCars.CommandType = CommandType.StoredProcedure;
                    if (ClassID > 0)
                    {
                        command_ShowAllCars.Parameters.AddWithValue("@ClassID", ClassID);
                    }
                    if (TierID > 0)
                    {
                        command_ShowAllCars.Parameters.AddWithValue("@TierID", TierID);
                    }
                    using (SqlDataAdapter sda_ShowAllCars = new SqlDataAdapter(command_ShowAllCars))
                    {
                        DataTable dt_ShowAllCars = new DataTable();
                        sda_ShowAllCars.Fill(dt_ShowAllCars);
                        RepeaterCar.DataSource = dt_ShowAllCars;
                        RepeaterCar.DataBind();
                    }
                }
            }
        }
    }
}