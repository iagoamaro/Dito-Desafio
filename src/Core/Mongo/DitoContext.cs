using dito.Core.Models;
using MongoDB.Driver;

namespace src.Core.Mongo
{
    public class DitoContext : IDitoContext
    {
        private readonly IMongoDatabase _db;
        public DitoContext(string mongoSrv)
        {
            var client = new MongoClient(mongoSrv);
            _db = client.GetDatabase("Dito");
        }
        public IMongoCollection<Data> Data => _db.GetCollection<Data>("Data");
    }
}