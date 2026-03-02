using Asp.Versioning;
using DataConsulting.Efactura.API.Utils;
using DataConsulting.Efactura.Application.Abstractions.Messaging;
using DataConsulting.Efactura.Application.SegmentosSunat.Commands.CreateSegmentoSunat;
using DataConsulting.Efactura.Application.SegmentosSunat.Queries.GetAllSegmentosSunat;
using DataConsulting.Efactura.Application.SegmentosSunat.Queries.GetSegmentoSunatById;
using DataConsulting.Efactura.Domain.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace DataConsulting.Efactura.API.Controllers.SegmentosSunat
{
    [ApiController]
    [ApiVersion(ApiVersions.V1)]
    [Route("api/v{version:apiVersion}/segmentos-sunat")]
    public class SegmentoSunatController : ControllerBase
    {
        private readonly IQueryHandler<GetAllSegmentosSunatQuery, List<GetAllSegmentosSunatResponse>> _getAllHandler;
        private readonly IQueryHandler<GetSegmentoSunatByIdQuery, GetSegmentoSunatByIdResponse> _getByIdHandler;
        private readonly ICommandHandler<CreateSegmentoSunatCommand> _createHandler;

        public SegmentoSunatController(IQueryHandler<GetAllSegmentosSunatQuery, List<GetAllSegmentosSunatResponse>> getAllHandler, IQueryHandler<GetSegmentoSunatByIdQuery, GetSegmentoSunatByIdResponse> getByIdHandler, ICommandHandler<CreateSegmentoSunatCommand> createHandler)
        {
            _getAllHandler = getAllHandler;
            _getByIdHandler = getByIdHandler;
            _createHandler = createHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var query = new GetAllSegmentosSunatQuery();
            var result = await _getAllHandler.Handle(query, cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken = default)
        {
            var query = new GetSegmentoSunatByIdQuery(id);
            var result = await _getByIdHandler.Handle(query, cancellationToken);
            return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
           [FromBody] CreateSegmentoSunatRequest request,
           CancellationToken cancellationToken = default)
        {
            var command = new CreateSegmentoSunatCommand(
                request.Codigo,
                request.Descripcion);

            Result result = await _createHandler.Handle(command, cancellationToken);

            return result.IsSuccess ? Ok() : BadRequest(result.Error);
        }
    }
}
