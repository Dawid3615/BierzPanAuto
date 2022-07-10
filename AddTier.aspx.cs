using BierzPanAuto.App_Code;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace BierzPanAuto
{
    public partial class AddTier : BasePage
    {
        public static String connection_string = ConfigurationManager.ConnectionStrings["BierzPanAutoDatabaseConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindClass();
                BindRepeaterTiers();
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
                    ddlClass.DataSource = dt_GetClass;
                    ddlClass.DataTextField = "ClassName";
                    ddlClass.DataValueField = "ClassID";
                    ddlClass.DataBind();
                    ddlClass.Items.Insert(0, new ListItem("-- Wybierz klasę --", "0"));
                }
            }
        }


        protected void btnAddTier_Click(object sender, EventArgs e)
        {
            using (SqlConnection connect_database = new SqlConnection(connection_string))
            {
                SqlCommand command_AddTier = new SqlCommand("INSERT INTO table_cTier VALUES('" + txtbName.Text + "','" + ddlClass.SelectedItem.Value + "')", connect_database);
                connect_database.Open();
                command_AddTier.ExecuteNonQuery();
                txtbName.Text = string.Empty;
                ddlClass.ClearSelection();
                ddlClass.Items.FindByValue("0").Selected = true;
            }
            BindRepeaterTiers();
        }
    }
}