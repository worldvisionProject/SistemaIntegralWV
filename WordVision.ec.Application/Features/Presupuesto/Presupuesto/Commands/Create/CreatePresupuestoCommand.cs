using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Presupuesto;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Presupuesto.Presupuesto.Commands.Create
{
    public partial class CreatePresupuestoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Tipo { get; set; }

        public string T5 { get; set; }

        public string DescripcionT5 { get; set; }

        public decimal Precio { get; set; }

        public decimal Cantidad { get; set; }

        public decimal Total { get; set; }

        public int TipoCargo { get; set; }


        public int Mes { get; set; }
        public int TodoAnio { get; set; }
    }

    public class CreatePresupuestoCommandHandler : IRequestHandler<CreatePresupuestoCommand, Result<int>>
    {
        private readonly IPresupuestoRepository _PresupuestoRepository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreatePresupuestoCommandHandler(IPresupuestoRepository PresupuestoRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _PresupuestoRepository = PresupuestoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreatePresupuestoCommand request, CancellationToken cancellationToken)
        {
            var presupuesto = _mapper.Map<WordVision.ec.Domain.Entities.Presupuesto.Presupuesto>(request);
            await _PresupuestoRepository.InsertAsync(presupuesto);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(presupuesto.Id);
        }
    }
}
