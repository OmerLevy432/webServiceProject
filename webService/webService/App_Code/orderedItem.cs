using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;

namespace webService.App_Code
{
    public class orderedItem :  IDbAction
    {
        // define setters and getters
        public int orderId { get; private set; }
        public FoodItem item 
        {
            get
            {
                return new FoodItem(this.item);
            }
            private set { }
        }
        public int amount { get; set; }

        // constructors
        public orderedItem() { }
        public orderedItem(int orderId)
        {
            this.orderId = orderId;
            this.Init();
        }

        // inits the ordered item from database data
        public int Init()
        {
            // create string query and execute it
            string query = string.Format("select * from orderedItems where orderId = {0}", this.orderId);
            DataSet itemsOrderedTable = DbQ.ExecuteQuery(query);

            // check if there are items within the dataset
            if (itemsOrderedTable.Tables[0].Rows.Count > 0)
            {
                int newItemId = int.Parse(itemsOrderedTable.Tables[0].Rows[0]["itemId"].ToString());
                this.item = new FoodItem(newItemId);
                this.amount = int.Parse(itemsOrderedTable.Tables[0].Rows[0]["amount"].ToString());

                return 1;
            }

            // return -1 for no items
            return -1;
        }

        // add new item to the database
        public int AddNew()
        {
            string query = string.Format("insert into orderedItems (prderId, itemId, amount) values ('{0}', '{1}', '{2}')", this.orderId, this.item.itemId, this.amount);
            return DbQ.ExecuteNonQuery(query);
        }

        // upadates item data in the database
        public int Update()
        {
            string query = string.Format("update orderedItems set itemId='{0}' , amount'{1}' where orderId={2};", this.item.itemId, this.amount, this.orderId);
            return DbQ.ExecuteNonQuery(query);
        }

        // delete the item from the database
        public int Delete()
        {
            string query = string.Format("delete from orderedItems where orderId={0} and itemId={1} and amount={2}", this.orderId, this.item.itemId, this.amount);
            return DbQ.ExecuteNonQuery(query);
        }
    }
}