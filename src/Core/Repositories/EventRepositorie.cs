using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dito.Core.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using src.Core.Mongo;


namespace src.Core.Repositories
{
    public class EventRepositorie : IEventRepositorie
    {
        private readonly IDitoContext _db;
        public EventRepositorie(IDitoContext db)
        {
            _db = db;
        }
        

        private IEnumerable<Data> SearchEvent(string name)
        {

            return _db.Data.AsQueryable().Where(x => x.Event.ToLower().Contains(name.ToLower()));
        }
        public async Task<IEnumerable<Data>> Search(string name)
        {
            var result = SearchEvent(name);
            return await Task.FromResult(result.ToList());
        }

        public async Task AddEvent(IEnumerable<Data> data)
        {
           await _db.Data.InsertManyAsync(data);
        }
        public async Task AddEvent(Data data)
        {
           await _db.Data.InsertOneAsync(data);
        }
    }
}