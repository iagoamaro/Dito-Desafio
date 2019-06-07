using System;
using MongoDB.Bson;

namespace dito.Core.Models
{
    public class Data
    {
        public ObjectId id { get; set; }
        public string eventName { get; set; }
        public DateTime timestamp { get; set; }
    }
}