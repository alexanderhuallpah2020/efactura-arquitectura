using DataConsulting.Efactura.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataConsulting.Efactura.Application.SegmentosSunat.Commands.CreateSegmentoSunat
{
    public sealed record CreateSegmentoSunatCommand(
           int IdSegmentoSunat,
           string Codigo,
           string Descripcion,
           short IdUsuarioCreador
       ) : ICommand;
}
