using DataConsulting.Efactura.Application.Abstractions.Data;
using DataConsulting.Efactura.Application.Abstractions.Messaging;
using DataConsulting.Efactura.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DataConsulting.Efactura.Application.SegmentosSunat.Queries.GetSegmentoFamiliaClase
{
    internal sealed class GetSegmentoFamiliaClaseQueryHandler(IApplicationDbContext context)
           : IQueryHandler<GetSegmentoFamiliaClaseQuery, List<GetSegmentoFamiliaClaseResponse>>
    {
        public async Task<Result<List<GetSegmentoFamiliaClaseResponse>>> Handle(
            GetSegmentoFamiliaClaseQuery query,
            CancellationToken cancellationToken)
        {
            var data =
                await (from s in context.SegmentosSunat.AsNoTracking()
                       join f in context.FamiliasSunat.AsNoTracking()
                           on s.Id equals f.IdSegmentoSunat
                       join c in context.ClasesSunat.AsNoTracking()
                           on f.Id equals c.IdFamiliaSunat
                       orderby s.Codigo, f.Codigo, c.Codigo
                       select new GetSegmentoFamiliaClaseResponse
                       {
                           Segmento = s.Codigo,
                           SegmentoDescripcion = s.Descripcion,
                           Familia = f.Codigo,
                           FamiliaDescripcion = f.Descripcion,
                           Clase = c.Codigo,
                           ClaseDescripcion = c.Descripcion
                       })
                      .ToListAsync(cancellationToken);

            return data;
        }
    }
}
