using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;

namespace webService.App_Code
{
    public class User : IDbAction
    {
        // define public user types
        public enum  RoleTypes
        {
            NormalUser,
            WorkerUser,
            AdminUser
        };


        // define get and setters
        public int UserId { get; set;}
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public Roles RoleTag { get; set; }
        public Orders OrderHistory { get; set; }

        // define constructors
        public User() { }
        public User(int id)
        {
            this.UserId = id;
            this.Init();
        }

        // inits the user from database data
        public int Init()
        {
            // create string query and execute it
            string query = string.Format("select * from users where userId={0}", this.UserId);
            DataSet usersTable = DbQ.ExecuteQuery(query);

            // check if there are users within the dataset
            if (usersTable.Tables[0].Rows.Count > 0)
            {
                int roleId = int.Parse(usersTable.Tables[0].Rows[0]["roleId"].ToString());

                this.UserName = usersTable.Tables[0].Rows[0]["userName"].ToString();
                this.UserEmail = usersTable.Tables[0].Rows[0]["userEmail"].ToString();
                this.UserPassword = usersTable.Tables[0].Rows[0]["userPassword"].ToString();
                this.RoleTag = new Roles(roleId);
                this.OrderHistory = new Orders(this.UserId);

                return 1;
            }

            // return -1 for no users
            return -1;
        }

        // add new user to the database
        public int AddNew()
        {
            string query = string.Format("insert into users (userName, userEmail, userPassword, roleId) values ('{0}','{1}','{2}','{3}')", this.UserName, this.UserEmail, this.UserPassword, this.RoleTag.RoleId.ToString());
            return DbQ.ExecuteNonQuery(query);
        }
        
        // updates user data in the database
        public int Update()
        {
            string query = string.Format("update users set userName='{0}' , userEmail='{1}' , userPassword='{2}', roleId='{3}' where userId={4};", this.UserName, this.UserEmail, this.UserPassword, this.RoleTag.RoleId.ToString(), this.UserId);
            return DbQ.ExecuteNonQuery(query);
        }
        
        // delete the user from the database
        public int Delete()
        {
            int orderDeleteResult = this.OrderHistory.Delete();

            // check if the orders were deleted properly
            if (orderDeleteResult == -1)
            {
                return -1;
            }

            string query = string.Format("delete from users where userId={0}", this.UserId);
            return DbQ.ExecuteNonQuery(query);
        }

        // get user by email and password
        public static User GetUserByEmailPassword(string userEmail, string userPassword)
        {
            // retrive user from database 
            string query = string.Format("select userId from users where userEmail='{0}' and userPassword='{1}'", userEmail, userPassword);
            DataSet userTable = DbQ.ExecuteQuery(query);

            if (userTable.Tables[0].Rows.Count > 0)
            {
                int newUserid = int.Parse(userTable.Tables[0].Rows[0]["userId"].ToString());
                return new User(newUserid);
            }
            return null;
        }

        // get a list of users
        public static List<User> GetUsersList()
        {
            List<User> userList = new List<User>();
            int newUserId = 0;
            int i = 0;
            int amountOfUsers = 0;

            // retrive the users from the database
            string query = string.Format("select userId from users ");
            DataSet usersTable = DbQ.ExecuteQuery(query);

            // if there are users
            amountOfUsers = usersTable.Tables[0].Rows.Count;
      
            for (i = 0; i < amountOfUsers; i++)
            {
                newUserId = int.Parse(usersTable.Tables[0].Rows[i]["userId"].ToString());
                userList.Add(new User(newUserId));
            }
            
            return userList;
        }

    }
}