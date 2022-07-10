using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BierzPanAuto
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdminSignOut_Click(object sender, EventArgs e)
        {
            Session["USRPWD"] = null;
            Response.Redirect("~/Default.aspx");
        }
    }
}