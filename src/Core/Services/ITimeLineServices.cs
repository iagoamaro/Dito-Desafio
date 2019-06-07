using System.Threading.Tasks;
using src.Core.Models;

namespace src.Core.Services
{
    public interface ITimeLineServices
    {
         Task<TimeLine> GetTimeLine();
    }
}