using DataConsulting.Efactura.Application.Abstractions.Data;
using DataConsulting.Efactura.Application.Abstractions.Messaging;
using DataConsulting.Efactura.Domain.Abstractions;
using DataConsulting.Efactura.Domain.SegmentosSunat;

namespace DataConsulting.Efactura.Application.SegmentosSunat.Commands.CreateSegmentoSunat
{
    internal sealed class CreateSegmentoSunatCommandHandler(
         ISegmentoSunatRepository repository,
         IUnitOfWork unitOfWork)
         : ICommandHandler<CreateSegmentoSunatCommand>
    {
        public async Task<Result> Handle(CreateSegmentoSunatCommand request, CancellationToken cancellationToken)
        {
            if (await repository.ExistsByCodigoAsync(request.Codigo, cancellationToken))
            {
                return Result.Failure(SegmentoSunatErrors.CodigoDuplicado(request.Codigo));
            }

            int nuevoId = await repository.GetNextIdAsync(cancellationToken);

            var entity = SegmentoSunat.Create(
                nuevoId,
                request.Codigo,
                request.Descripcion,
                1,
                DateTime.UtcNow);

            repository.Add(entity);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(entity.Id);
        }
    }
}
