using DataConsulting.Efactura.Application.Abstractions.Data;
using DataConsulting.Efactura.Application.Abstractions.Messaging;
using DataConsulting.Efactura.Application.Services.ClasesSunat;
using DataConsulting.Efactura.Domain.Abstractions;

namespace DataConsulting.Efactura.Application.Features.ClasesSunat.Commands.CreateClaseSunat
{
    internal sealed class CreateClaseSunatCommandHandler(
       IClaseSunatService claseService,
       IUnitOfWork unitOfWork) : ICommandHandler<CreateClaseSunatCommand, int>
    {
        public async Task<Result<int>> Handle(CreateClaseSunatCommand request, CancellationToken ct)
        {
            var result = await claseService.RegistrarClaseAsync(
                request.IdFamiliaSunat,
                request.Codigo,
                request.Descripcion,
                request.IdUsuarioCreador,
                ct);

            if (result.IsFailure)
            {
                return result;
            }

            await unitOfWork.SaveChangesAsync(ct);

            return result;
        }
    }
}
