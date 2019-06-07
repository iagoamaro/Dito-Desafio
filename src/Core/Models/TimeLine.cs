using System;
using System.Collections.Generic;

namespace src.Core.Models
{
    public class TimeLine
    {
        public TimeLine()
        {
            products = new List<Products>();
        }
        public DateTime timestamp { get; set; }
        public double revenue { get; set; }
        public string transaction_id { get; set; }
        public string store_name { get; set; }
        public IList<Products> products { get; set; }

    }

    public class Products{
        public string name { get; set; }
        public double price { get; set; }

    }
}