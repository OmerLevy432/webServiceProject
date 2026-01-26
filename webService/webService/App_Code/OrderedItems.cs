using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;

namespace webService.App_Code
{
    public class OrderedItems : IDbAction
    {
        // define setters and getters
        public int OrderId { get;  set; }

        /*
         there is a seperate list for the items and their counts
         */
        public List<FoodItem> FoodItems { get; set; }
        public List<int> FoodAmounts { get; set; }
        public DateTime OrderDate { get; set; }

        // constructors
        public OrderedItems()
        {
            // initializing lists
            this.FoodItems = new List<FoodItem>();
            this.FoodAmounts = new List<int>();
        }
        public OrderedItems(int orderId) : this()
        {
            this.OrderId = orderId;
            this.Init();
        }

        // methods
        public void AddItem(FoodItem item, int amount)
        {
            this.FoodItems.Add(item);
            this.FoodAmounts.Add(amount);
        }

        // inits the ordered item from database data
        public int Init()
        {
            // create string query and execute it
            string query = string.Format("select * from orderedItems where orderId = {0}", this.OrderId);
            DataSet itemsOrderedTable = DbQ.ExecuteQuery(query);

            int amountOfitems = itemsOrderedTable.Tables[0].Rows.Count;
            int i = 0;
            int newItemId = 0;

            // adds all the items from a certain order to the object
            for (i = 0; i < amountOfitems; i++)
            {
                newItemId = int.Parse(itemsOrderedTable.Tables[0].Rows[i]["itemId"].ToString());
                this.FoodItems.Add(new FoodItem(newItemId));
                this.FoodAmounts.Add(int.Parse(itemsOrderedTable.Tables[0].Rows[i]["amount"].ToString()));
            }

            // gets the date of the order
            query = string.Format("select orderDate from orders where orderId = {0}", this.OrderId);
            DataSet orderDate = DbQ.ExecuteQuery(query);
            this.OrderDate = Convert.ToDateTime(orderDate.Tables[0].Rows[0]["orderDate"]);

            return 1;
        }

        // add new items to the database
        public int AddNew()
        {
            int i = 0;
            string query = "";
            int rowsChanged = 0;

            for (i = 0; i < this.FoodItems.Count; i++)
            {
                query = string.Format("insert into orderedItems (orderId, itemId, amount) values ('{0}', '{1}', '{2}')", this.OrderId, this.FoodItems[i].ItemId, this.FoodAmounts[i]);
                rowsChanged += DbQ.ExecuteNonQuery(query);
            }

            return rowsChanged;
        }

        // updates items data in the database
        public int Update()
        {
            int i = 0;
            string query = "";
            int rowsChanged = 0;

            for (i = 0; i < this.FoodItems.Count; i++)
            {
                query = string.Format("update orderedItems set itemId='{0}', amount='{1}' where orderId={2};", this.FoodItems[i].ItemId, this.FoodAmounts[i], this.OrderId);
                rowsChanged += DbQ.ExecuteNonQuery(query);
            }

            return rowsChanged;
        }

        // delete the item from the database
        public int Delete()
        {
            int i = 0;
            string query = "";
            int rowsChanged = 0;

            for (i = 0; i < this.FoodItems.Count; i++)
            {
                query = string.Format("delete from orderedItems where orderId={0} and itemId={1} and amount={2}", this.OrderId, this.FoodItems[i].ItemId, this.FoodAmounts[i]);
                rowsChanged += DbQ.ExecuteNonQuery(query);
            }

            return rowsChanged;
        }
    }
}