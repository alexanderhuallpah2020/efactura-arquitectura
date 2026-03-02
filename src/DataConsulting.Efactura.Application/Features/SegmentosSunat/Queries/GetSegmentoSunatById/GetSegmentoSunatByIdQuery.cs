using DataConsulting.Efactura.Application.Abstractions.Messaging;

namespace DataConsulting.Efactura.Application.Features.SegmentosSunat.Queries.GetSegmentoSunatById
{
    public sealed record GetSegmentoSunatByIdQuery(int idSegmentoSunat)
            : IQuery<GetSegmentoSunatByIdResponse>;
}
