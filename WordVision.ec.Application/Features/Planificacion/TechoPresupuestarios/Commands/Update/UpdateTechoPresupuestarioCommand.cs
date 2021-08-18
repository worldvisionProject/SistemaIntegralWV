using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.TechoPresupuestarios.Commands.Update
{
    public class UpdateTechoPresupuestarioCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string CodigoCC { get; set; }
        public string DescripcionCC { get; set; }
        public decimal? Techo { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateTechoPresupuestarioCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ITechoPresupuestarioRepository _techoPresupuestarioRepository;
            private readonly IMapper _mapper;

            public UpdateProductCommandHandler( ITechoPresupuestarioRepository TechoPresupuestarioRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _techoPresupuestarioRepository = TechoPresupuestarioRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Result<int>> Handle(UpdateTechoPresupuestarioCommand command, CancellationToken cancellationToken)
            {
                var techoPresupuestario = await _techoPresupuestarioRepository.GetByIdAsync(command.Id);

                if (techoPresupuestario == null)
                {
                    return Result<int>.Fail($"techoPresupuestario no encontrado.");
                }
                else
                {


                    techoPresupuestario.CodigoCC = command.CodigoCC;
                    techoPresupuestario.DescripcionCC = command.DescripcionCC;
                    techoPresupuestario.Techo = command.Techo;
                     await _techoPresupuestarioRepository.UpdateAsync(techoPresupuestario);
                    

                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(techoPresupuestario.Id);
                }
            }
        }

    }
}
