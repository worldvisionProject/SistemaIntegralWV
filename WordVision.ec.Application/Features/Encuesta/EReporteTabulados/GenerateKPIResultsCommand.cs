using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;
using System.Collections.Generic;

namespace WordVision.ec.Application.Features.Encuesta.EReporteTabulados
{
    public class GenerateKPIResultsCommand : IRequest<Result<int>>
    {
        public int evaluacionId { get; set; }

        public class GenerateKPIResultsCommandHandler : IRequestHandler<GenerateKPIResultsCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IEReporteTabuladoRepository _eReporteTabuladoRepository;
            private readonly IERegionRepository _eRegionRepository;
            private readonly IEProvinciaRepository _eProvinciaRepository;
            private readonly IECantonRepository _eCantonRepository;
            private readonly IEEvaluacionRepository _eEvaluacionRepository;
            private readonly IEProgramaRepository _eProgramaRepository;
            private readonly IEIndicadorRepository _eIndicadorRepository;
            private readonly IMapper _mapper;

            public GenerateKPIResultsCommandHandler(    IEReporteTabuladoRepository eReporteTabuladoRepository,
                                                        IERegionRepository eRegionRepository,
                                                        IEProvinciaRepository eProvinciaRepository,
                                                        IECantonRepository eCantonRepository,

                                                        IEEvaluacionRepository eEvaluacionRepository,
                                                        IEProgramaRepository eProgramaRepository,
                                                        IEIndicadorRepository eIndicadorRepository,

                                                        IUnitOfWork unitOfWork, 
                                                        IMapper mapper)
            {
                _eReporteTabuladoRepository = eReporteTabuladoRepository;
                _eRegionRepository = eRegionRepository;
                _eProvinciaRepository = eProvinciaRepository;
                _eCantonRepository = eCantonRepository;
                _eEvaluacionRepository = eEvaluacionRepository;
                _eProgramaRepository = eProgramaRepository;
                _eIndicadorRepository = eIndicadorRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            //En el objeto command se encuentra la información del registro recibido de los cambios
            //las propiedades de command son las propiedades que estan declaradas arriba en este mismo documento
            public async Task<Result<int>> Handle(GenerateKPIResultsCommand command, CancellationToken cancellationToken)
            {
                int numRegistrosInsertados = 0;

                //Eliminamos toda la información del ReporteTAbulado de la evaluacion recibida
                await _eReporteTabuladoRepository.DeleteAllAsync(command.evaluacionId);
                await _unitOfWork.Commit(cancellationToken);

                //Generamos los resultadzos con el EvaluacionId recibido.  (Con la mayoria de los indicadores)
                List<ETabulado> responseKPI = new List<ETabulado>();
                responseKPI = await _eReporteTabuladoRepository.GenerateResultsListAsync(command.evaluacionId);
                if (responseKPI != null && responseKPI.Count > 0)
                {
                    foreach (ETabulado fila in responseKPI)
                    {
                        //Antes de insertar traemos los clases 
                        ERegion eRegion = await _eRegionRepository.GetByIdAsync(fila.CodigoRegion);
                        EProvincia eProvincia = await _eProvinciaRepository.GetByIdAsync(fila.CodigoProvincia);
                        ECanton eCanton = await _eCantonRepository.GetByIdAsync(fila.CodigoCanton);

                        EEvaluacion eEvaluacion = await _eEvaluacionRepository.GetByIdAsync(command.evaluacionId);
                        EPrograma ePrograma = await _eProgramaRepository.GetByIdAsync(fila.CodigoPA);
                        EIndicador eIndicador = await _eIndicadorRepository.GetByIdAsync(fila.CodigoIndicador);

                        if (eIndicador == null) throw new ArgumentException("No se ha encontrado el indicador " + fila.CodigoIndicador.ToString());
                        if (ePrograma == null) throw new ArgumentException("No se ha encontrado el PA " + fila.CodigoPA.ToString());
                        if (eEvaluacion == null) throw new ArgumentException("No se ha encontrado la evaluación " + command.evaluacionId.ToString());

                        if (eRegion == null) throw new ArgumentException("No se ha encontrado la región " + fila.CodigoRegion.ToString());
                        if (eProvincia == null) throw new ArgumentException("No se ha encontrado la provincia " + fila.CodigoProvincia.ToString());
                        if (eCanton == null) throw new ArgumentException("No se ha encontrado el cantón " + fila.CodigoCanton.ToString());

                        //Insertar en la base de datos.
                        EReporteTabulado eReporteTabulado = new EReporteTabulado();
                        eReporteTabulado.rta_nombre_indicador = fila.Indicador;
                        eReporteTabulado.rta_tipo_indicador = fila.TipoIndicador;
                        eReporteTabulado.rta_Operacion = eIndicador.ind_Operacion;
                        eReporteTabulado.rta_nombre_pa = fila.PA;
                        eReporteTabulado.rta_numerador = fila.NumeroTotal;
                        eReporteTabulado.rta_denominador = fila.EntrevistadosTotal;
                        eReporteTabulado.rta_porcentaje = Convert.ToDecimal(fila.Porcentaje);
                        eReporteTabulado.rta_resultado = fila.Result;
                        eReporteTabulado.EEvaluacion = eEvaluacion;
                        eReporteTabulado.EPrograma = ePrograma;
                        eReporteTabulado.EIndicador = eIndicador;
                        eReporteTabulado.ERegion = eRegion;
                        eReporteTabulado.EProvincia = eProvincia;
                        eReporteTabulado.ECanton = eCanton;

                        await _eReporteTabuladoRepository.InsertAsync(eReporteTabulado);  //Insertar a la BBDD
                        numRegistrosInsertados++;
                    }
                    await _unitOfWork.Commit(cancellationToken);
                }


                //Generamos los resultadzos con el EvaluacionId recibido.  (Con la mayoria de los indicadores COMPLEJOS)
                List<ETabulado> responseKPIComplejos = new List<ETabulado>();
                responseKPIComplejos = await _eReporteTabuladoRepository.GenerateResultsComplejosListAsync(command.evaluacionId);
                if (responseKPIComplejos != null && responseKPIComplejos.Count > 0)
                {
                    foreach (ETabulado fila in responseKPIComplejos)
                    {
                        //Antes de insertar traemos los clases 
                        ERegion eRegion = await _eRegionRepository.GetByIdAsync(fila.CodigoRegion);
                        EProvincia eProvincia = await _eProvinciaRepository.GetByIdAsync(fila.CodigoProvincia);
                        ECanton eCanton = await _eCantonRepository.GetByIdAsync(fila.CodigoCanton);

                        EEvaluacion eEvaluacion = await _eEvaluacionRepository.GetByIdAsync(command.evaluacionId);
                        EPrograma ePrograma = await _eProgramaRepository.GetByIdAsync(fila.CodigoPA);
                        EIndicador eIndicador = await _eIndicadorRepository.GetByIdAsync(fila.CodigoIndicador);

                        if (eIndicador == null) throw new ArgumentException("No se ha encontrado el indicador " + fila.CodigoIndicador.ToString());
                        if (ePrograma == null) throw new ArgumentException("No se ha encontrado el PA " + fila.CodigoPA.ToString());
                        if (eEvaluacion == null) throw new ArgumentException("No se ha encontrado la evaluación " + command.evaluacionId.ToString());

                        if (eRegion == null) throw new ArgumentException("No se ha encontrado la región " + fila.CodigoRegion.ToString());
                        if (eProvincia == null) throw new ArgumentException("No se ha encontrado la provincia " + fila.CodigoProvincia.ToString());
                        if (eCanton == null) throw new ArgumentException("No se ha encontrado el cantón " + fila.CodigoCanton.ToString());

                        //Insertar en la base de datos.
                        EReporteTabulado eReporteTabulado = new EReporteTabulado();
                        eReporteTabulado.rta_nombre_indicador = fila.Indicador;
                        eReporteTabulado.rta_tipo_indicador = fila.TipoIndicador;
                        eReporteTabulado.rta_Operacion = eIndicador.ind_Operacion;
                        eReporteTabulado.rta_nombre_pa = fila.PA;
                        eReporteTabulado.rta_numerador = fila.NumeroTotal;
                        eReporteTabulado.rta_denominador = fila.EntrevistadosTotal;
                        eReporteTabulado.rta_porcentaje = Convert.ToDecimal(fila.Porcentaje);
                        eReporteTabulado.rta_resultado = fila.Result;
                        eReporteTabulado.EEvaluacion = eEvaluacion;
                        eReporteTabulado.EPrograma = ePrograma;
                        eReporteTabulado.EIndicador = eIndicador;
                        eReporteTabulado.ERegion = eRegion;
                        eReporteTabulado.EProvincia = eProvincia;
                        eReporteTabulado.ECanton = eCanton;

                        await _eReporteTabuladoRepository.InsertAsync(eReporteTabulado);  //Insertar a la BBDD
                        numRegistrosInsertados++;
                    }
                    await _unitOfWork.Commit(cancellationToken);
                }


                //Generamos los resultadzos con el EvaluacionId recibido.  (Con la mayoria de los indicadores DAP)
                List<ETabulado> responseKPIDAP = new List<ETabulado>();
                responseKPIDAP = await _eReporteTabuladoRepository.GenerateResultsDAPListAsync(command.evaluacionId);
                if (responseKPIDAP != null && responseKPIDAP.Count > 0)
                {
                    foreach (ETabulado fila in responseKPIDAP)
                    {
                        //Antes de insertar traemos los clases 
                        ERegion eRegion = await _eRegionRepository.GetByIdAsync(fila.CodigoRegion);
                        EProvincia eProvincia = await _eProvinciaRepository.GetByIdAsync(fila.CodigoProvincia);
                        ECanton eCanton = await _eCantonRepository.GetByIdAsync(fila.CodigoCanton);

                        EEvaluacion eEvaluacion = await _eEvaluacionRepository.GetByIdAsync(command.evaluacionId);
                        EPrograma ePrograma = await _eProgramaRepository.GetByIdAsync(fila.CodigoPA);
                        EIndicador eIndicador = await _eIndicadorRepository.GetByIdAsync(fila.CodigoIndicador);

                        if (eIndicador == null) throw new ArgumentException("No se ha encontrado el indicador " + fila.CodigoIndicador.ToString());
                        if (ePrograma == null) throw new ArgumentException("No se ha encontrado el PA " + fila.CodigoPA.ToString());
                        if (eEvaluacion == null) throw new ArgumentException("No se ha encontrado la evaluación " + command.evaluacionId.ToString());

                        if (eRegion == null) throw new ArgumentException("No se ha encontrado la región " + fila.CodigoRegion.ToString());
                        if (eProvincia == null) throw new ArgumentException("No se ha encontrado la provincia " + fila.CodigoProvincia.ToString());
                        if (eCanton == null) throw new ArgumentException("No se ha encontrado el cantón " + fila.CodigoCanton.ToString());

                        //Insertar en la base de datos.
                        EReporteTabulado eReporteTabulado = new EReporteTabulado();
                        eReporteTabulado.rta_nombre_indicador = fila.Indicador;
                        eReporteTabulado.rta_tipo_indicador = fila.TipoIndicador;
                        eReporteTabulado.rta_Operacion = eIndicador.ind_Operacion;
                        eReporteTabulado.rta_nombre_pa = fila.PA;
                        eReporteTabulado.rta_numerador = fila.NumeroTotal;
                        eReporteTabulado.rta_denominador = fila.EntrevistadosTotal;
                        eReporteTabulado.rta_porcentaje = Convert.ToDecimal(fila.Porcentaje);
                        eReporteTabulado.rta_resultado = fila.Result;
                        eReporteTabulado.EEvaluacion = eEvaluacion;
                        eReporteTabulado.EPrograma = ePrograma;
                        eReporteTabulado.EIndicador = eIndicador;
                        eReporteTabulado.ERegion = eRegion;
                        eReporteTabulado.EProvincia = eProvincia;
                        eReporteTabulado.ECanton = eCanton;

                        await _eReporteTabuladoRepository.InsertAsync(eReporteTabulado);  //Insertar a la BBDD
                        numRegistrosInsertados++;
                    }
                    await _unitOfWork.Commit(cancellationToken);
                }



                //Generamos los resultadzos con el EvaluacionId recibido.  (Con la mayoria de los indicadores NACIONALES)
                List<ETabulado> responseKPINacionales = new List<ETabulado>();
                responseKPINacionales = await _eReporteTabuladoRepository.GenerateResultsNacionalesListAsync(command.evaluacionId);
                if (responseKPINacionales != null && responseKPINacionales.Count > 0)
                {
                    foreach (ETabulado fila in responseKPINacionales)
                    {
                        //Antes de insertar traemos los clases 
                        ERegion eRegion = await _eRegionRepository.GetByIdAsync(fila.CodigoRegion);
                        EProvincia eProvincia = await _eProvinciaRepository.GetByIdAsync(fila.CodigoProvincia);
                        ECanton eCanton = await _eCantonRepository.GetByIdAsync(fila.CodigoCanton);

                        EEvaluacion eEvaluacion = await _eEvaluacionRepository.GetByIdAsync(command.evaluacionId);
                        EPrograma ePrograma = await _eProgramaRepository.GetByIdAsync(fila.CodigoPA);
                        EIndicador eIndicador = await _eIndicadorRepository.GetByIdAsync(fila.CodigoIndicador);

                        if (eIndicador == null) throw new ArgumentException("No se ha encontrado el indicador " + fila.CodigoIndicador.ToString());
                        if (ePrograma == null) throw new ArgumentException("No se ha encontrado el PA " + fila.CodigoPA.ToString());
                        if (eEvaluacion == null) throw new ArgumentException("No se ha encontrado la evaluación " + command.evaluacionId.ToString());

                        if (eRegion == null) throw new ArgumentException("No se ha encontrado la región " + fila.CodigoRegion.ToString());
                        if (eProvincia == null) throw new ArgumentException("No se ha encontrado la provincia " + fila.CodigoProvincia.ToString());
                        if (eCanton == null) throw new ArgumentException("No se ha encontrado el cantón " + fila.CodigoCanton.ToString());

                        //Insertar en la base de datos.
                        EReporteTabulado eReporteTabulado = new EReporteTabulado();
                        eReporteTabulado.rta_nombre_indicador = fila.Indicador;
                        eReporteTabulado.rta_tipo_indicador = fila.TipoIndicador;
                        eReporteTabulado.rta_Operacion = eIndicador.ind_Operacion;
                        eReporteTabulado.rta_nombre_pa = fila.PA;
                        eReporteTabulado.rta_numerador = fila.NumeroTotal;
                        eReporteTabulado.rta_denominador = fila.EntrevistadosTotal;
                        eReporteTabulado.rta_porcentaje = Convert.ToDecimal(fila.Porcentaje);
                        eReporteTabulado.rta_resultado = fila.Result;
                        eReporteTabulado.EEvaluacion = eEvaluacion;
                        eReporteTabulado.EPrograma = ePrograma;
                        eReporteTabulado.EIndicador = eIndicador;
                        eReporteTabulado.ERegion = eRegion;
                        eReporteTabulado.EProvincia = eProvincia;
                        eReporteTabulado.ECanton = eCanton;

                        await _eReporteTabuladoRepository.InsertAsync(eReporteTabulado);  //Insertar a la BBDD
                        numRegistrosInsertados++;
                    }
                    await _unitOfWork.Commit(cancellationToken);
                }


                return Result<int>.Success(numRegistrosInsertados);
            }
        }


    }
}
