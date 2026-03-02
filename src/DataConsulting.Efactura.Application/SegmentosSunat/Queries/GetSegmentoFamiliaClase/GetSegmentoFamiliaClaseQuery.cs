using DataConsulting.Efactura.Application.Abstractions.Messaging;

namespace DataConsulting.Efactura.Application.SegmentosSunat.Queries.GetSegmentoFamiliaClase
{
    public sealed record GetSegmentoFamiliaClaseQuery()
           : IQuery<List<GetSegmentoFamiliaClaseResponse>>;
}
