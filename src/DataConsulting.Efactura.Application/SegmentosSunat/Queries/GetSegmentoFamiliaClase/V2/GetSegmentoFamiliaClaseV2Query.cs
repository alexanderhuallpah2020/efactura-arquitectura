using DataConsulting.Efactura.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataConsulting.Efactura.Application.SegmentosSunat.Queries.GetSegmentoFamiliaClase.V2
{
    public sealed record GetSegmentoFamiliaClaseV2Query()
           : IQuery<List<GetSegmentoFamiliaClaseResponse>>;
}
