using LuminiTeste.Domain.Dto;
using LuminiTeste.Domain.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LuminiTeste.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoutesController : ControllerBase
    {
        private readonly IRouteService _service;

        public RoutesController(IRouteService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AddRoute([FromBody] RouteDto route)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _service.AddRoute(route.Origin, route.Destination, route.Cost);
            return Ok(result);
        }

        [HttpGet("best-route/{origin}-{destination}")]
        public IActionResult GetBestRoute(string origin, string destination)
        {
            var result = _service.FindCheapestRoute(origin, destination);
            return Ok(result);
        }
    }
}
