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

namespace WordVision.ec.Application.Features.Planificacion.Recursos.Commands.Create
{
    public partial class CreateRecursoCommand : IRequest<Result<int>>
    {
        public int CentroCosto { get; set; }
        public int CuentaCodigoCC { get; set; }
        public int CategoriaMercaderia { get; set; }
        public int Insumo { get; set; }
        public string ParaqueConsultoria { get; set; }
        public string Gtrm { get; set; }
        public string JustificacionConsultoria { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public decimal? Total { get; set; }
        public string DetalleInsumo { get; set; }
        public int IdActividad { get; set; }
        public ICollection<FechaCantidadRecurso> FechaCantidadRecursos { get; set; }
    }

    public class CreateRecursoCommandHandler : IRequestHandler<CreateRecursoCommand, Result<int>>
    {
        private readonly IRecursoRepository _recursoRepository;
        private readonly IFechaCantidadRecursoRepository _fechaRepository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateRecursoCommandHandler(IFechaCantidadRecursoRepository fechaRepository, IRecursoRepository recursoRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _recursoRepository = recursoRepository;
            _fechaRepository = fechaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateRecursoCommand request, CancellationToken cancellationToken)
        {
            var recurso = _mapper.Map<Recurso>(request);
            await _recursoRepository.InsertAsync(recurso);

            foreach (var a in request.FechaCantidadRecursos)
            {
                var fecha = _mapper.Map<FechaCantidadRecurso>(a);
                fecha.IdRecurso = recurso.Id;
                await _fechaRepository.InsertAsync(fecha);
            }

            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(recurso.Id);
        }
    }


}
