using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoesShop1.Common
{
    [Serializable]
    public class AdminLogin
    {
        public int adminID { set; get; }
        public string adminName { set; get; }
    }
}