using DataConsulting.Efactura.Application.Abstractions.Data;
using DataConsulting.Efactura.Domain.SegmentosSunat;
using DataConsulting.Efactura.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;

namespace DataConsulting.Efactura.Infrastructure.Database;

public sealed class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<SegmentoSunat> SegmentosSunat => Set<SegmentoSunat>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new SegmentoSunatConfiguration());
    }

    public async Task<DbTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        // Si ya hay una transacción activa, no la reiniciamos.
        if (Database.CurrentTransaction is not null)
        {
            return Database.CurrentTransaction.GetDbTransaction();
        }

        IDbContextTransaction tx = await Database.BeginTransactionAsync(cancellationToken);
        return tx.GetDbTransaction();
    }
}