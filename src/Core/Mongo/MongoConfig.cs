using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace dito.Core.Mongo
{
    public class MongoDatabaseConfiguration
    {
        private readonly IMongoDatabase db;
        private readonly List<string> collections;

        public MongoDatabaseConfiguration(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("Mongodb"));
            db = client.GetDatabase("db");
            collections = db.ListCollectionNames().ToList();
        }

        public void Configure()
        {
            ConfigureCollection(
                new CreateIndexModel<Models.Data>(Builders<Models.Data>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions
                {
                    Name = "DataId_1",
                    Unique = true
                })                
            );         
        }

        public void ConfigureCollection<T>(params CreateIndexModel<T>[] indexModels)
        {
            var collectionName = typeof(T).Name;
            if (!collections.Contains(collectionName))
            {
                db.CreateCollection(collectionName);
                collections.Add(collectionName);
            }

            var collection = db.GetCollection<T>(collectionName);
            foreach (var index in indexModels)
            {
                collection.Indexes.CreateOne(index);
            }
        }
    }
}