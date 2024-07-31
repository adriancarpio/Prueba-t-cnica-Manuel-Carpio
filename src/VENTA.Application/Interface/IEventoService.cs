using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VENTA.Dto;

namespace VENTA.Application.Interface
{
    public interface IEventoService
    {
        public Task<RespuestaGenerica<bool>> CreateEvento(DateTime fechaEvento, 
            string lugarEvento, string descripcionEvento, decimal precio);
        public Task<RespuestaGenerica<bool>> UpdateEvento(int idEvento, DateTime fechaEvento,
            string lugarEvento, string descripcionEvento, decimal precio);
        public Task<RespuestaGenerica<bool>> DeleteEvento(int idEvento);
        public Task<RespuestaGenerica<EventoDto>> GetEventoById(int idEvento);
        public Task<RespuestaGenerica<IEnumerable<EventoDto>>> GetEventos();
    }
}
