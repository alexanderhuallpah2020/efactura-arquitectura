using DataConsulting.Efactura.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataConsulting.Efactura.Application.SegmentosSunat.Queries.GetSegmentoFamiliaClase.V1
{
    public sealed record GetSegmentoFamiliaClaseV1Query()
            : IQuery<List<GetSegmentoFamiliaClaseResponse>>;
}
