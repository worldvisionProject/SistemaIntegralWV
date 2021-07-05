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

namespace WordVision.ec.Application.Features.Presupuesto.DatosT5.Commands.Create
{
    public partial class CreateDatosT5Command : IRequest<Result<int>>
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Cuentasop { get; set; }
        public string T2 { get; set; }
        public string DescripcionT2 { get; set; }
        public int Tipo { get; set; }
    }

    public class CreateDatosT5CommandHandler : IRequestHandler<CreateDatosT5Command, Result<int>>
    {
        private readonly IDatosT5Repository _datosT5Repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateDatosT5CommandHandler(IDatosT5Repository datosT5Repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _datosT5Repository = datosT5Repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateDatosT5Command request, CancellationToken cancellationToken)
        {
            var datosT5 = _mapper.Map<WordVision.ec.Domain.Entities.Presupuesto.DatosT5>(request);
            await _datosT5Repository.InsertAsync(datosT5);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(datosT5.Id);
        }
    }
}
