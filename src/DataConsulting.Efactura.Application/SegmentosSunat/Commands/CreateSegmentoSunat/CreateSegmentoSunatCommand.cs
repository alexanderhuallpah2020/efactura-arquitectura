using DataConsulting.Efactura.Application.Abstractions.Messaging;

namespace DataConsulting.Efactura.Application.SegmentosSunat.Commands.CreateSegmentoSunat
{
    public sealed record CreateSegmentoSunatCommand(
           string Codigo,
           string Descripcion
       ) : ICommand<int>;
}
