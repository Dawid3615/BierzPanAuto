using BierzPanAuto.App_Code;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using static BierzPanAuto.Global;

namespace BierzPanAuto
{
    public partial class ForgotPassword : BasePage
    {
        public static String connection_string = ConfigurationManager.ConnectionStrings["BierzPanAutoDatabaseConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void btnPasswordRecover_Click(object sender, EventArgs e)
        //{
        //    using (SqlConnection connect_database = new SqlConnection(connection_string))
        //    {
        //        SqlCommand command_RecoverPassword = new SqlCommand("SELECT * FROM table_Users WHERE Email='" + txtbEmail.Text + "'", connect_database);
        //        connect_database.Open();
        //        SqlDataAdapter sda_RecoverPassword = new SqlDataAdapter(command_RecoverPassword);
        //        DataTable dt_RecoverPassword = new DataTable();
        //        sda_RecoverPassword.Fill(dt_RecoverPassword);

        //        if (dt_RecoverPassword.Rows.Count != 0)
        //        {
        //            String myGUID = Guid.NewGuid().ToString();
        //            int UserID = Convert.ToInt32(dt_RecoverPassword.Rows[0][0]);
        //            SqlCommand command_InsertRequest = new SqlCommand("INSERT INTO table_ForgotPasswordRequests VALUES ('" + myGUID + "','" + UserID + "',getdate())", connect_database);
        //            command_InsertRequest.ExecuteNonQuery();

        //            // send email
        //            String ToEmailAddress = dt_RecoverPassword.Rows[0][3].ToString();
        //            String Username = dt_RecoverPassword.Rows[0][1].ToString();
        //            String EmailBody = "Cześć " + Username + ",<br /><br /> Kliknij poniższe łącze, aby zresetować hasło <br /><br /> http://localhost:59713/RecoverPassword.aspx?UserID=" + myGUID;
        //            MailMessage PasswordRevoverMail = new MailMessage("bierzpanauto@gmail.com", ToEmailAddress);
        //            PasswordRevoverMail.Body = EmailBody;
        //            PasswordRevoverMail.IsBodyHtml = true;
        //            PasswordRevoverMail.Subject = "Zresetuj hasło";

        //            SmtpClient SMTP = new SmtpClient("smtp.gmail.com", 587);
        //            SMTP.Credentials = new NetworkCredential()
        //            {
        //                UserName = "bierzpanauto@gmail.com",
        //                Password = "BierAuto#2020"
        //            };
        //            SMTP.EnableSsl = true;
        //            SMTP.Send(PasswordRevoverMail);

        //            PageUtility.MessageBox(this, "Sprawdź pocztę, aby zresetować hasło.");
        //        }
        //        else
        //        {
        //            PageUtility.MessageBox(this, "Uups... Ten identyfikator e-mail NIE ISTNIEJE w naszej bazie danych !");
        //        }
        //    }
        //}
    }
}