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

namespace WordVision.ec.Application.Features.Planificacion.IndicadorCicloEstrategicos.Commands.Update
{
   
    public class UpdateIndicadorCicloEstrategicoCommand : IRequest<Result<int>>
    {
		public int Id { get; set; }
        public string IndicadorCiclo { get; set; }
        public int IdEstrategia { get; set; }
        public ICollection<MetaCicloEstrategico> MetaCicloEstrategicos { get; set; }
        public class UpdateIndicadorCicloEstrategicoCommandHandler : IRequestHandler<UpdateIndicadorCicloEstrategicoCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IIndicadorCicloEstrategicoRepository _entidadRepository;
            private readonly IMapper _mapper;

            public UpdateIndicadorCicloEstrategicoCommandHandler(IIndicadorCicloEstrategicoRepository entidadRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _entidadRepository = entidadRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Result<int>> Handle(UpdateIndicadorCicloEstrategicoCommand command, CancellationToken cancellationToken)
            {
                var obj = await _entidadRepository.GetByIdAsync(command.Id);

                if (obj == null)
                {
                    return Result<int>.Fail($"IndicadorCicloEstrategico no encontrado.");
                }


                obj.IndicadorCiclo = command.IndicadorCiclo;
                obj.IdEstrategia = command.IdEstrategia;
                

                await _entidadRepository.UpdateAsync(obj);


                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(obj.Id);

            }
        }

    }
}
