using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace Assignment_3
{
    class User
    {
        //PROPERTIES
        public int UserId { get; set; }

        public string userName { get; set; }

        public int accessLevel { get; set; }

        public int custId { get; set; }

        //CONSTRUCTORS
        public User(int UserID, int accessLevel)
        {
            //Calls the database and gets the user's information
            DAL_Project.DAL d = new DAL_Project.DAL(ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString);
            d.AddParam("@UserId", UserID);
            DataSet ds = d.ExecuteProcedure("spGetUsers");

            if (ds.Tables[0].Rows.Count > 0)
            {
                UserId = (int)ds.Tables[0].Rows[0]["UserID"];
                userName = ds.Tables[0].Rows[0]["UserName"].ToString();
                accessLevel = (int)ds.Tables[0].Rows[0]["AccessLevel"];
                custId = (int)ds.Tables[0].Rows[0]["CustomerID"];
            }
            else
            {
                throw new Exception(String.Format("ERROR!  No User ID found for UserID {0}", UserID));
            }
        }

        public User() { }
        
    }
}
