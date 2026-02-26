using DataConsulting.Efactura.Application.Abstractions.Data;
using DataConsulting.Efactura.Application.Abstractions.Messaging;
using DataConsulting.Efactura.Domain.Abstractions;
using DataConsulting.Efactura.Domain.SegmentosSunat;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataConsulting.Efactura.Application.SegmentosSunat.Commands.CreateSegmentoSunat
{
    internal sealed class CreateSegmentoSunatCommandHandler(
         ISegmentoSunatRepository repository,
         IUnitOfWork unitOfWork)
         : ICommandHandler<CreateSegmentoSunatCommand>
    {
        public async Task<Result> Handle(CreateSegmentoSunatCommand request, CancellationToken cancellationToken)
        {
            SegmentoSunat? existente = await repository.GetAsync(request.IdSegmentoSunat, cancellationToken);
            if (existente is not null)
            {
                return Result.Failure(SegmentoSunatErrors.NotFound(request.IdSegmentoSunat));
            }

            string codigo = request.Codigo.Trim();
            bool codigoExiste = await repository.ExistsByCodigoAsync(codigo, cancellationToken);
            if (codigoExiste)
            {
                return Result.Failure(SegmentoSunatErrors.CodigoDuplicado(codigo));
            }

            string descripcion = request.Descripcion.Trim();

            var entity = SegmentoSunat.Create(
                request.IdSegmentoSunat,
                codigo,
                descripcion,
                request.IdUsuarioCreador,
                DateTime.UtcNow);

            repository.Insert(entity);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
