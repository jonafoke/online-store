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
    public partial class WebForm7 : System.Web.UI.Page
    {
        User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshCart();
            }

            // ASSIGN THE CLASS VARIABLE
            user = (User)Session["user"];

            // IF IT'S NOT NULL THEY ARE LOGGED IN, ELSE THEY ARE NOT LOGGED IN
            if (user != null)
            {
                PanelInput.Visible = false;
            }
            else
            {
                PanelInput.Visible = true;
            }
        }

        /// <summary>
        /// Refreshes the Shopping Cart
        /// </summary>
        protected void RefreshCart()
        {
            gvCart.DataSource = Cart.cart.Items;
            gvCart.DataBind();
        }

        /// <summary>
        /// This uses the remove linkbutton on the gridview. If clicked, the Product will be removed 
        /// from the Shopping Cart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvCart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                int productId = Convert.ToInt32(e.CommandArgument);
                Cart.cart.RemoveItem(productId);
                RefreshCart();
            }
        }

        /// <summary>
        /// Shows the total the user will be spending
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvCart_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[4].Text = "Total " + Cart.cart.GetSubTotal().ToString("C");
            }
        }

        /// <summary>
        ///If the User wishes to change quantities of products, they can put the new quantity in the 
        ///textbox and click update. The new total for the row and a new grand total will be shown. If 
        ///they put a 0 and click then that deletes the product from the Shopping Cart.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvCart.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    try
                    {
                        int productId = Convert.ToInt32(gvCart.DataKeys[row.RowIndex].Value);
                        int quantity = int.Parse(((TextBox)row.Cells[3].FindControl("txtQuantity")).Text);

                        Cart.cart.SetItemQuantity(productId, quantity);
                    }
                    catch (FormatException) { }
                }


                RefreshCart();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // ASSIGN THE CURRENT LOGGED IN CUSTOMER, HOPEFULLY THIS WAS ASSIGNED AT LOG IN!
            int customerId;

            if (user == null)
            {
                // IF THEY WERE NOT LOGGED IN, WE CAN RUN THIS METHOD. This creates the new customer.
                customerId = CreateCustomer();

                // ALL ORDER AND ORDER DETAILS ARE HANDLED IN THIS METHOD. Once these are done and the full
                //order is complete, their session is ended and they are taken to the Thank You page.
                Cart.cart.CreateOrder(customerId);
                Cart.cart.Items.Clear();
                Session.Abandon();
                Response.Redirect("ThankYou.aspx");
                
            }
            else
            {
                customerId = user.custId;
                // ALL ORDER AND ORDER DETAILS ARE HANDLED IN THIS METHOD for logged in customers. Once these 
                //are done and the full order is complete, their session is ended and they are taken to the Thank You page.
                Cart.cart.CreateOrder(customerId);
                Cart.cart.Items.Clear();
                Session.Abandon();
                Response.Redirect("ThankYou.aspx");
            }
        }

        //Creates a new customer, and inserts them into the database.
        public int CreateCustomer()
        {
            DAL_Project.DAL d = new DAL_Project.DAL(ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString);

            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string address = txtAddress.Text;
            string cityProv = txtCityProv.Text;
            string postal = txtPostal.Text;

            d.AddParam("firstName", firstName);
            d.AddParam("lastName", lastName);
            d.AddParam("addr", address);
            d.AddParam("cityProv", cityProv);
            d.AddParam("postal", postal);

            DataSet ds = d.ExecuteProcedure("spAddCustomer");

            return Convert.ToInt32(ds.Tables[0].Rows[0]["CustomerID"]);
            
        }
    }
}