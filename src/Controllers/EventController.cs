using System.Collections.Generic;
using System.Threading.Tasks;
using dito.Core.Models;
using Microsoft.AspNetCore.Mvc;
using src.Core.Repositories;

namespace dito.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class EventController : Controller
    {
        private readonly IEventRepositorie _eventRepositorie;
        public EventController(IEventRepositorie eventRepositorie)
        {
            _eventRepositorie = eventRepositorie;
        }

        [HttpGet]
        public async Task<JsonResult> AutoComplete(string name)
        {
            if (name.Length >= 2)
                return Json(await _eventRepositorie.Search(name));
            return Json("Necessário ao menos 2 letras para efeturar a busca!");
        }

        [HttpPost]
        public async Task<ActionResult> Insert([FromBody]Data data)
        {
            await _eventRepositorie.AddEvent(data);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Insert([FromBody]IList<Data> data)
        {
            if (data.Count > 0)
                await _eventRepositorie.AddEvent(data);
            return Ok();
        }

        [HttpGet]
        public async Task<JsonResult> Insert()
        {
            
            return Json("");
        }

    }
}