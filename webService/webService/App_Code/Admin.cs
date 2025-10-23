using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webService.App_Code
{
    public class Admin : User
    {
        // constructor
        public Admin(int userId) : base(userId) 
        {
            if (!checkAdmin())
            {
                
            }
        }

        private bool checkAdmin()
        {
            return (User.RoleTypes)this.RoleTag.RoleId == User.RoleTypes.NormalUser;
        }
    }
    
}