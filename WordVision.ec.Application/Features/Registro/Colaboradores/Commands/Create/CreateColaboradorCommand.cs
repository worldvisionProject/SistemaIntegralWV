using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Application.Features.Registro.Colaboradores.Commands.Create
{
  
    public partial class CreateColaboradorCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Apellidos { get; set; }
        public string ApellidoMaterno { get; set; }
        public string PrimerNombre { get; set; }

        public string SegundoNombre { get; set; }

        public string Identificacion { get; set; }

        public string Email { get; set; }
        public string Cargo { get; set; }

         public string Area { get; set; }

        public string LugarTrabajo { get; set; }


    }

    public class CreateColaboradorCommandHandler : IRequestHandler<CreateColaboradorCommand, Result<int>>
    {
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateColaboradorCommandHandler(IColaboradorRepository colaboradorRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _colaboradorRepository = colaboradorRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateColaboradorCommand request, CancellationToken cancellationToken)
        {
            var colaborador = _mapper.Map<Colaborador>(request);
            await _colaboradorRepository.InsertAsync(colaborador);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(colaborador.Id);
        }
    }
}
