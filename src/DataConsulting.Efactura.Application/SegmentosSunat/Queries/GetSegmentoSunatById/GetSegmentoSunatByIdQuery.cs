using DataConsulting.Efactura.Application.Abstractions.Messaging;

namespace DataConsulting.Efactura.Application.SegmentosSunat.Queries.GetSegmentoSunatById
{
    public sealed record GetSegmentoSunatByIdQuery(int idSegmentoSunat)
            : IQuery<GetSegmentoSunatByIdResponse>;
}
