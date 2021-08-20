using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Planificacion.ObjetivoEstrategicoes.Commands.Update
{
    public class UpdateObjetivoEstrategicoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public int Categoria { get; set; }
        public int AreaPrioridad { get; set; }
        public int Dimension { get; set; }

        public int CargoResponsable { get; set; }

        public int IdEstrategia { get; set; }
        public string Programa { get; set; }
        public string Cwbo { get; set; }


        public class UpdateProductCommandHandler : IRequestHandler<UpdateObjetivoEstrategicoCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IObjetivoEstrategicoRepository _ObjetivoEstrategicoRepository;

            public UpdateProductCommandHandler(IObjetivoEstrategicoRepository ObjetivoEstrategicoRepository, IUnitOfWork unitOfWork)
            {
                _ObjetivoEstrategicoRepository = ObjetivoEstrategicoRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(UpdateObjetivoEstrategicoCommand command, CancellationToken cancellationToken)
            {
                var ObjetivoEstrategico = await _ObjetivoEstrategicoRepository.GetByIdAsync(command.Id);

                if (ObjetivoEstrategico == null)
                {
                    return Result<int>.Fail($"ObjetivoEstrategico no encontrado.");
                }
                else
                {
                    ObjetivoEstrategico.Descripcion = command.Descripcion;
                    ObjetivoEstrategico.Categoria = command.Categoria;
                    ObjetivoEstrategico.AreaPrioridad = command.AreaPrioridad;
                    ObjetivoEstrategico.Dimension = command.Dimension;
                    ObjetivoEstrategico.CargoResponsable = command.CargoResponsable;
                    ObjetivoEstrategico.Programa = command.Programa;
                    ObjetivoEstrategico.Cwbo = command.Cwbo;

                    await _ObjetivoEstrategicoRepository.UpdateAsync(ObjetivoEstrategico);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(ObjetivoEstrategico.Id);
                }
            }
        }

    }
}
