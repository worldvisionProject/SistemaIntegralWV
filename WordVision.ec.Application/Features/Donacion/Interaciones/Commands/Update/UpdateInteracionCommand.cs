using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Donacion;
using WordVision.ec.Application.Interfaces.Repositories.Identity;

namespace WordVision.ec.Application.Features.Donacion.Interaciones.Commands.Update
{
    public class UpdateInteracionCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public int Gestion { get; set; }

        public int Tipo { get; set; }

        public string Observacion { get; set; }




        public class UpdateInteracionCommandHandler : IRequestHandler<UpdateInteracionCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IInteracionRepository _interacionRepository;
            private readonly IMapper _mapper;

            public UpdateInteracionCommandHandler(IInteracionRepository interacionRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _interacionRepository = interacionRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public Task<Result<int>> Handle(UpdateInteracionCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }

}
