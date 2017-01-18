using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_3
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check if this is the first time the user visits the page
            if (!IsPostBack)
            {
                //Bind the products to the gridview.
                gvProducts.DataSource = BindProducts();
                gvProducts.DataBind();
            }

            PanelInput.Visible = false;

            //we assign the user variable to the Session, if the user is an Admin, they stay on this page.
            //If not, they get redirected to the Welcome page.
            User user = (User)Session["user"];
            if (user is Admin)
            {
                int accessLevel = Convert.ToInt32(Session["UserLevel"]);

            }
            else
            {
                Response.Redirect("Default.aspx");
            }

        }

        /// <summary>
        /// This method connects to the database and returns back the products currently available.
        /// </summary>
        /// <returns></returns>
        private DataSet BindProducts()
        {
            //Create a connection object
            DAL_Project.DAL d = new DAL_Project.DAL(ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString);

            if (Session["SortColumn"] != null)
            {
                d.AddParam("SortColumn", Session["SortColumn"].ToString());
            }

            DataSet ds = d.ExecuteProcedure("spGetProductsOrdered");
            return ds;

        }

        /// <summary>
        /// Here in the RowCommand we set up our Delete and Edit buttons that are in the Gridview. If the Delete
        /// button is clicked, the corresponding Product is deleted off of the page and also out of the database.
        /// If the user clicks Edit, they are then able to edit the information on the screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "Sort")
            {

                gvProducts.SelectedIndex = Convert.ToInt32(e.CommandArgument.ToString());
                int productId = Convert.ToInt32(gvProducts.SelectedValue.ToString());

                if (e.CommandName == "Delete Product")
                {
                    DAL_Project.DAL d = new DAL_Project.DAL(ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString);
                    d.AddParam("@ProductId", gvProducts.SelectedValue.ToString());
                    DataSet ds = d.ExecuteProcedure("spDeleteProduct");
                   
                    gvProducts.DataSource = BindProducts();
                    gvProducts.DataBind();
                }
                else if (e.CommandName == "Edit Product")
                {
                    PanelInput.Visible = true;
                    txtName.Text = gvProducts.SelectedRow.Cells[3].Text;
                    txtDescription.Text = gvProducts.SelectedRow.Cells[4].Text;
                    txtPrice.Text = gvProducts.SelectedRow.Cells[5].Text;
                    txtCategoryID.Text = gvProducts.SelectedRow.Cells[7].Text;
                }
            }
        }

        /// <summary>
        /// This enables us to sort whatever column the user would like.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvProducts_Sorting(object sender, GridViewSortEventArgs e)
        {
            Session["SortColumn"] = e.SortExpression;
            gvProducts.DataSource = BindProducts();
            gvProducts.DataBind();
        }

        /// <summary>
        /// This enables us to change pages if the user clicks on the numbers at the bottom of the gridview.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProducts.DataSource = BindProducts();
            gvProducts.PageIndex = e.NewPageIndex;
            gvProducts.DataBind();
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            PanelInput.Visible = true;
            txtName.Text = "";
            txtDescription.Text = "";
            txtCategoryID.Text = "";
            txtPrice.Text = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string fileName = "";

            //Check if the file upload has a file
            if (uploadImage.HasFile)
            {
                //Get the file name from the file upload
                fileName = uploadImage.FileName;
            }

            //Using the DAL, pass in the appropriate parameters and use the stored procedure to update
            //the Product
            DAL_Project.DAL d = new DAL_Project.DAL(ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString);
            d.AddParam("@ProductId", gvProducts.SelectedValue.ToString());
            d.AddParam("@Name", txtName.Text);
            d.AddParam("@Desc", txtDescription.Text);
            d.AddParam("@Price", txtPrice.Text);
            d.AddParam("@CategoryId", txtCategoryID.Text);
            d.AddParam("@ImagePath", fileName);

            uploadImage.SaveAs(Server.MapPath(".") + fileName);

            DataSet ds = d.ExecuteProcedure("spUpdateProduct");

            //this shows a message to the user confirming the save was successful
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Save successful!');", true);

            gvProducts.DataSource = BindProducts();
            gvProducts.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string fileName = "";

            //Check if the file upload has a file
            if (uploadImage.HasFile)
            {
                //Get the file name from the file upload
                fileName = uploadImage.FileName;
            }

            //Using the DAL, pass in the appropriate parameters and use the stored procedure to add
            //the new Product
            DAL_Project.DAL d = new DAL_Project.DAL(ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString);
            d.AddParam("@Name", txtName.Text);
            d.AddParam("@Desc", txtDescription.Text);
            d.AddParam("@Price", txtPrice.Text);
            d.AddParam("@ImagePath", fileName);
            d.AddParam("@CategoryId", txtCategoryID.Text);

            DataSet ds = d.ExecuteProcedure("spAddProduct");

            uploadImage.SaveAs(Server.MapPath(".") + fileName);

            //this shows a message to the user confirming the new Product has been added.
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('New Product Added!');", true);

            gvProducts.DataSource = BindProducts();
            gvProducts.DataBind();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }
    }
}