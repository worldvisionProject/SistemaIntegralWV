using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.DTOs.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Features.Maestro.Catalogos.Commands.Create
{
   public  class CreateCatalogoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }
        public ICollection<DetalleCatalogoResponse> DetalleCatalogos { get; set; }
    }

    public class CreateCatalogoCommandHandler : IRequestHandler<CreateCatalogoCommand, Result<int>>
    {
        private readonly ICatalogoRepository _EstructuraRepository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateCatalogoCommandHandler(ICatalogoRepository EstructuraRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _EstructuraRepository = EstructuraRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateCatalogoCommand request, CancellationToken cancellationToken)
        {
            var estructura = _mapper.Map<Catalogo>(request);
            await _EstructuraRepository.InsertAsync(estructura);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(estructura.Id);
        }
    }
}
