using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_3
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User u;
            u = (User)Session["user"];

            //on page load we check to see that there is a user signed in. If they are an Admin, the button
            //that lets them get to the Admin Page is made visible
            if (u is Admin)
            {
                btnAdminPage.Visible = true;
            }
            else
            {
                btnAdminPage.Visible = false;
            }

            //If there is a User signed in, their Customer ID will be shown in the label and the Logout 
            //button is made visible so they can log out
            if (Session["User"] != null)
            {
            
                lblCustomerId.Text = "Customer ID = " + u.custId;
                btnLogout.Visible = true;
            }
            else
            {
                btnLogout.Visible = false;
            }
        }
         
        /// <summary>
        /// lets the user view their shopping cart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnViewCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShoppingCart.aspx");
        }

        /// <summary>
        /// logs the user out
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        /// <summary>
        /// sends the user to the admin page if they have access.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdminPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }
    }
}

//User u;

//// When a user logs in, you grab the row matching their username/password
//// if you have a row, the user/pass is corect.
//// grab their access level.
//// if it's a user:
//u= new User();

//// if it's an admin:
//u = new Admin();

//// either way.. assign it to the session:
//Session["user"] = u;

//// later on, you can check for admin like this:
//User user = (User)Session["user"];
//if (user is Admin)
//{

//}

//}