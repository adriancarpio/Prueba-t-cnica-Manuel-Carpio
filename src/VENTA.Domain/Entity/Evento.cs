using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VENTA.Domain.Entity
{
    public class Evento
    {
        [Key]
        public int Id { get; set; }
        public DateTime FechaEvento { get; set; }
        public string? LugarEvento { get; set; }
        public string? DescripcionEvento { get; set; }
        public decimal Precio { get; set; }
        public bool Eliminado { get; set; }
    }
}
