using DataConsulting.Efactura.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataConsulting.Efactura.Application.Services.ClasesSunat
{
    public interface IClaseSunatService
    {
        Task<Result<int>> RegistrarClaseAsync(
            int idFamiliaSunat,
            string codigo,
            string descripcion,
            short idUsuario,
            CancellationToken ct);
    }
}
