using System;
using System.IO;
using System.Web;

namespace BierzPanAuto.App_Code
{
    public class BasePage : System.Web.UI.Page
    {
        protected override void OnLoadComplete(EventArgs e)
        {
            if (string.IsNullOrEmpty(Page.Title) || Page.Title == "Untitled Page" || Page.Title == "Strona bez tytułu")
            {
                string newTitle = null;

                SiteMapNode current = SiteMap.CurrentNode;

                if (current != null)
                {
                    newTitle = current.Title;
                }
                else
                {
                    newTitle = Path.GetFileNameWithoutExtension(Request.PhysicalPath);
                }

                Page.Title = "Bierz Pan Auto | " + newTitle;
            }

            base.OnLoadComplete(e);
        }
    }
}