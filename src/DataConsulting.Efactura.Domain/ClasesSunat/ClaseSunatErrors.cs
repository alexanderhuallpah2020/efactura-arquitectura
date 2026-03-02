using DataConsulting.Efactura.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataConsulting.Efactura.Domain.ClasesSunat
{
    public static class ClaseSunatErrors
    {
        public static Error NotFound(int idClaseSunat) =>
            Error.NotFound(
                "ClasesSunat.NotFound",
                $"No se encontró la ClaseSunat con Id {idClaseSunat}");

        public static Error FamiliaNotFound(int idFamiliaSunat) =>
            Error.NotFound(
                "ClasesSunat.FamiliaNotFound",
                $"No se encontró la FamiliaSunat con Id {idFamiliaSunat}");

        public static Error CodigoDuplicado(int idFamiliaSunat, string codigo) =>
            Error.Conflict(
                "ClasesSunat.CodigoDuplicado",
                $"Ya existe una ClaseSunat con código '{codigo}' para la FamiliaSunat {idFamiliaSunat}");
    }
}
