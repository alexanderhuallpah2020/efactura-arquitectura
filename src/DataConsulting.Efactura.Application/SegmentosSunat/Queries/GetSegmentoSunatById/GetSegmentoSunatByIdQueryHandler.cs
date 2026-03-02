using DataConsulting.Efactura.Application.Abstractions.Data;
using DataConsulting.Efactura.Application.Abstractions.Messaging;
using DataConsulting.Efactura.Domain.Abstractions;
using DataConsulting.Efactura.Domain.SegmentosSunat;
using Microsoft.EntityFrameworkCore;

namespace DataConsulting.Efactura.Application.SegmentosSunat.Queries.GetSegmentoSunatById
{
    internal sealed class GetSegmentoSunatByIdQueryHandler(IApplicationDbContext context)
        : IQueryHandler<GetSegmentoSunatByIdQuery, GetSegmentoSunatByIdResponse>
    {
        public async Task<Result<GetSegmentoSunatByIdResponse>> Handle(
            GetSegmentoSunatByIdQuery query,
            CancellationToken cancellationToken)
        {
            var item = await context.SegmentosSunat
                .AsNoTracking()
                .Where(x => x.Id == query.idSegmentoSunat)
                .Select(x => new GetSegmentoSunatByIdResponse
                {
                    IdSegmentoSunat = x.IdSegmentoSunat,
                    Codigo = x.Codigo,
                    Descripcion = x.Descripcion,
                    Estado = (short)x.Estado,
                    UpdateToken = x.UpdateToken,
                    IdUsuarioCreador = x.IdUsuarioCreador,
                    FechaCreacion = x.FechaCreacion,
                    IdUsuarioModificador = x.IdUsuarioModificador,
                    FechaModificacion = x.FechaModificacion
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (item is null)
            {
                return Result.Failure<GetSegmentoSunatByIdResponse>(SegmentoSunatErrors.NotFound(query.idSegmentoSunat));
            }

            return item;
        }
    }
}
