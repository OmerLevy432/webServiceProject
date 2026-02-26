using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace webService.App_Code
{
    [XmlRoot("OrdersXmlWrapper")]
    public class OrdersXmlWrapper
    {
        #region Private Fields & Configuration

        // Safely gets the physical path to your App_Data folder using an expression body
        private static string FilePath => HttpContext.Current.Server.MapPath("~/App_Data/ordersFile.xml");

        #endregion

        #region Public Properties

        [XmlElement("WrapperId")]
        public int WrapperId { get; set; }

        [XmlElement("IsReady")]
        public bool IsReady { get; set; }

        [XmlElement("OrderData")]
        public Orders OrderData { get; set; }

        #endregion

        #region Constructors

        // Parameterless constructor is strictly required for XmlSerializer
        public OrdersXmlWrapper() { }

        public OrdersXmlWrapper(Orders order, bool isReady)
        {
            this.OrderData = order;
            this.IsReady = isReady;
        }

        #endregion

        #region Public Queue & Data Methods

        /// <summary>
        /// Adds a new order to the XML file, automatically assigning it the next available WrapperId.
        /// </summary>
        public static void Enqueue(Orders order, bool isReady)
        {
            List<OrdersXmlWrapper> allOrders = LoadAllFromXml();

            int nextId = allOrders.Count > 0 ? allOrders.Max(o => o.WrapperId) + 1 : 1;

            OrdersXmlWrapper newWrapper = new OrdersXmlWrapper(order, isReady)
            {
                WrapperId = nextId
            };

            allOrders.Add(newWrapper);
            SaveAllToXml(allOrders);
        }

        /// <summary>
        /// Finds the oldest order with the requested status, removes it from the XML file, and returns it.
        /// </summary>
        public static OrdersXmlWrapper DequeueByReadyStatus(bool isReadyStatus)
        {
            List<OrdersXmlWrapper> allOrders = LoadAllFromXml();

            OrdersXmlWrapper itemToDequeue = allOrders
                .Where(o => o.IsReady == isReadyStatus)
                .OrderBy(o => o.WrapperId)
                .FirstOrDefault();

            if (itemToDequeue != null)
            {
                allOrders.Remove(itemToDequeue);
                SaveAllToXml(allOrders);
            }

            return itemToDequeue;
        }

        /// <summary>
        /// Finds the oldest 'false' order, changes its tag to 'true', saves the file, and returns the Orders object.
        /// </summary>
        public static Orders MarkNextOrderAsReady()
        {
            List<OrdersXmlWrapper> allOrders = LoadAllFromXml();

            OrdersXmlWrapper orderToUpdate = allOrders
                .Where(o => o.IsReady == false)
                .OrderBy(o => o.WrapperId)
                .FirstOrDefault();

            if (orderToUpdate != null)
            {
                orderToUpdate.IsReady = true;
                SaveAllToXml(allOrders);
                return orderToUpdate.OrderData;
            }

            return null;
        }

        /// <summary>
        /// Returns a raw list of Orders objects based on the requested ready status.
        /// </summary>
        public static List<Orders> GetAllOrdersDataByStatus(bool isReadyStatus)
        {
            return LoadAllFromXml()
                .Where(o => o.IsReady == isReadyStatus)
                .Select(o => o.OrderData)
                .ToList();
        }

        /// <summary>
        /// Returns a list of the full wrapper objects based on the requested ready status.
        /// </summary>
        public static List<OrdersXmlWrapper> GetOrdersByReadyStatus(bool isReadyStatus)
        {
            return LoadAllFromXml()
                .Where(o => o.IsReady == isReadyStatus)
                .ToList();
        }

        #endregion

        #region Private XML File Helpers

        private static void SaveAllToXml(List<OrdersXmlWrapper> ordersList)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<OrdersXmlWrapper>));
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                serializer.Serialize(writer, ordersList);
            }
        }

        private static List<OrdersXmlWrapper> LoadAllFromXml()
        {
            if (!File.Exists(FilePath))
            {
                return new List<OrdersXmlWrapper>();
            }

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<OrdersXmlWrapper>));
                using (StreamReader reader = new StreamReader(FilePath))
                {
                    return (List<OrdersXmlWrapper>)serializer.Deserialize(reader) ?? new List<OrdersXmlWrapper>();
                }
            }
            catch
            {
                // Returns an empty list if the file is corrupted or completely empty
                return new List<OrdersXmlWrapper>();
            }
        }

        #endregion
    }
}