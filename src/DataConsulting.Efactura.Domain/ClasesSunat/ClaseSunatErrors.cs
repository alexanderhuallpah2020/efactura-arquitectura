using DataConsulting.Efactura.Domain.Abstractions;

namespace DataConsulting.Efactura.Domain.ClasesSunat
{
    public static class ClaseSunatErrors
    {
        public static Error FamiliaNotFound(int id) =>
             Error.NotFound("ClasesSunat.FamiliaNotFound", $"La familia {id} no existe.");

        public static Error CodigoDuplicado(string codigo) =>
               Error.Conflict("ClasesSunat.CodigoDuplicado", $"El código {codigo} ya está registrado.");
    }
}
