using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;

namespace webService.App_Code
{
    public class Orders: IDbAction
    {
        // define getters and setters
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderedItems> OrderList { get; private set; }

        // define constructors
        public Orders()
        { 
            this.OrderList = new List<OrderedItems>();
        }
        public Orders(int userId) : this()
        {
            this.UserId = userId;
            this.Init();
        }

        // inits all the orders
        public int Init()
        {
            // create string query and execute it
            string query = string.Format("select * from orders where userId = {0}", this.UserId);
            DataSet allOrders = DbQ.ExecuteQuery(query);

            int amountOfOrders = allOrders.Tables[0].Rows.Count;
            int i = 0;
            int orderId = 0;

            // adds all the orders to the list
            for (i = 0; i < amountOfOrders; i++)
            {
                orderId = int.Parse(allOrders.Tables[0].Rows[i]["orderId"].ToString());
                this.OrderList.Add(new OrderedItems(orderId));
                this.OrderDate = Convert.ToDateTime(allOrders.Tables[0].Rows[i]["orderDate"]);
            }

            return 1;
        }

        // adds new orders to the database
        public int AddNew()
        {
            int i = 0;
            string query = "";
            int rowsChanged = 0;

            for (i = 0; i < this.OrderList.Count; i++)
            {
                query = string.Format("insert into orders (orderId, userId, orderDate) values ('{0}', '{1}', '{2}')", this.OrderList[i].OrderId, this.UserId, this.OrderDate);
                rowsChanged += DbQ.ExecuteNonQuery(query);
            }

            return rowsChanged;
        }

        // updates the user's orders in the database
        public int Update()
        {
            int i = 0;
            string query = "";
            int rowsChanged = 0;

            for (i = 0; i < this.OrderList.Count; i++)
            {
                query = string.Format("update orders set orderId='{0}', userId='{1}' where orderDate={2};", this.OrderList[i].OrderId, this.UserId, this.OrderDate);
                rowsChanged += DbQ.ExecuteNonQuery(query);
            }

            return rowsChanged;
        }

        // delete the orders from the database
        public int Delete()
        {
            int i = 0;
            string query = "";
            int rowsChanged = 0;

            for (i = 0; i < this.OrderList.Count; i++)
            {
                this.OrderList[i].Delete();

                query = string.Format("delete from orders where orderId={0} and userId={1} and orderDate={2}", this.OrderList[i].OrderId, this.UserId, this.OrderDate);
                rowsChanged += DbQ.ExecuteNonQuery(query);
            }

            return rowsChanged;
        }
    }
}