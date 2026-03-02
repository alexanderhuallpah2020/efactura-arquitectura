using System.Data.Common;

namespace DataConsulting.Efactura.Application.Abstractions.Data
{
    public interface IDbConnectionFactory
    {
        ValueTask<DbConnection> OpenConnectionAsync();
    }

}
