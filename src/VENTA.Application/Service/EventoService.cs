using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VENTA.Application.Interface;
using VENTA.Dto;
using VENTA.Infrastructure.Interface;
using VENTA.Infrastructure.Utilidades;

namespace VENTA.Application.Service
{
    internal class EventoService : IEventoService
    {
        private readonly IEventoRepository repository;

        public EventoService(IEventoRepository repository)
        {
            this.repository = repository; 
        }

        public async Task<RespuestaGenerica<bool>> CreateEvento(DateTime fechaEvento, string lugarEvento, string descripcionEvento, decimal precio)
        {
            try
            {
                await repository.CreateEvento(fechaEvento, lugarEvento, descripcionEvento, precio);

                return RespuestaGenerica<bool>.RespuestaExito(true);
            }
            catch
            {
                return RespuestaGenerica<bool>.RespuestaError("Ha Ocurrido una Excepción");
            }
        }

        public async Task<RespuestaGenerica<bool>> DeleteEvento(int idEvento)
        {
            try
            {
                await repository.DeleteEvento(idEvento);

                return RespuestaGenerica<bool>.RespuestaExito(true);
            }
            catch
            {
                return RespuestaGenerica<bool>.RespuestaError("Ha Ocurrido una Excepción");
            }
        }

        public async Task<RespuestaGenerica<EventoDto>> GetEventoById(int idEvento)
        {
            try
            {
                var evento = await repository.GetEventoById(idEvento);
                if (evento is null)
                {
                    return RespuestaGenerica<EventoDto>.RespuestaError("El evento no existe");
                }

                var eventoDto = evento.Mapear<EventoDto>();

                return RespuestaGenerica<EventoDto>.RespuestaExito(eventoDto);
            }
            catch
            {
                return RespuestaGenerica<EventoDto>.RespuestaError("Ha Ocurrido una Excepción");
            }
        }

        public async Task<RespuestaGenerica<IEnumerable<EventoDto>>> GetEventos()
        {
            try
            {
                var eventos = await repository.GetEventos();
                var eventosDto = eventos.Mapear<IEnumerable<EventoDto>>();
                return RespuestaGenerica<IEnumerable<EventoDto>>.RespuestaExito(eventosDto);
            }
            catch
            {
                return RespuestaGenerica<IEnumerable<EventoDto>>.RespuestaError("Ha Ocurrido una Excepción");
            }
        }

        public async Task<RespuestaGenerica<bool>> UpdateEvento(int idEvento, DateTime fechaEvento, string lugarEvento, string descripcionEvento, decimal precio)
        {
            try
            {
                await repository.UpdateEvento(idEvento,
                    fechaEvento, lugarEvento, descripcionEvento, precio);

                return RespuestaGenerica<bool>.RespuestaExito(true);
            }
            catch
            {
                return RespuestaGenerica<bool>.RespuestaError("Ha Ocurrido una Excepción");
            }
        }
    }
}
