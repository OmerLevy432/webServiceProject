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
        // define get and setters
        public int userId { get; }
        public string userName { get; set; }
        public string userEmail { get; set; }
        public string userPassword { get; set; }
        public int roleId { get; set; }

        // define constructors
        public User() { }
        public User(int id)
        {
            this.userId = id;
            this.Init();
        }

        // inits the user from database data
        public int Init()
        {
            // create string query and execute it
            string query = string.Format("select * from users where userId={0}", this.userId);
            DataSet usersTable = DbQ.ExecuteQuery(query);

            // check if there are users within the dataset
            if (usersTable.Tables[0].Rows.Count > 0)
            {
                this.userName = usersTable.Tables[0].Rows[0]["userName"].ToString();
                this.userEmail = usersTable.Tables[0].Rows[0]["userEmail"].ToString();
                this.userPassword = usersTable.Tables[0].Rows[0]["userPassword"].ToString();
                this.roleId = int.Parse(usersTable.Tables[0].Rows[0]["roleId"].ToString());

                return 1;
            }

            // return -1 for no users
            return -1;
        }

        // add new user to the database
        public int AddNew()
        {
            string query = string.Format("insert into users (userName, userEmail,, userPassword, roleId) values ('{0}','{1}','{2}','{3}')", this.userName, this.userEmail, this.userPassword, this.roleId);
            return DbQ.ExecuteNonQuery(query);
        }
        
        // upadates user data in the database
        public int Update()
        {
            string query = string.Format("update users set userName='{0}' , userEmail='{1}' , userPassword='{2}', roleId='{3}' where userId={4};", this.userName, this.userEmail, this.userPassword, this.roleId, this.userId);
            return DbQ.ExecuteNonQuery(query);
        }
        
        // delete the user from the database
        public int Delete()
        {
            string query = string.Format("delete from user where userId={0}", this.userId);
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
                int newUserid = int.Parse(userTable.Tables[0].Rows[0]["userid"].ToString());
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