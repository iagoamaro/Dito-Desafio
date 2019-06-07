using System.Collections.Generic;
using System.Threading.Tasks;
using dito.Core.Models;
using Microsoft.AspNetCore.Mvc;
using src.Core.Repositories;

namespace dito.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventRepositorie _eventRepositorie;
        public EventController(IEventRepositorie eventRepositorie)
        {
            _eventRepositorie = eventRepositorie;
        }

        [HttpGet()]
        public IActionResult Index() => View("Index");


        public async Task<JsonResult> Search(string name)
        {
            if (name.Length >= 2)
                return Json(await _eventRepositorie.Search(name));
            return Json("Necessário ao menos 2 letras para efeturar a busca!");
        }

        [HttpPost()]
        public async Task<ActionResult> Insert([FromBody]Data data)
        {
            await _eventRepositorie.AddEvent(data);
            return Ok("Dados inseridos com sucesso!");
        }

        [HttpPost]
        public async Task<ActionResult> InsertList([FromBody]IList<Data> data)
        {
            if (data != null)
                await _eventRepositorie.AddEvent(data);
            return Ok();
        }


    }
}