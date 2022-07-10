using BierzPanAuto.App_Code;
using System;

namespace BierzPanAuto
{
    public partial class UserHome : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USRPWD"] != null)
            {
                lblShowUsername.Text = "Zalogowano pomyślnie, Witaj " + Session["USRPWD"].ToString() + " !";
            }
        }
    }
}