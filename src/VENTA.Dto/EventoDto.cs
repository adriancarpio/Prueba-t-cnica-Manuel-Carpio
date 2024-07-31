namespace VENTA.Dto
{
    public class EventoDto
    {
        public int Id { get; set; }
        public DateTime FechaEvento { get; set; }
        public string? LugarEvento { get; set; }
        public string? DescripcionEvento { get; set; }
        public decimal Precio { get; set; }
        public bool Eliminado { get; set; }
    }
}
