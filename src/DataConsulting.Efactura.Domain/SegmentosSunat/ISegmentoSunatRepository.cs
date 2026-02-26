namespace DataConsulting.Efactura.Domain.SegmentosSunat
{
    public interface ISegmentoSunatRepository
    {
        Task<IReadOnlyList<SegmentoSunat>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
