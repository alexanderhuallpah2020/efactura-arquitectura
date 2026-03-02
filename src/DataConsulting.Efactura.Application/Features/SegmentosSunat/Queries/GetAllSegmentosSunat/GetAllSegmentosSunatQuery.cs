using DataConsulting.Efactura.Application.Abstractions.Messaging;

namespace DataConsulting.Efactura.Application.Features.SegmentosSunat.Queries.GetAllSegmentosSunat
{
    public sealed record GetAllSegmentosSunatQuery() : IQuery<List<GetAllSegmentosSunatResponse>>;
}
