using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.Core.Models;
using src.Core.Services;

namespace src.Controllers
{
   
    public class TimeLineController  : Controller
    {
        private readonly ITimeLineServices _timeLine;
        public TimeLineController(ITimeLineServices timeLine)
        {
            _timeLine = timeLine;
        }

       [HttpGet]
        public async Task<TimeLine> Index()
        {
           return await _timeLine.GetTimeLine();
        }
        
    }
}