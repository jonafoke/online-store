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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //bind the DataList if this page load is not a postback.
            if (!IsPostBack)
            {
                dlClothing.DataSource = RefreshClothing();
                dlClothing.DataBind();
            }
        }

        /// <summary>
        /// this Dataset populates the DataList on page load.
        /// </summary>
        /// <returns></returns>
        private DataSet RefreshClothing()
        {
            DAL_Project.DAL d = new DAL_Project.DAL(ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString);
            return d.ExecuteProcedure("spGetClothing");
        }

        protected void dlClothing_ItemCommand(object source, DataListCommandEventArgs e)
        {
            //this adds the Product the user clicked on to the Shopping Cart
            if (e.CommandName == "add")
            {
                Label s = (Label)e.Item.FindControl("lblProductID");
                int productId = int.Parse(s.Text);
                Cart.cart.AddItem(productId);
            }
        }

        protected void dlClothing_SelectedIndexChanged(object sender, EventArgs e)
        {
            dlClothing.DataBind();
        }
    }
}