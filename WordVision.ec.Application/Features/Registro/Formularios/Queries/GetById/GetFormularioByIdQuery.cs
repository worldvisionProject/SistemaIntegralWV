using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.CacheRepositories;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Registro.Formularios.Queries.GetById
{
    public class GetFormularioByIdQuery : IRequest<Result<GetFormularioByIdResponse>>
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public class GetFormularioByIdQueryHandler : IRequestHandler<GetFormularioByIdQuery, Result<GetFormularioByIdResponse>>
        {
            private readonly IFormularioRepository _FormularioCache;
            private readonly ITerceroRepository _terceroCache;
            private readonly IMapper _mapper;

            public GetFormularioByIdQueryHandler(ITerceroRepository terceroCache, IFormularioRepository FormularioCache, IMapper mapper)
            {
                _FormularioCache = FormularioCache;
                _terceroCache = terceroCache;
                _mapper = mapper;
            }

            public async Task<Result<GetFormularioByIdResponse>> Handle(GetFormularioByIdQuery query, CancellationToken cancellationToken)
            {
                var formulario = await _FormularioCache.GetByIdAsync(query.Id);
                //if (formulario!=null)
                // formulario.FormularioTerceros= await _terceroCache.GetByIdFormularioAsync(formulario.Id, query.Tipo);
                var mappedColaborador = _mapper.Map<GetFormularioByIdResponse>(formulario);
                return Result<GetFormularioByIdResponse>.Success(mappedColaborador);
            }
        }
    }
}