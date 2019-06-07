using System;
using MongoDB.Bson;

namespace dito.Core.Models
{
    public class Data
    {
        public ObjectId Id { get; set; }
        public string Event { get; set; }
        public DateTime MyProperty { get; set; }
    }
}