using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Assignment_3
{
    public class CartItem : IEquatable<CartItem>
    {
        public int quantity { get; set; }

        public Product product { get; private set; }

        public int ProductID
        {
            get { return product.ProductId; }
        }

        public decimal Price
        {
            get { return product.Price; }
        }

        public decimal TotalPrice
        {
            get { return Price * quantity; }
        }
              
        public string Description
        {
            get { return product.Description; }
        }

        public string Name
        {
            get { return product.ItemName; }
        }

        public CartItem(int productId)
        {
            product = new Product(productId);
        }

        public bool Equals(CartItem shoppingItem)
        {
            return shoppingItem.product.ProductId == product.ProductId;
        }

        /// <summary>
        /// Calls the database and inserts new order details based on the order submitted.
        /// </summary>
        /// <param name="orderId"></param>
        internal void CreateOrderDetail(int orderId)
        {
            DAL_Project.DAL d = new DAL_Project.DAL(ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString);
            d.AddParam("OrderID", orderId);
            d.AddParam("ProductID", ProductID);
            d.AddParam("Quantity", quantity);
            d.AddParam("TotalPrice", TotalPrice);
            d.ExecuteProcedure("spAddOrderDetail");
        }
    }
}