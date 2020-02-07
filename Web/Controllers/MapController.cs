using System.Collections.Generic;
using System.Threading.Tasks;
using Application.CQRS.Maps.Command;
using Application.CQRS.Maps.Queries;
using Application.CQRS.Maps.TransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class MapController : APIBaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<MapDTO>>> Get()
        {
            return await Mediator.Send(new MapsQuery());
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<MapDTO>> Get(int id)
        {
            return await Mediator.Send(new MapQuery(id));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] MapDTO value)
        {
            return await Mediator.Send(new MapCreaterCommand(value));
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] MapDTO value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
