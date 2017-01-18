using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Assignment_3
{
    public class Cart
    {
        public List<CartItem> Items { get; private set; }
        public static readonly Cart cart;

        /// <summary>
        /// this lets us only ever have one session at a time while in use by a user.
        /// </summary>
        static Cart()
        {
            if (HttpContext.Current.Session["Assignment-3"] == null)
            {
                cart = new Cart();
                cart.Items = new List<CartItem>();
                HttpContext.Current.Session["Assignment-3"] = cart;
            }
            else
            {
                cart = (Cart)HttpContext.Current.Session["Assignment-3"];
            }
        }

        protected Cart(){}

        /// <summary>
        /// Adds a new item to the Shopping Cart
        /// </summary>
        /// <param name="productId"></param>
        public void AddItem(int productId)
        {
            CartItem newItem = new CartItem(productId);

            if (Items.Contains(newItem))
            {
                foreach (CartItem item in Items)
                {
                    if (item.Equals(newItem))
                    {
                        item.quantity++;
                        return;
                    }
                }
            }
            else
            {
                newItem.quantity = 1;
                Items.Add(newItem);
            }
        }

        /// <summary>
        /// sets a new item quantity in the Shopping Cart if a user is changing a quantity
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        public void SetItemQuantity(int productId, int quantity)
        {
            
            if (quantity == 0)
            {
                RemoveItem(productId);
            }

            CartItem updatedItem = new CartItem(productId);

            foreach (CartItem item in Items)
            {
                if (item.Equals(updatedItem))
                {
                    item.quantity = quantity;
                    return;
                }
            }
        }

        /// <summary>
        /// Removes an item from the Shopping Cart if the user changes his/her mind.
        /// </summary>
        /// <param name="productId"></param>
        public void RemoveItem(int productId)
        {
            CartItem removedItem = new CartItem(productId);
            Items.Remove(removedItem);
        }

        /// <summary>
        /// Gives the user their sub total before they submit the order.
        /// </summary>
        /// <returns></returns>
        public decimal GetSubTotal()
        {
            decimal subTotal = 0;
            foreach (CartItem item in Items)
            {
                subTotal += item.TotalPrice;
            }
            return subTotal;
        }

        /// <summary>
        /// Connects to the database and creates the new order. Once the order is created, calls the 
        /// CartItem class to create the order details.
        /// </summary>
        /// <param name="customerId"></param>
        public void CreateOrder(int customerId)
        {
            DAL_Project.DAL d = new DAL_Project.DAL(ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString);
            DateTime date = DateTime.Now;

            d.AddParam("Date", date.Date);
            d.AddParam("CustomerID", customerId);

            DataSet ds = d.ExecuteProcedure("spAddOrder");
            
            int orderId = Convert.ToInt32(ds.Tables[0].Rows[0]["OrderID"]);

            foreach (CartItem item in Items)
            {
                item.CreateOrderDetail(orderId);
            }
        }
            
        }
    }
