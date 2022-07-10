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
    public partial class Take : BasePage
    {
        public static String connection_string = ConfigurationManager.ConnectionStrings["BierzPanAutoDatabaseConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTakeCars();
            }
        }

        private void BindTakeCars()
        {
            if (Request.Cookies["TakeCarID"] != null)
            {
                string CookieData = Request.Cookies["TakeCarID"].Value.Split('=')[1];
                string[] CookieDataArray = CookieData.Split(',');
                if (CookieDataArray.Length > 0)
                {
                    h1NoItems.InnerText = "Moje zamówienie (" + CookieDataArray.Length + " Samochody)";
                    DataTable dt_TakeCars = new DataTable();
                    Int64 TakeTotal = 0;
                    Int64 Disc = 0;
                    for (int i = 0; i < CookieDataArray.Length; i++)
                    {
                        string CarID = CookieDataArray[i].ToString().Split('-')[0];
                        string TierID = CookieDataArray[i].ToString().Split('-')[1];

                        using (SqlConnection connect_database = new SqlConnection(connection_string))
                        {
                            using (SqlCommand command_TakeCars = new SqlCommand("SELECT A.*, dbo.funcGetTierName(" + TierID + ") AS TierNamee,"
                                + TierID + " AS TierIDD,TierData.ImageName,TierData.ImageExtention FROM table_Cars A cross apply(SELECT TOP 1 B.ImageName, ImageExtention FROM table_cImages B WHERE B.CarID = A.CarID) TierData WHERE A.CarID="
                                + CarID + "", connect_database))
                            {
                                command_TakeCars.CommandType = CommandType.Text;
                                using (SqlDataAdapter sda_TakeCars = new SqlDataAdapter(command_TakeCars))
                                {
                                    sda_TakeCars.Fill(dt_TakeCars);

                                }
                            }
                        }
                        TakeTotal += Convert.ToInt64(dt_TakeCars.Rows[i]["Price"]);
                        Disc += Convert.ToInt64(dt_TakeCars.Rows[i]["SellPrice"]);
                    }
                    RepeaterTakeCars.DataSource = dt_TakeCars;
                    RepeaterTakeCars.DataBind();
                    divPriceDetails.Visible = true;

                    spanRentTotal.InnerText = TakeTotal.ToString();
                    spanDisc.InnerText = "- " + Disc.ToString();
                    spanTotal.InnerText = (TakeTotal - Disc).ToString();
                }
                else
                {
                    // pokaż pusty koszyk
                    h1NoItems.InnerText = "Twoje zamówienie jest puste.";
                    divPriceDetails.Visible = false;
                }
            }
            else
            {
                // pokaż pusty koszyk
                h1NoItems.InnerText = "Twoje zamówienie jest puste.";
                divPriceDetails.Visible = false;
            }
        }

        protected void btnRemoveItem_Click(object sender, EventArgs e)
        {
            string CookieCarID = Request.Cookies["TakeCarID"].Value.Split('=')[1];
            Button btn = (Button)(sender);
            string CarIDTier = btn.CommandArgument;

            List<String> CookieCarIDList = CookieCarID.Split(',').Select(i => i.Trim()).Where(i => i != string.Empty).ToList();
            CookieCarIDList.Remove(CarIDTier);
            string CookieCarIDUpdated = String.Join(",", CookieCarIDList.ToArray());

            if (CookieCarIDUpdated == "")
            {
                HttpCookie TakenCars = Request.Cookies["TakeCarID"];
                TakenCars.Values["TakeCarID"] = null;
                TakenCars.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(TakenCars);
            }
            else
            {
                HttpCookie TakenCars = Request.Cookies["TakeCarID"];
                TakenCars.Values["TakeCarID"] = CookieCarIDUpdated;
                TakenCars.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(TakenCars);
            }
            Response.Redirect("~/Take.aspx");
        }

        protected void btnTakeItem_Click(object sender, EventArgs e)
        {
            if (Session["USRPWD"] != null)
            {
                Response.Redirect("~/Payment.aspx");
            }
            else
            {
                Response.Redirect("~/SignIn.aspx?rurl=take");
            }
        }
    }
}