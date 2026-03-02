using DataConsulting.Efactura.Domain.FamiliasSunat;
using DataConsulting.Efactura.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace DataConsulting.Efactura.Infrastructure.Repositories
{
    internal sealed class FamiliaSunatRepository(ApplicationDbContext dbContext)
           : Repository<FamiliaSunat>(dbContext), IFamiliaSunatRepository
    {
        public async Task<bool> ExistsByCodigoAsync(
            int idSegmentoSunat,
            string codigo,
            CancellationToken cancellationToken = default)
        {
            string norm = codigo.Trim().ToUpper();

            return await DbContext.FamiliasSunat
                .AnyAsync(x => x.IdSegmentoSunat == idSegmentoSunat && x.Codigo == norm, cancellationToken);
        }

        public async Task<int> GetNextIdAsync(CancellationToken cancellationToken = default)
        {
            int maxId = await DbContext.FamiliasSunat
                .MaxAsync(x => (int?)x.Id, cancellationToken) ?? 0;

            return maxId + 1;
        }
    }
}
