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

namespace WordVision.ec.Application.Features.Planificacion.ObjetivoEstrategicoes.Commands.Create
{
  
    public partial class CreateObjetivoEstrategicoCommand : IRequest<Result<int>>
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


    }

    public class CreateObjetivoEstrategicoCommandHandler : IRequestHandler<CreateObjetivoEstrategicoCommand, Result<int>>
    {
        private readonly IObjetivoEstrategicoRepository _ObjetivoEstrategicoRepository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateObjetivoEstrategicoCommandHandler(IObjetivoEstrategicoRepository ObjetivoEstrategicoRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _ObjetivoEstrategicoRepository = ObjetivoEstrategicoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateObjetivoEstrategicoCommand request, CancellationToken cancellationToken)
        {
            var ObjetivoEstrategico = _mapper.Map<ObjetivoEstrategico>(request);
            await _ObjetivoEstrategicoRepository.InsertAsync(ObjetivoEstrategico);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(ObjetivoEstrategico.Id);
        }
    }
}
