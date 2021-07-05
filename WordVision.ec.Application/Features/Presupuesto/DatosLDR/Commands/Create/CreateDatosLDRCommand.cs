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

namespace WordVision.ec.Application.Features.Presupuesto.DatosLDR.Commands.Create
{
    public partial class CreateDatosLDRCommand : IRequest<Result<int>>
    {
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Area { get; set; }
        public string Cargo { get; set; }

        public string Ubicacion { get; set; }
        public string T0 { get; set; }
        public string T1 { get; set; }
        public string T2 { get; set; }
        public string T3 { get; set; }
        public string T4 { get; set; }
        public string T5 { get; set; }
        public string T6 { get; set; }
        public string T7 { get; set; }
        public string T8 { get; set; }
        public string T9 { get; set; }
        public string FijoEventual { get; set; }
        public decimal Ldr { get; set; }
    }

    public class CreateDatosLDRCommandHandler : IRequestHandler<CreateDatosLDRCommand, Result<int>>
    {
        private readonly IDatosLDRRepository _datosLDRRepository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateDatosLDRCommandHandler(IDatosLDRRepository datosLDRRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _datosLDRRepository = datosLDRRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateDatosLDRCommand request, CancellationToken cancellationToken)
        {
            var datosLDR = _mapper.Map<WordVision.ec.Domain.Entities.Presupuesto.DatosLDR>(request);
            await _datosLDRRepository.InsertAsync(datosLDR);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(datosLDR.Id);
        }
    }
}
