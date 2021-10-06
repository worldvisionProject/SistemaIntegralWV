using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Registro.Formularios.Queries.GetById;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Application.Features.Registro.Terceros.Commands.Create
{
    public class CreateTerceroCommand : IRequest<Result<int>>
    {
       
        public string Tipo { get; set; }
        public string Identificacion { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public DateTime? FecNacimiento { get; set; }
        public string? Genero { get; set; }
        public DateTime? VigDesde { get; set; }
        public DateTime? VigHasta { get; set; }

        public string CodigoArea { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }

        public int idFormulario { get; set; }
        public int IdColaborador { get; set; }
        public string TipoGrupo { get; set; }

        public byte[] ImageCedula { get; set; }
    }

    public class CreateTerceroCommandHandler : IRequestHandler<CreateTerceroCommand, Result<int>>
    {
        private readonly ITerceroRepository _terceroRepository;
        private readonly IFormularioTerceroRepository _fterceroRepository;
        private readonly IFormularioRepository _FormularioCache;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateTerceroCommandHandler(IFormularioRepository formularioCache,IFormularioTerceroRepository fterceroRepository,ITerceroRepository terceroRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _terceroRepository = terceroRepository;
            _fterceroRepository = fterceroRepository;
            _FormularioCache = formularioCache;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateTerceroCommand request, CancellationToken cancellationToken)
        {
            var formulario = await _FormularioCache.GetByIdFormularioAsync(request.idFormulario);
           // var mappedColaborador = _mapper.Map<GetFormularioByIdResponse>(Colaborador);

            var tercero = _mapper.Map<Tercero>(request);
            var inter = new FormularioTercero();
            inter.Terceros = tercero;
            inter.Formularios = formulario;
            inter.Tipo = request.TipoGrupo;

            await _terceroRepository.InsertAsync(tercero);
            await _fterceroRepository.InsertAsync(inter);
            
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(tercero.Id);
        }
    }
}
