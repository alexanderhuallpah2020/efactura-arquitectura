using DataConsulting.Efactura.Domain.Enums;

namespace DataConsulting.Efactura.Domain.SegmentosSunat
{
    public sealed class SegmentoSunat
    {
        private SegmentoSunat() { }

        public int IdSegmentoSunat { get; private set; }
        public string Codigo { get; private set; } = default!;
        public string Descripcion { get; private set; } = default!;
        public EEstado Estado { get; private set; }

        // Concurrencia (en su tabla es smallint)
        public short UpdateToken { get; private set; }

        // Auditoría (dominio puro: no depende de infraestructura)
        public short IdUsuarioCreador { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public short? IdUsuarioModificador { get; private set; }
        public DateTime? FechaModificacion { get; private set; }

        public static SegmentoSunat Create(
            int idSegmentoSunat,
            string codigo,
            string descripcion,
            short idUsuarioCreador,
            DateTime fechaCreacionUtc)
        {
            return new SegmentoSunat
            {
                IdSegmentoSunat = idSegmentoSunat,
                Codigo = codigo,
                Descripcion = descripcion,
                Estado = EEstado.Activo,
                UpdateToken = 1,
                IdUsuarioCreador = idUsuarioCreador,
                FechaCreacion = fechaCreacionUtc
            };
        }
    }
}
