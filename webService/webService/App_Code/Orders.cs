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
        public int orderId { get; private set; }
        public int userId { get; set; }

    }
}