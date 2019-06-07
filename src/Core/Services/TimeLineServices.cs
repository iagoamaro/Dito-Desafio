using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using src.Core.Models;

namespace src.Core.Services
{
    public class TimeLineServices : ITimeLineServices
    {

        private TimeLine JsonToObject(string json)
        {

            var obj = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            var timeLine = new TimeLine();
            foreach (var item in obj)
            {
                if (item.Key == nameof(timeLine.timestamp))
                {
                    timeLine.timestamp = DateTime.Parse(item.Value.ToString());
                }

                if (item.Key == nameof(timeLine.revenue))
                {
                    timeLine.revenue = double.Parse(item.Value.ToString());
                }
                if (item.Key == "custom_data")
                {
                    var custom = JsonConvert.DeserializeObject<Dictionary<string, object>>(item.Value.ToString());
                    foreach (var customdata in custom)
                    {
                        var products = new Products();
                        if (customdata.Key == "product_name")
                        {
                            products.name = customdata.Value.ToString();
                        }
                        if (customdata.Key == "product_price")
                        {
                            products.price = double.Parse(customdata.Value.ToString());
                        }
                        if (customdata.Key == "transaction_id")
                        {
                            timeLine.transaction_id = customdata.Value.ToString();
                        }
                    }
                }
            }
            return timeLine;
        }

        public async Task<TimeLine> GetTimeLine()
        {
            var request = WebRequest.CreateHttp("https://storage.googleapis.com/dito-questions/events.json");
            request.Method = WebRequestMethods.Http.Get;
            request.Accept = "application/json";
            var timeLine = new TimeLine();
            var json = "";
            using (var response = request.GetResponse())
            {
                var _response = response.GetResponseStream();
                StreamReader reader = new StreamReader(_response, Encoding.UTF8);
                json = JsonConvert.SerializeObject(reader.ReadToEnd());
            }


            return await Task.FromResult(JsonToObject(json));

        }
    }
}