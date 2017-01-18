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
    public partial class WebForm15 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Bind the products to the gridview.
                gvItemQuantitySold.DataSource = BindSales();
                gvItemQuantitySold.DataBind();
            }

            User user = (User)Session["user"];
            if (user is Admin)
            {
                int accessLevel = user.accessLevel;

            }
            else
            {
                //redirect user to default page since they aren't loggin in
                Response.Redirect("Default.aspx");
            }
        }

        /// <summary>
        /// This returns back a report showing what units were sold for each item in a gridview.
        /// </summary>
        /// <returns></returns>
        private DataSet BindSales()
        {
            //Create a connection object
            DAL_Project.DAL d = new DAL_Project.DAL(ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString);

            DataSet ds = d.ExecuteProcedure("spUnitsSoldPerItem");
            return ds;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }

        /// <summary>
        /// This enables us to change pages if the user clicks on the numbers at the bottom of the gridview.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvItemQuantitySold_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvItemQuantitySold.DataSource = BindSales();
            gvItemQuantitySold.PageIndex = e.NewPageIndex;
            gvItemQuantitySold.DataBind();
        }
    }
}