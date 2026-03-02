using DataConsulting.Efactura.Domain.Abstractions;
using DataConsulting.Efactura.Domain.Enums;

namespace DataConsulting.Efactura.Domain.SegmentosSunat
{
    public sealed class SegmentoSunat : Entity
    {
        private SegmentoSunat(
            int id,
            string codigo,
            string descripcion,
            EEstado estado,
            short updateToken,
            short idUsuarioCreador,
            DateTime fechaCreacion)
            : base(id)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            Estado = estado;
            UpdateToken = updateToken;
            IdUsuarioCreador = idUsuarioCreador;
            FechaCreacion = fechaCreacion;
        }

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
            DateTime fechaCreacion)
        {
            return new SegmentoSunat
            {
                IdSegmentoSunat = idSegmentoSunat,
                Codigo = codigo,
                Descripcion = descripcion,
                Estado = EEstado.Activo,
                UpdateToken = 1,
                IdUsuarioCreador = idUsuarioCreador,
                FechaCreacion = fechaCreacion
            };
        }
    }
}
