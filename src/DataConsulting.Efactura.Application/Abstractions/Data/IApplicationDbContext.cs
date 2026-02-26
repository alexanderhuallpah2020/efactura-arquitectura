using DataConsulting.Efactura.Domain.SegmentosSunat;
using Microsoft.EntityFrameworkCore;

namespace DataConsulting.Efactura.Application.Abstractions.Data
{
    public interface IApplicationDbContext
    {
        DbSet<SegmentoSunat> SegmentosSunat { get; }
    }
}