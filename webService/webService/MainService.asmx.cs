
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using webService.App_Code;

namespace webService
{
    /// <summary>
    /// Summary description for MainService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MainService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        #region UserRegion
        /// <summary>
        /// gets user from the database 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>MyUser object holding user data</returns>
        [WebMethod]
        public MyUser UserGet(int id)
        {
            return new MyUser(id);
        }

        /// <summary>
        /// adds new user to the database
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        [WebMethod]
        public int UserAdd(MyUser newUser)
        {
            return newUser.AddNew();
        }

        /// <summary>
        /// deletes the user from the database
        /// </summary>
        /// <param name="userToDelete"></param>
        /// <returns>return if the deletion was successful or not</returns>
        [WebMethod]
        public int UserDelete(MyUser userToDelete)
        {
            return userToDelete.Delete();
        }

        /// <summary>
        /// updates the current user within the database
        /// </summary>
        /// <param name="userToUpdate"></param>
        /// <returns>returns if the update was succcessful or not</returns>
        [WebMethod]
        public int UserUpdate(MyUser userToUpdate)
        {
            return userToUpdate.Update();
        }

        /// <summary>
        /// gets the user by email and password
        /// </summary>
        /// <param name="userEmail"> the user's email</param>
        /// <param name="userPassword">the user's password</param>
        /// <returns>user object representing the user with the given email and password</returns>
        [WebMethod]
        public MyUser GetUserByPersonalData(string userEmail, string userPassword)
        {
            return MyUser.GetUserByEmailPassword(userEmail, userPassword);
        }

        /// <summary>
        /// gets all the users
        /// </summary>
        /// <returns>a list of all the users in the database</returns>
        [WebMethod]
        public List<MyUser> GetAllUsers()
        {
            return MyUser.GetUsersList();
        }

        #endregion

        #region foodItems

        /// <summary>
        /// gets the food item from its item id
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns>FoodItem object holding food item data</returns>
        [WebMethod]
        public FoodItem FoodItemGet(int itemId)
        {
            return new FoodItem(itemId);
        }

        /// <summary>
        /// adds new food item to the database
        /// </summary>
        /// <param name="ItemToAdd"></param>
        /// <returns>return if the addition was successful or not, 1 - success, -1 not successful</returns>
        [WebMethod]
        public int FoodItemAdd(FoodItem ItemToAdd)
        {
            return ItemToAdd.AddNew();
        }

        /// <summary>
        /// updates the food item in the database
        /// </summary>
        /// <param name="itemToUpdate"></param>
        /// <returns>returns if the update was successful or not, 1 - success, -1 not successful</returns>
        [WebMethod]
        public int FoodItemUpdate(FoodItem itemToUpdate)
        {
            return itemToUpdate.Update();
        }

        /// <summary>
        /// deletes the food item from the database
        /// </summary>
        /// <param name="itemToDelete"></param>
        /// <returns>returns if the deletion was successful, 1 - successful, -1 not successful </returns>
        [WebMethod]
        public int FoodItemDelete(FoodItem itemToDelete)
        {
            return itemToDelete.Delete();
        }


        /// <summary>
        /// gets all the food items
        /// </summary>
        /// <returns> returns a list of all the food items </returns>
        [WebMethod]
        public List<FoodItem> GetAllFoodItems()
        {
            return FoodItem.GetItemsList();
        }

        /// <summary>
        /// get all the food items from a creator
        /// </summary>
        /// <param name="userId"></param>
        /// <returns> returns a list of food items from a certain creator</returns>
        [WebMethod]
        public List<FoodItem> GetFoodItemsOfCreator(int userId)
        {
            return FoodItem.GetItemByCreator(userId);
        }

        #endregion
    }
}
