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
        public int OrderId { get; set; }
        public List<OrderedItems> OrderList { get; set; }

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

        // methods
        public void AddOrder(ref OrderedItems order)
        {
            this.OrderList.Add(order);
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
                this.OrderList[i].OrderDate = Convert.ToDateTime(allOrders.Tables[0].Rows[i]["orderDate"]);
            }
            this.OrderId = orderId;

            return 1;
        }

        // adds new orders to the database
        public int AddNew()
        {
            int i = 0;
            string query = "";
            int rowsChanged = 0;
            bool hasOrderId = false;
            Orders ordersCopy;

            for (i = 0; i < this.OrderList.Count; i++)
            {
                this.OrderList[i].setTotalPrice();
                this.OrderList[i].OrderDate = DateTime.Now;
                query = string.Format("insert into orders (userId, orderDate, totalPrice) values ('{0}', '{1}', '{2}')", this.UserId, this.OrderList[i].OrderDate, this.OrderList[i].totalPrice);
                rowsChanged += DbQ.ExecuteNonQuery(query);

                // get the new order id
                if (!hasOrderId)
                {
                    ordersCopy = new Orders(this.UserId);
                    this.OrderId = ordersCopy.OrderId;
                    hasOrderId = true;
                }

                this.OrderList[i].OrderId = this.OrderId;
                this.OrderList[i].AddNew();
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
                this.OrderList[i].setTotalPrice();
                query = string.Format("update orders set orderId='{0}', orderDate='{3}', totalPrice='{2}' where userId={1};", this.OrderList[i].OrderId, this.UserId, this.OrderList[i].totalPrice, this.OrderList[i].OrderDate);
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

                query = string.Format("delete from orders where userId={0}",this.UserId);
                rowsChanged += DbQ.ExecuteNonQuery(query);
            }

            return rowsChanged;
        }
    }
}