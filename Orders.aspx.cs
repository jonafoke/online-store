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
    public partial class WebForm12 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Bind the products to the gridview.
                gvOrders.DataSource = BindOrders();
                gvOrders.DataBind();
            }
           
            //we assign the user variable to the Session, if the user is an Admin, they stay on this page.
            //If not, they get redirected to the Welcome page.
            User user = (User)Session["user"];
            if (user is Admin)
            {
                int accessLevel = Convert.ToInt32(Session["UserLevel"]);

            }
            else
            {
                //redirect user to default page since they aren't loggin in
                Response.Redirect("Default.aspx");
            }
        }
        /// <summary>
        /// This method connects to the database and returns back all orders that have been made
        /// </summary>
        /// <returns></returns>
        private DataSet BindOrders()
        {
            
            DAL_Project.DAL d = new DAL_Project.DAL(ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString);

            if (Session["SortColumn"] != null)
            {
                d.AddParam("SortColumn", Session["SortColumn"].ToString());
            }

            DataSet ds = d.ExecuteProcedure("spGetOrders");
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
        protected void gvOrders_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvOrders.DataSource = BindOrders();
            gvOrders.PageIndex = e.NewPageIndex;
            gvOrders.DataBind();
        }

        /// <summary>
        /// This enables us to sort whatever column the user would like.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvOrders_Sorting(object sender, GridViewSortEventArgs e)
        {
            Session["SortColumn"] = e.SortExpression;
            gvOrders.DataSource = BindOrders();
            gvOrders.DataBind();
        }

    }
}