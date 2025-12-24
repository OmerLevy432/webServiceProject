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
    public class Roles : IDbAction
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
        public int AddNew()
        {
            string query = string.Format("insert into roles (roleId, roleTag) values ('{0}','{1}')", this.RoleId, this.RoleTag);
            return DbQ.ExecuteNonQuery(query);
        }

        public int Update()
        {
            string query = string.Format("update roles set roleTag='{1}' where roleId={0};", this.RoleId, this.RoleTag);
            return DbQ.ExecuteNonQuery(query);
        }
        public int Delete()
        {
            string query = string.Format("delete from roles where roleId={0}", this.RoleId);
            return DbQ.ExecuteNonQuery(query);
        }

        public static List<Roles> GetRoles()
        {
            int amountOfRoles = 0;
            int i = 0;
            int newRoleId = 0;
            string query = string.Format("select roleId from roles");
            DataSet rolesTable = DbQ.ExecuteQuery(query);
            List<Roles> roles = new List<Roles>();

            // if there are roles
            amountOfRoles = rolesTable.Tables[0].Rows.Count;

            for (i = 0; i < amountOfRoles; i++)
            {
                newRoleId = int.Parse(rolesTable.Tables[0].Rows[i]["roleId"].ToString());
                roles.Add(new Roles(newRoleId));
            }

            return roles;
        }

        public static Roles GetRoleById(int roleId)
        {
            return new Roles(roleId);
        }
    }
}