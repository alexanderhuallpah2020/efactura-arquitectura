using DataConsulting.Efactura.Application.Abstractions.Data;
using DataConsulting.Efactura.Domain.ClasesSunat;
using DataConsulting.Efactura.Domain.FamiliasSunat;
using DataConsulting.Efactura.Domain.SegmentosSunat;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;

namespace DataConsulting.Efactura.Infrastructure.Database;

public sealed class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    }

    public DbSet<SegmentoSunat> SegmentosSunat { get; set; }
    public DbSet<FamiliaSunat> FamiliasSunat { get; set; }
    public DbSet<ClaseSunat> ClasesSunat { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public async Task<DbTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (Database.CurrentTransaction is not null)
        {
            await Database.CurrentTransaction.DisposeAsync();
        }

        return (await Database.BeginTransactionAsync(cancellationToken)).GetDbTransaction();
    }
}