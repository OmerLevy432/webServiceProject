using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace webService.App_Code
{
    public class User :tableObjectInterface
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string userEmail { get; set; }
    }
}