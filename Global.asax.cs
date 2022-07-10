using System;
using System.Web.UI;

namespace BierzPanAuto
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/scripts/jquery-3.5.1.min.js",
                DebugPath = "~/scripts/jquery-3.5.1.js",
                CdnPath = "https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.5.1.min.js",
                CdnDebugPath = "https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.5.1.js"
            });
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        public static class PageUtility
        {
            public static void MessageBox(System.Web.UI.Page page, string srtingMessage)
            {
                //+ character added after stringMessage "')"
                ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "alertMessage", "alert('" + srtingMessage + "')", true);
            }
        }
    }
}