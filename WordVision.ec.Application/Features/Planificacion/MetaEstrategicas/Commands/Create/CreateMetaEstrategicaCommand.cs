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

namespace WordVision.ec.Application.Features.Planificacion.MetaEstrategicas.Commands.Create
{
    public class CreateMetaEstrategicaCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public ICollection<MetaEstrategica> MetaEstrategicas { get; set; }
    }

    public class CreateMetaEstrategicaCommandHandler : IRequestHandler<CreateMetaEstrategicaCommand, Result<int>>
    {
        private readonly IMetaEstrategicaRepository _metaEstrategicaRepository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateMetaEstrategicaCommandHandler(IMetaEstrategicaRepository metaEstrategicaRepository,IUnitOfWork unitOfWork, IMapper mapper)
        {
            _metaEstrategicaRepository = metaEstrategicaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateMetaEstrategicaCommand request, CancellationToken cancellationToken)
        {
            
            foreach (var indicador in request.MetaEstrategicas)
            {
                var meta = _mapper.Map<MetaEstrategica>(indicador);
                await _metaEstrategicaRepository.InsertAsync(meta);
            }

            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success();
        }
    }
}
