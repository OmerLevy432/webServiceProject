using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;

namespace webService.App_Code
{
    public class FoodItem : IDbAction
    {
        // define getters and setters
        public int itemId { get; }
        public double itemPrice { get; set; }
        public string itemDescription { get; set; }
        public int userId { get; set; }

        // constructors
        public FoodItem() { }
        public FoodItem(int itemId)
        {
            this.itemId = itemId;
            this.Init();
        }
        public FoodItem(FoodItem other)
        {
            this.itemId = other.itemId;
            this.itemPrice = other.itemPrice;
            this.itemDescription = other.itemDescription;
            this.userId = other.userId;
        }

        // inits the food item from database data
        public int Init()
        {
            // create string query and execute it
            string query = string.Format("select * from foodItems where itemId={0}", this.itemId);
            DataSet itemsTable = DbQ.ExecuteQuery(query);

            // check if there are items within the dataset
            if (itemsTable.Tables[0].Rows.Count > 0)
            {
                this.itemDescription = itemsTable.Tables[0].Rows[0]["itemDescription"].ToString();
                this.itemPrice = double.Parse(itemsTable.Tables[0].Rows[0]["itemPrice"].ToString());
                this.userId = int.Parse(itemsTable.Tables[0].Rows[0]["userId"].ToString());

                return 1;
            }

            // return -1 for no items
            return -1;
        }

        // add new item to the database
        public int AddNew()
        {
            string query = string.Format("insert into foodItems (itemPrice, itemDescription, userId) values ('{0}','{1}','{2}')", this.itemPrice, this.itemDescription, this.userId);
            return DbQ.ExecuteNonQuery(query);
        }

        // upadates item data in the database
        public int Update()
        {
            string query = string.Format("update foodItems set itemPrice='{0}' , itemDescription='{1}' , userId='{2}' where itemId={4};", this.itemPrice, this.itemDescription, this.userId, this.itemId);
            return DbQ.ExecuteNonQuery(query);
        }

        // delete the item from the database
        public int Delete()
        {
            string query = string.Format("delete from items where itemId={0}", this.itemId);
            return DbQ.ExecuteNonQuery(query);
        }

        // get item by its creator
        public static List<FoodItem> GetItemByCreator(int userId)
        {
            // retrive item from database 
            string query = string.Format("select userId from foodItems userId='{0}'", userId);
            DataSet itemsTable = DbQ.ExecuteQuery(query);

            List<FoodItem> foodItemList = new List<FoodItem>();
            int amountOfItems= itemsTable.Tables[0].Rows.Count;
            int i = 0;
            
            for (i = 0; i < amountOfItems; i++)
            {
                int newItemId = int.Parse(itemsTable.Tables[0].Rows[i]["userid"].ToString());
                foodItemList.Add(new FoodItem(newItemId));
            }
            return foodItemList;
        }

        // get a list of items
        public static List<FoodItem> GetItemsList()
        {
            List<FoodItem> foodItemList = new List<FoodItem>();
            int newItemId = 0;
            int i = 0;
            int amountOfItems = 0;

            // retrive the users from the database
            string query = string.Format("select userId from foodItems");
            DataSet itemsTable = DbQ.ExecuteQuery(query);

            // if there are users
            amountOfItems = itemsTable.Tables[0].Rows.Count;

            for (i = 0; i < amountOfItems; i++)
            {
                newItemId = int.Parse(itemsTable.Tables[0].Rows[i]["userId"].ToString());
                foodItemList.Add(new FoodItem(newItemId));
            }

            return foodItemList;
        }

    }
}