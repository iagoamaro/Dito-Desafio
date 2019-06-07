using dito.Core.Models;
using MongoDB.Driver;

namespace src.Core.Mongo
{
    public class DitoContext : IDitoContext
    {
        private readonly IMongoDatabase _db;
        public DitoContext(MongoConfig mongoConfiig)
        {
            var client = new MongoClient(mongoConfiig.ConnectionString);
            _db = client.GetDatabase(mongoConfiig.Database);
        }
        public IMongoCollection<Data> Data => _db.GetCollection<Data>("Data");
    }
}