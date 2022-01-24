using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.DTOs.Valoracion;
using WordVision.ec.Application.Interfaces.Repositories.Valoracion;

namespace WordVision.ec.Application.Features.Valoracion.Responsabilidades.Queries.GetAll
{
    public class GetAllResponsabilidadQuery : IRequest<Result<List<ResponsabilidadResponse>>>
    {
        public int IdObjetivoAnioFiscal { get; set; }
        public int IdEstructura { get; set; }
        public GetAllResponsabilidadQuery()
        {
        }
    }

    public class GetAllResponsabilidadQueryHandler : IRequestHandler<GetAllResponsabilidadQuery, Result<List<ResponsabilidadResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly IResponsabilidadRepository _repository;


        public GetAllResponsabilidadQueryHandler(IResponsabilidadRepository planificacionRepository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = planificacionRepository;
        }



        public async Task<Result<List<ResponsabilidadResponse>>> Handle(GetAllResponsabilidadQuery request, CancellationToken cancellationToken)
        {
            var obj = await _repository.GetListPadreAsync(request.IdEstructura,request.IdObjetivoAnioFiscal);
            var mapped = _mapper.Map<List<ResponsabilidadResponse>>(obj);

            return Result<List<ResponsabilidadResponse>>.Success(mapped);
        }
    }

}
