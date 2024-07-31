using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VENTA.Domain.Entity;
using VENTA.Infrastructure.Data;
using VENTA.Infrastructure.Interface;

namespace VENTA.Infrastructure.Repository
{
    public class EventoRepository : IEventoRepository
    {
        public readonly IDbConnection Connection;

        public EventoRepository(IConnectionService connection)
        {
            string conSql = connection.GetConnection();

            Connection = new SqlConnection(conSql);
        }

        public async Task CreateEvento(DateTime fechaEvento, 
            string lugarEvento, string descripcionEvento, decimal precio)
        {
            DynamicParameters parametro = new();
            parametro.Add("Operacion", "Registrar");
            parametro.Add("FechaEvento", fechaEvento);
            parametro.Add("LugarEvento", lugarEvento);
            parametro.Add("DescripcionEvento", descripcionEvento);
            parametro.Add("Precio", precio);


            await Connection.ExecuteAsync("GestionarEvento", parametro, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteEvento(int idEvento)
        {
            DynamicParameters parametro = new();
            parametro.Add("Operacion", "Eliminar");
            parametro.Add("Id", idEvento);

            await Connection.ExecuteAsync("GestionarEvento", parametro, commandType: CommandType.StoredProcedure);

        }

        public async Task<Evento?> GetEventoById(int idEvento)
        {
            DynamicParameters parametro = new();
            parametro.Add("Operacion", "Consultar");
            parametro.Add("Id", idEvento);

            Evento? consulta = await Connection.QueryFirstOrDefaultAsync<Evento?>("GestionarEvento", parametro, commandType: CommandType.StoredProcedure);

            return consulta;
        }

        public async Task<IEnumerable<Evento>> GetEventos()
        {
            DynamicParameters parametro = new();
            parametro.Add("Operacion", "ConsultarTodos");

            IEnumerable<Evento> lista = await Connection.QueryAsync<Evento>("GestionarEvento", parametro, commandType: CommandType.StoredProcedure);

            return lista;
        }

        public async Task UpdateEvento(int idEvento, 
            DateTime fechaEvento, string lugarEvento, string descripcionEvento, decimal precio)
        {
            DynamicParameters parametro = new();
            parametro.Add("Operacion", "Modificar");
            parametro.Add("Id", idEvento);
            parametro.Add("FechaEvento", fechaEvento);
            parametro.Add("LugarEvento", lugarEvento);
            parametro.Add("DescripcionEvento", descripcionEvento);
            parametro.Add("Precio", precio);

            await Connection.ExecuteAsync("GestionarEvento", parametro, commandType: CommandType.StoredProcedure);

        }
    }
}
