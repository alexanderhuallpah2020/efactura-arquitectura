using DataConsulting.Efactura.Application.Abstractions.Messaging;
using DataConsulting.Efactura.Application.Features.SegmentosSunat.Queries.GetSegmentoFamiliaClase;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataConsulting.Efactura.Application.Features.SegmentosSunat.Queries.GetSegmentoFamiliaClase.V1
{
    public sealed record GetSegmentoFamiliaClaseV1Query()
            : IQuery<List<GetSegmentoFamiliaClaseResponse>>;
}
