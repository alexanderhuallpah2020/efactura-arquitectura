using DataConsulting.Efactura.Domain.SegmentosSunat;
using DataConsulting.Efactura.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace DataConsulting.Efactura.Infrastructure.Repositories
{
    internal sealed class SegmentoSunatRepository : ISegmentoSunatRepository
    {
        private readonly ApplicationDbContext _context;

        public SegmentoSunatRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<SegmentoSunat>> GetAllAsync(
            CancellationToken cancellationToken = default)
        {
            return await _context.SegmentosSunat
                .AsNoTracking() // porque es solo lectura
                .OrderBy(x => x.Descripcion)
                .ToListAsync(cancellationToken);
        }
    }
}
