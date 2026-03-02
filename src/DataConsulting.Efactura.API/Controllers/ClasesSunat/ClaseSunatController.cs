using Asp.Versioning;
using DataConsulting.Efactura.API.Utils;
using DataConsulting.Efactura.Application.Abstractions.Messaging;
using DataConsulting.Efactura.Application.Features.ClasesSunat.Commands.CreateClaseSunat;
using DataConsulting.Efactura.Domain.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace DataConsulting.Efactura.API.Controllers.ClasesSunat
{
    [ApiController]
    [ApiVersion(ApiVersions.V1)]
    [Route("api/v{version:apiVersion}/clases-sunat")]
    public class ClaseSunatController : ControllerBase
    {
        private readonly ICommandHandler<CreateClaseSunatCommand, int> _createHandler;

        public ClaseSunatController(
            ICommandHandler<CreateClaseSunatCommand, int> createHandler)
        {
            _createHandler = createHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
           [FromBody] CreateClaseSunatRequest request,
           CancellationToken cancellationToken = default)
        {
            short idUsuarioTemporal = 1;

            var command = new CreateClaseSunatCommand(
                request.IdFamiliaSunat,
                request.Codigo,
                request.Descripcion,
                idUsuarioTemporal);

            Result<int> result = await _createHandler.Handle(command, cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }
    }
}