using System.Collections.Generic;
using System.Threading.Tasks;
using dito.Core.Models;

namespace src.Core.Repositories
{
    public interface IEventRepositorie
    {
         Task<IEnumerable<Data>> Search(string name);         
         Task AddEvent(IEnumerable<Data> data);
         Task AddEvent(Data data);
         
    }
}