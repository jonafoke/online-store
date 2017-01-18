using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment_3
{
    class Admin : User
    {
        public Admin(int userId, int accessLevel)
            : base(userId,accessLevel)
        {
            // Calls the parent class's constructor
        }
    }
}
