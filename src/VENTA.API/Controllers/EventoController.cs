using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VENTA.Application.Interface;

namespace VENTA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _eventoService;

        public EventoController(IEventoService eventoService) {
            _eventoService = eventoService;
        }

        [HttpGet("GetEventos")]
        public async Task<JsonResult> GetEventos()
        {
            return new JsonResult(await _eventoService.GetEventos());
        }

        [HttpGet("GetEvento")]
        public async Task<JsonResult> GetEvento(int idEvento)
        {
            return new JsonResult(await _eventoService.GetEventoById(idEvento));
        }

        [HttpPost("CreateEvento")]
        public async Task<JsonResult> CreateEvento(DateTime fechaEvento,
            string lugarEvento, string descripcionEvento, decimal precio)
        {
            return new JsonResult(await _eventoService
                .CreateEvento(fechaEvento, lugarEvento, descripcionEvento, precio));
        }

        [HttpPut("UpdateEvento")]
        public async Task<JsonResult> UpdateEvento(int idEvento, DateTime fechaEvento,
            string lugarEvento, string descripcionEvento, decimal precio)
        {
            return new JsonResult(await _eventoService.UpdateEvento(idEvento,
                fechaEvento, lugarEvento, descripcionEvento, precio));
        }

        [HttpDelete("DeleteEventos")]
        public async Task<JsonResult> DeleteEventos(int idEvento)
        {
            return new JsonResult(await _eventoService.DeleteEvento(idEvento));
        }
    }
}
