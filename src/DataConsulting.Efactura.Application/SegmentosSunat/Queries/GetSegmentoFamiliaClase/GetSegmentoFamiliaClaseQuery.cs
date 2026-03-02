using DataConsulting.Efactura.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataConsulting.Efactura.Application.SegmentosSunat.Queries.GetSegmentoFamiliaClase
{
    public sealed record GetSegmentoFamiliaClaseQuery()
           : IQuery<List<GetSegmentoFamiliaClaseResponse>>;
}
