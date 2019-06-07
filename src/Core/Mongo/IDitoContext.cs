using dito.Core.Models;
using MongoDB.Driver;

namespace src.Core.Mongo
{
    public interface IDitoContext
    {
        IMongoCollection<Data> Data { get; }

    }
}