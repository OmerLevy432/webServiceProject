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
        public int ItemId { get; set; }
        public double ItemPrice { get; set; }
        public string ItemDescription { get; set; }
        public int UserId { get; set; }

        // constructors
        public FoodItem() { }
        public FoodItem(int itemId)
        {
            this.ItemId = itemId;
            this.Init();
        }
        public FoodItem(FoodItem other)
        {
            this.ItemId = other.ItemId;
            this.ItemPrice = other.ItemPrice;
            this.ItemDescription = other.ItemDescription;
            this.UserId = other.UserId;
        }

        // 
        /// <summary>
        /// inits the food item from database data
        /// </summary>
        /// <returns> 1 - if the retrival was successful, else it returns -1 </returns>
        public int Init()
        {
            // create string query and execute it
            string query = string.Format("select * from foodItems where itemId={0}", this.ItemId);
            DataSet itemsTable = DbQ.ExecuteQuery(query);

            // check if there are items within the dataset
            if (itemsTable.Tables[0].Rows.Count > 0)
            {
                this.ItemDescription = itemsTable.Tables[0].Rows[0]["itemDescription"].ToString();
                this.ItemPrice = double.Parse(itemsTable.Tables[0].Rows[0]["itemPrice"].ToString());
                this.UserId = int.Parse(itemsTable.Tables[0].Rows[0]["userId"].ToString());

                return 1;
            }

            // return -1 for no items
            return -1;
        }

        /// <summary>
        /// add new food item to the database 
        /// </summary>
        /// <returns>returns if the insertion was successful</returns>
        public int AddNew()
        {
            string query = string.Format("insert into foodItems (itemPrice, itemDescription, userId) values ('{0}','{1}','{2}')", this.ItemPrice, this.ItemDescription, this.UserId);
            return DbQ.ExecuteNonQuery(query);
        }

        /// <summary>
        /// updates item data in the database 
        /// </summary>
        /// <returns>returns if the update was successful</returns>
        public int Update()
        {
            string query = string.Format("update foodItems set itemPrice='{0}' , itemDescription='{1}' , userId='{2}' where itemId={3};", this.ItemPrice, this.ItemDescription, this.UserId, this.ItemId);
            return DbQ.ExecuteNonQuery(query);
        }

        /// <summary>
        /// delete the food item from the database
        /// </summary>
        /// <returns>if the deletion was successful</returns>
        public int Delete()
        {
            string query = string.Format("delete from foodItems where itemId={0}", this.ItemId);
            return DbQ.ExecuteNonQuery(query);
        }

        /// <summary>
        /// get food items by its creator
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>a list of the food items from the creator</returns>
        public static List<FoodItem> GetItemByCreator(int userId)
        {
            // retrive food items from database 
            string query = string.Format("select * from foodItems where userId={0}", userId);
            DataSet itemsTable = DbQ.ExecuteQuery(query);

            List<FoodItem> foodItemList = new List<FoodItem>();
            int amountOfItems= itemsTable.Tables[0].Rows.Count;
            int i = 0;
            int newItemId = 0;
            
            for (i = 0; i < amountOfItems; i++)
            {
                newItemId = int.Parse(itemsTable.Tables[0].Rows[i]["itemId"].ToString());
                foodItemList.Add(new FoodItem(newItemId));
            }
            return foodItemList;
        }

        /// <summary>
        /// get a list of food items
        /// </summary>
        /// <returns>list of all the food items</returns>
        public static List<FoodItem> GetItemsList()
        {
            List<FoodItem> foodItemList = new List<FoodItem>();
            FoodItem currentItem;
            int newItemId = 0;
            int i = 0;
            int amountOfItems = 0;

            // retrive the food items from the database
            string query = string.Format("select * from foodItems");
            DataSet itemsTable = DbQ.ExecuteQuery(query);


            amountOfItems = itemsTable.Tables[0].Rows.Count;
            for (i = 0; i < amountOfItems; i++)
            {
                newItemId = int.Parse(itemsTable.Tables[0].Rows[i]["itemId"].ToString());
                currentItem = new FoodItem(newItemId);  
                foodItemList.Add(currentItem);
            }

            return foodItemList;
        }

    }
}