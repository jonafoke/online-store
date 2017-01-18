using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_3
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //This is a page only Admin users have right to access. At page load we check to see if the user
            //has Admin status, if they do not they are redirected to the Welcome page (Default).
            User u = (User)Session["user"];
            bool isAdmin = u is Admin;
            if (!isAdmin)
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}