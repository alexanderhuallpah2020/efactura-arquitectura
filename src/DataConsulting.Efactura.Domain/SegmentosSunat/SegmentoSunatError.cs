using DataConsulting.Efactura.Domain.Abstractions;

namespace DataConsulting.Efactura.Domain.SegmentosSunat
{
    public static class SegmentoSunatErrors
    {
        public static Error NotFound(int idSegmentoSunat) =>
            Error.NotFound(
                "SegmentosSunat.NotFound",
                $"No se encontró el SegmentoSunat con Id {idSegmentoSunat}");

        public static Error NotFound(string codigo) =>
            Error.NotFound(
                "SegmentosSunat.NotFound",
                $"No se encontró el SegmentoSunat con código '{codigo}'");

        public static Error CodigoDuplicado(string codigo) =>
            Error.Conflict(
                "SegmentosSunat.CodigoDuplicado",
                $"Ya existe un SegmentoSunat con código '{codigo}'");

        public static Error CodigoInvalido(string codigo) =>
            Error.Failure(
                "SegmentosSunat.CodigoInvalido",
                $"El código '{codigo}' es inválido. Máximo 10 caracteres y no puede estar vacío.");

        public static Error DescripcionInvalida() =>
            Error.Failure(
                "SegmentosSunat.DescripcionInvalida",
                "La descripción es obligatoria y no puede exceder 200 caracteres.");

        public static Error EstadoInvalido(short estado) =>
            Error.Failure(
                "SegmentosSunat.EstadoInvalido",
                $"El estado '{estado}' es inválido.");
    }
}
