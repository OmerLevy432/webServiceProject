using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;

namespace webService.App_Code
{
    /*
    unlike other classes who use the IDbAction interface
    who enforces the following method: Init, AddNew, Delete, Update
    im only interested in implementing the Init method 
    im not interested in a program changing the current values in the roles data base
    i want to limit the program to only access it
     */
    public class Roles
    {
        // define getters and setters
        public int RoleId { get; set; }
        public string RoleTag { get; set; }

        // constructors
        public Roles() { }
        public Roles(int roleId)
        {
            this.RoleId = roleId;
            this.Init();
        }
        public int Init()
        {
            // create string query and execute it
            string query = string.Format("select * from roles where roleId = {0}", this.RoleId);
            DataSet rolesTable = DbQ.ExecuteQuery(query);

            // check if there are items within the dataset
            if (rolesTable.Tables[0].Rows.Count > 0)
            {
                this.RoleTag = rolesTable.Tables[0].Rows[0]["roleTag"].ToString();
                return 1;
            }

            // return -1 for not finding a role by his id
            return -1;
        }
    }
}