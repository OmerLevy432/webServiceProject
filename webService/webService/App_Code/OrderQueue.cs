using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webService.App_Code
{
    public class OrderQueue
    {
        public List<Orders> queue { get; set; }

        // constructor
        public OrderQueue()
        {
            this.queue = new List<Orders>();
        }

        // methods
        public void AddOrderToQueue(Orders orders)
        {
            this.queue.Add(orders);
        }

        public Orders RemoveOrderFromQueue()
        {
            int amountOfOrders = this.queue.Count;
            int orderIndex = amountOfOrders - 1;

            /* get the order to remove and remove it*/
            Orders removedOrder = this.queue[orderIndex];
            this.queue.RemoveAt(orderIndex);

            return removedOrder;
        }
    }
}