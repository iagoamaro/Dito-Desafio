using System;
using System.Collections.Generic;

namespace src.Core.Models
{
    public class TimeLine
    {
        public TimeLine()
        {
            timeline = new List<TimeLineEvent>();
        }
        public IList<TimeLineEvent> timeline { get; set; }
    }
    public class TimeLineEvent
    {
        public TimeLineEvent()
        {

            products = new List<Products>();
        }
        public DateTime timestamp { get; set; }
        public double revenue { get; set; }
        public string transaction_id { get; set; }
        public string store_name { get; set; }
        public IList<Products> products { get; set; }

    }

    public class Products
    {
        public Products(string _name, double _price)
        {
            name = _name;
            price = _price;
        }
        public string name { get; set; }
        public double price { get; set; }

    }
}