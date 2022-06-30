using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Donacion.Debitos.Queries.GetById;
using WordVision.ec.Application.Interfaces.Repositories.Donacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;
using WordVision.ec.Domain.Entities.Donacion;

namespace WordVision.ec.Application.Features.Donacion.Debitos.Commands.Create
{
    public partial class CreateDebitoCommand : IRequest<Result<int>>
    {
        public List<GetDebitosByIdResponse> ListaDebitos { get; set; }
        public int CodigoBanco { get; set; }

        public int Anio { get; set; }

        public int Mes { get; set; }


        //public int Quincena { get; set; }


        public int Intento { get; set; }

        public decimal? Valor { get; set; }
        public int? CodigoRespuesta { get; set; }
        public int? Estado { get; set; }

        public int IdDonante { get; set; }
    }
    public class CreateDebitoCommandHandler : IRequestHandler<CreateDebitoCommand, Result<int>>
    {
        private readonly IDebitoRepository _debitoRepository;


        private readonly IMapper _mapper;//coge los campos de la interfaz con la bbdd hace un mapeo

        private IUnitOfWork _unitOfWork { get; set; }// hace la transaccionabilidad crea la cabecera y luego detalle



        public CreateDebitoCommandHandler(IDebitoRepository debitoRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _debitoRepository = debitoRepository;

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        //ejecuta directamene desde a interfaz el controaldor
        public async Task<Result<int>> Handle(CreateDebitoCommand request, CancellationToken cancellationToken)
        {
            foreach(var item in request.ListaDebitos)
            {
                var debito = _mapper.Map<Debito>(item);//mapea
            await _debitoRepository.InsertAsync(debito);//INsertar a la BBDD

            }


            await _unitOfWork.Commit(cancellationToken);//commit
            return Result<int>.Success(1);//devuelve le id existoso de la persona
        }
    }

}
