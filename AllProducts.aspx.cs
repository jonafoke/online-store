using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_3
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //bind the DataList if this page load is not a postback.
            if (!IsPostBack)
            {
                dlProducts.DataSource = RefreshProducts();
                dlProducts.DataBind();
               
            }
        }

            /// <summary>
        /// this Dataset populates the DataList on page load.
        /// </summary>
        /// <returns></returns>
        private DataSet RefreshProducts()
        {
            DAL_Project.DAL d = new DAL_Project.DAL("Data Source=localhost; Initial Catalog=dbActiveLiving; Integrated Security=SSPI");
            return d.ExecuteProcedure("spGetProducts");
        }

        protected void dlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            dlProducts.DataBind();
        }

        protected void dlProducts_ItemCommand(object source, DataListCommandEventArgs e)
        {
            //this adds the product that the user clicks on to the Shopping Cart.
                if (e.CommandName == "add")
                {
                    Label s = (Label)e.Item.FindControl("lblProductID");
                    int productId = int.Parse(s.Text);
                    Cart.cart.AddItem(productId);
                    
                }
            }
        }      
    }
