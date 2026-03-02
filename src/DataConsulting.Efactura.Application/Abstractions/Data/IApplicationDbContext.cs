using DataConsulting.Efactura.Domain.ClasesSunat;
using DataConsulting.Efactura.Domain.FamiliasSunat;
using DataConsulting.Efactura.Domain.SegmentosSunat;
using Microsoft.EntityFrameworkCore;

namespace DataConsulting.Efactura.Application.Abstractions.Data
{
    public interface IApplicationDbContext
    {
        DbSet<SegmentoSunat> SegmentosSunat { get; }
        DbSet<FamiliaSunat> FamiliasSunat { get; }
        DbSet<ClaseSunat> ClasesSunat { get; }
    }
}