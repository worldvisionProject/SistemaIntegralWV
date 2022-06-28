using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace WordVision.ec.Application.Features.Encuesta.EncuestaKobos
{
    public class SyncEncuestaKoboCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class SyncEncuestaKoboCommandHandler : IRequestHandler<SyncEncuestaKoboCommand, Result<int>>
        {
            private readonly IEncuestaKoboRepository _encuestaKoboRepository;
            private readonly IPreguntaKoboRepository _preguntaKoboRepository;
            private readonly IEncuestadoKoboRepository _encuestadoKoboRepository;
            private readonly IEncuestadoPreguntaKoboRepository _encuestadoPreguntaKoboRepository;

            private readonly IERegionRepository _eRegionRepository;
            private readonly IEProvinciaRepository _eProvinciaRepository;
            private readonly IECantonRepository _eCantonRepository;
            private readonly IEParroquiaRepository _eParroquiaRepository;

            private readonly IUnitOfWork _unitOfWork;

            public SyncEncuestaKoboCommandHandler(  IEncuestaKoboRepository encuestaKoboRepository, 
                                                    IPreguntaKoboRepository preguntaKoboRepository, 
                                                    IEncuestadoKoboRepository encuestadoKoboRepository, 
                                                    IEncuestadoPreguntaKoboRepository encuestadoPreguntaKoboRepository,
                                                    IERegionRepository eRegionRepository,
                                                    IEProvinciaRepository eProvinciaRepository,
                                                    IECantonRepository eCantonRepository,
                                                    IEParroquiaRepository eParroquiaRepository,
                                                    IUnitOfWork unitOfWork)
            {
                _encuestaKoboRepository = encuestaKoboRepository;
                _preguntaKoboRepository = preguntaKoboRepository;
                _encuestadoKoboRepository = encuestadoKoboRepository;
                _encuestadoPreguntaKoboRepository = encuestadoPreguntaKoboRepository;
                _eRegionRepository = eRegionRepository;
                _eProvinciaRepository = eProvinciaRepository;
                _eCantonRepository = eCantonRepository;
                _eParroquiaRepository = eParroquiaRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(SyncEncuestaKoboCommand command, CancellationToken cancellationToken)
            {
                var encuestaKoboModel = await _encuestaKoboRepository.GetByIdAsync(command.Id);
                int numRegistrosInsertados = 0;

                using (var httpCliente = new HttpClient())
                {
                    //Ponemos la seguridad en la cabecera
                    Encoding ascii = Encoding.ASCII;
                    httpCliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(ascii.GetBytes("super_admin" + ":" + "wve**Bio*_?2022")));

                    //Consultamos el ultimo secuencial de la tabla EncuestadoPreguntaKobo de la encuesta seleccionada
                    int UltimoSecuencial = await _encuestadoKoboRepository.GetLastIdAsync(command.Id) + 1;

                    //Ejecutamos la consulta del API
                    string url = "https://kc.visionmundial.org.ec/api/v1/data/" + command.Id.ToString() + "?query={\"_id\":{\"$gt\":" + UltimoSecuencial.ToString() + "}}&sort={\"_id\":\"1\"}";
                    using var respuesta = await httpCliente.GetAsync(url);
                    string respuestaAPI = await respuesta.Content.ReadAsStringAsync();

                    //************* De la respuesta del API le ponemos en una variable dinamica
                    dynamic d1 = new List<JArray>();
                    d1 = JArray.Parse(respuestaAPI);
                    if (d1.Count > 0)
                    {

                        //************* Mapeamos el resultado del API en la clase modelo para que posteriormente se inserte en la base de datos
                        JArray d2 = JArray.Parse(respuestaAPI);
                        IList<EncuestadoKobo> syncEncuestadoKoboJS = d2.Select(p => new EncuestadoKobo
                        {
                            Id = (int)p["_id"],
                            eko_xform_id_string = Convert.ToString(p["_xform_id_string"]),
                            eko_formhub = Convert.ToString(p["formhub/uuid"]),
                            eko_start = Convert.ToDateTime(p["start"]),
                            eko_end = Convert.ToDateTime(p["end"]),
                            eko_today = Convert.ToDateTime(p["today"]),
                            eko_deviceid = Convert.ToString(p["deviceid"]),
                            eko_imei = Convert.ToString(p["imei"]),
                            eko_username = Convert.ToString(p["username"]),
                            //eko_secuencial = (string)p["encuesta_hogar/secuencial"],
                            eko_secuencial = (string)p["encuesta_hogar/fa0" + Convert.ToString(7 - command.Id + 1) + "_secuencial"],
                            eko_pa = Convert.ToString(p["encuesta_hogar/pa"]),
                            eko_region = Convert.ToString("1"),
                            eko_provincia = Convert.ToString("1"),
                            eko_canton = Convert.ToString("1"),
                            eko_parroquia = Convert.ToString(p["encuesta_hogar/parroquia"]),
                            eko_comunidad = Convert.ToString(p["encuesta_hogar/comunidad"]),
                            eko_desastre = Convert.ToString(p["encuesta_hogar/desastre"]),
                            eko_nombre_encuestador = Convert.ToString(p["encuesta_hogar/Encuestador"]),
                            eko_fecha = Convert.ToDateTime(p["encuesta_hogar/Fecha"]),
                            eko_ref_vivienda = Convert.ToString(p["encuesta_hogar/RefVivienda"]),
                            eko_nombre_nino = " ",
                            eko_sexo = " ",
                            eko_patrocinio = " ",
                            eko_status = Convert.ToString(p["_status"]),
                            EncuestaKobo = encuestaKoboModel
                        }).ToList();

                        //************* Vamos a iterar con todos los registros para insertar en EncuestadoKobos
                        foreach (EncuestadoKobo fila in syncEncuestadoKoboJS)
                        {
                            if (Convert.ToString(fila.eko_parroquia).Trim().Length > 0)
                            {
                                //Antes de insertar actualizamos los campos region, canton, parroquia
                                EParroquia eParroquia = await _eParroquiaRepository.GetByIdAsync(fila.eko_parroquia);
                                ECanton eCanton = await _eCantonRepository.GetByIdAsync(eParroquia.ECanton.Id);
                                EProvincia eProvincia = await _eProvinciaRepository.GetByIdAsync(eCanton.EProvincia.Id);
                                ERegion eRegion = await _eRegionRepository.GetByIdAsync(eProvincia.eRegion.Id);

                                fila.eko_region = Convert.ToString(eRegion.Id);
                                fila.eko_provincia = eProvincia.Id;
                                fila.eko_canton = eCanton.Id;
                            }

                            //Insertar en la base de datos.
                            await _encuestadoKoboRepository.InsertAsync(fila);  //Insertar a la BBDD
                            numRegistrosInsertados++;
                        }
                        await _unitOfWork.Commit(cancellationToken);


                        //Vamos a iterar con las propiedades para insertar en PreguntaKobos
                        //Pueden haber registros de encuestas con mas o con menos propiedades, dependera de como se conteste las preguntas
                        //Por este motivo se tiene que barrer todas los registros de respuesta y verificar si estan todas las propiedades insertadas en la tabla
                        foreach (var fila in d1)
                        {
                            foreach (JProperty property in fila.Properties())
                            {
                                PreguntaKobo preguntaKoboModel = await _preguntaKoboRepository.GetByNameAsync(encuestaKoboModel.Id, property.Name);
                                if (preguntaKoboModel == null)
                                {
                                    //Console.WriteLine(property.Name + " - " + property.Value);
                                    PreguntaKobo preguntaKobo = new PreguntaKobo();
                                    preguntaKobo.prk_CodigoKobo = property.Name;
                                    preguntaKobo.prk_Descripcion = "Pregunta " + property.Name;
                                    preguntaKobo.prk_CodigoWVE = " ";
                                    preguntaKobo.prk_Fecha = DateTime.Now;
                                    preguntaKobo.EncuestaKobo = encuestaKoboModel;

                                    await _preguntaKoboRepository.InsertAsync(preguntaKobo);  //Insertar a la BBDD
                                    await _unitOfWork.Commit(cancellationToken);
                                }
                            }
                        }


                        //Insertamos las respuestas
                        foreach (var fila in d1)
                        {
                            foreach (JProperty property in fila.Properties())
                            {
                                PreguntaKobo preguntaKoboModel = await _preguntaKoboRepository.GetByNameAsync(encuestaKoboModel.Id, property.Name);
                                EncuestadoKobo encuestadoKoboModel = await _encuestadoKoboRepository.GetByIdAsync(Convert.ToInt32(((Newtonsoft.Json.Linq.JValue)((Newtonsoft.Json.Linq.JProperty)((Newtonsoft.Json.Linq.JContainer)fila).First).Value).Value));

                                EncuestadoPreguntaKobo epk = new EncuestadoPreguntaKobo();
                                epk.Valor = Convert.ToString(property.Value);
                                epk.EncuestadoKobo = encuestadoKoboModel;
                                epk.PreguntaKobo = preguntaKoboModel;

                                await _encuestadoPreguntaKoboRepository.InsertAsync(epk);  //Insertar a la BBDD
                            }
                        }
                        await _unitOfWork.Commit(cancellationToken);


                    }

                    //Actualizamos la fecha de actualizacion de la encuesta
                    encuestaKoboModel.enk_Fecha = DateTime.Now;
                    await _encuestaKoboRepository.UpdateAsync(encuestaKoboModel);
                    await _unitOfWork.Commit(cancellationToken);

                }

                return Result<int>.Success(numRegistrosInsertados);
            }
        }

    }
}
