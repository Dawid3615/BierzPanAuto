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
    public partial class Payment : BasePage
    {
        public static String connection_string = ConfigurationManager.ConnectionStrings["BierzPanAutoDatabaseConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USRPWD"] != null)
            {
                if (!IsPostBack)
                {
                    BindPriceData();
                }
            }
            else
            {
                Response.Redirect("~/SignIn.aspx");
            }
        }

        private void BindPriceData()
        {
            if (Request.Cookies["TakeCarID"] != null)
            {
                string CookieData = Request.Cookies["TakeCarID"].Value.Split('=')[1];
                string[] CookieDataArray = CookieData.Split(',');
                if (CookieDataArray.Length > 0)
                {
                    DataTable dt_TakePriceData = new DataTable();
                    Int64 TakeTotal = 0;
                    Int64 Disc = 0;
                    for (int i = 0; i < CookieDataArray.Length; i++)
                    {
                        string CarID = CookieDataArray[i].ToString().Split('-')[0];
                        string TierID = CookieDataArray[i].ToString().Split('-')[1];

                        if (hfCarIDTierID.Value != null && hfCarIDTierID.Value != "")
                        {
                            hfCarIDTierID.Value += "," + CarID + "-" + TierID;
                        }
                        else
                        {
                            hfCarIDTierID.Value += CarID + "-" + TierID;
                        }

                        using (SqlConnection connect_database = new SqlConnection(connection_string))
                        {
                            using (SqlCommand command_TakeCars = new SqlCommand("SELECT A.*, dbo.funcGetTierName(" + TierID + ") AS TierNamee,"
                                + TierID + " AS TierIDD,TierData.ImageName,TierData.ImageExtention FROM table_Cars A cross apply(SELECT TOP 1 B.ImageName, ImageExtention FROM table_cImages B WHERE B.CarID = A.CarID) TierData WHERE A.CarID="
                                + CarID + "", connect_database))
                            {
                                command_TakeCars.CommandType = CommandType.Text;
                                using (SqlDataAdapter sda_TakeCars = new SqlDataAdapter(command_TakeCars))
                                {
                                    sda_TakeCars.Fill(dt_TakePriceData);

                                }
                            }
                        }
                        TakeTotal += Convert.ToInt64(dt_TakePriceData.Rows[i]["Price"]);
                        Disc += Convert.ToInt64(dt_TakePriceData.Rows[i]["SellPrice"]);
                    }
                    divPriceDetails.Visible = true;

                    spanRentTotal.InnerText = TakeTotal.ToString();
                    spanDisc.InnerText = "- " + Disc.ToString();
                    spanTotal.InnerText = (TakeTotal - Disc).ToString();

                    hfAmount.Value = TakeTotal.ToString();
                    hfDiscount.Value = Disc.ToString();
                    hfTotalPayed.Value = (TakeTotal - Disc).ToString();
                }
                else
                {
                    // pokaż pusty koszyk
                    Response.Redirect("~/Cars.aspx");
                }
            }
            else
            {
                // pokaż pusty koszyk
                Response.Redirect("~/Cars.aspx");
            }
        }

        protected void btnPayPal_Click(object sender, EventArgs e)
        {
            if (Session["USERID"] != null)
            {
                string USERID = Session["USERID"].ToString();
                string PaymentType = "PayPal";
                string PaymentStatus = "Nie zapłacono";
                string EMAILID = Session["USEREMAIL"].ToString();
                DateTime DateOfPurchase = DateTime.Now;

                using (SqlConnection connect_database = new SqlConnection(connection_string))
                {
                    SqlCommand command_PayPal = new SqlCommand("INSERT INTO table_Purchase VALUES('" + USERID + "','" + hfCarIDTierID.Value + "','" + hfAmount.Value + "','" + hfDiscount.Value + "','" + hfTotalPayed.Value + "','" + PaymentType + "','" + PaymentStatus + "','" + DateOfPurchase + "','" + txtbName.Text + "','" + txtbAddress.Text + "','" + txtbZipCode.Text + "')SELECT SCOPE_IDENTITY()", connect_database);
                    connect_database.Open();
                    Int64 PurchaseID = Convert.ToInt64(command_PayPal.ExecuteScalar());
                }
            }
            else
            {
                Response.Redirect("~/Cars.aspx");
            }
        }
    }
}