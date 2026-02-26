namespace DataConsulting.Efactura.API.Controllers.SegmentosSunat
{
    public sealed class CreateSegmentoSunatRequest
    {
        public int IdSegmentoSunat { get; init; }
        public string Codigo { get; init; } = string.Empty;
        public string Descripcion { get; init; } = string.Empty;
        public short IdUsuarioCreador { get; init; }
    }
}
