using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_3
{
    public partial class WebForm6 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //Using the DAL we connect to the database and Login using the Username and Password supplied 
            //by the user.
            DAL_Project.DAL d = new DAL_Project.DAL(ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString);
            d.AddParam("Username", txtUsername.Text);
            d.AddParam("Password", txtPassword.Text);
            DataSet ds = d.ExecuteProcedure("spLogin");

            User u;
            //assign the user level and user name keys to the current user's access level and name from the data table
            //provided that the table is not empty
            if (ds.Tables[0].Rows.Count > 0)
            {
                u = (User)Session["user"];
                int userId = (int)ds.Tables[0].Rows[0]["UserID"];
                int accessLevel = (int)ds.Tables[0].Rows[0]["AccessLevel"];

                //if the User ID is less than 2, the user is not an Admin client so they are redirected to
                //the Products page. 
                if (userId < 2)
                {
                    u = new User(userId,accessLevel);
                    Session["user"] = u;
                    Response.Redirect("AllProducts.aspx");
                }

                //if the user is an Admin, they are redirected to the Admin page.
                else
                {
                    u = new Admin(userId,accessLevel);
                    Session["user"] = u;
                    Response.Redirect("Admin.aspx");
                }
            }
            else
            {
                //If the Username and/or Password supplied is wrong, display the message below.

                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Wrong Username/Password!');", true);
            }
            
        }
    }
}