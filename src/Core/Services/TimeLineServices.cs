using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using src.Core.Models;
using src.DTO;
using System.Linq;

namespace src.Core.Services
{
    public class TimeLineServices : ITimeLineServices
    {

        private TimeLine JsonToObject(ListTimeLineDto timeLineDto)
        {
            var data = new TimeLine();
            foreach (var time in timeLineDto.events)
            {

                var events = new TimeLineEvent();
                var productName = "";
                var productPrice = "";
                foreach (var item in time.custom_data)
                {

                    events.revenue = time.revenue;
                    events.timestamp = time.timestamp;
                    if (item.key == "transaction_id")
                    {
                        events.transaction_id = item.value;
                    }
                    if (item.key == "store_name")
                    {
                        events.store_name = item.value;
                    }
                    if (item.key == "product_name")
                    {
                        productName = item.value;
                    }
                    if (item.key == "product_price")
                    {
                        productPrice = item.value.ToString();

                    }

                    if (!string.IsNullOrEmpty(productName) && !string.IsNullOrEmpty(productPrice))
                    {
                        var product = new Products(productName, double.Parse(productPrice));
                        events.products.Add(product);
                    }


                }
                data.timeline.Add(events);

            }

            data.timeline = data.timeline.OrderByDescending(x => x.timestamp).ThenBy(t => t.timestamp.TimeOfDay).ToList();
            return data;
        }


        public async Task<TimeLine> GetTimeLine()
        {

            var client = new HttpClient();
            var response = await client.GetStringAsync("https://storage.googleapis.com/dito-questions/events.json");
            var timeLineDto = JsonConvert.DeserializeObject<ListTimeLineDto>(response);
            return await Task.FromResult(JsonToObject(timeLineDto));

        }
    }
}