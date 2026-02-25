namespace DataConsulting.Efactura.Domain.SegmentosSunat
{
    public sealed class SegmentoSunat
    {
        private SegmentoSunat() { }

        public int IdSegmentoSunat { get; private set; }
        public string Codigo { get; private set; } = default!;
        public string Descripcion { get; private set; } = default!;
        public SegmentoEstado Estado { get; private set; }

        // Concurrencia (en su tabla es smallint)
        public short UpdateToken { get; private set; }

        // Auditoría (dominio puro: no depende de infraestructura)
        public short IdUsuarioCreador { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public short? IdUsuarioModificador { get; private set; }
        public DateTime? FechaModificacion { get; private set; }
    }

    public enum SegmentoEstado : short
    {
        Inactivo = 0,
        Activo = 1
    }
}
