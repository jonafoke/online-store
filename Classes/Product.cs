using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Assignment_3
{
    public class Product
    {
        //PROPERTIES
        public int ProductId { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        //CONSTRUCTOR
        public Product(int productId)
        {
            //Calls the database and gets all of the information of the Products
            DAL_Project.DAL d = new DAL_Project.DAL(ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString);
            d.AddParam("@ProductId", productId);
            DataSet ds = d.ExecuteProcedure("spGetProducts");

            if (ds.Tables[0].Rows.Count > 0)
            {
                ProductId = (int)ds.Tables[0].Rows[0]["ProductId"];
                ItemName = ds.Tables[0].Rows[0]["Name"].ToString();
                Price = (decimal)ds.Tables[0].Rows[0]["Price"];
                Description = ds.Tables[0].Rows[0]["Description"].ToString();
            }
            else
            {
                throw new Exception(String.Format("ERROR!  No Product ID found for productId {0}", productId));
            }
        }
    }
}