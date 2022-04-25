using System.Collections.Generic;

using WordVision.ec.Web.Areas.Registro.Models;
using WordVision.ec.Web.Areas.Valoracion.Models;

namespace WordVision.ec.Web.Areas.Valoracion.Pages.Objetivo.Wizard
{
    internal static class StepMapper
    {
        public static void EnrichClient(ObjetivoResponseViewModel contact, IEnumerable<StepViewModel> steps)
        {
            foreach (var step in steps)
            {
                //switch (step)
                //{
                //    case Objetivo_1Step s:
                //        contact.IdObjetivo = i.IdObjetivo,
                //        contact.NumeroObjetivo = i.Numero,
                //        contact.Objetivo = i.NombreObjetivo,
                //        contact.DescObjetivo = i.Descripcion,
                //        contact.IdObjetivoAnioFiscal = j.Id,
                //        contact.AnioFiscal = j.AnioFiscal,
                //        contact.PlanificacionResultados = j.PlanificacionResultados


                //        break;
                //    case Objetivo_2Step s:
                //        contact.IdObjetivo = i.IdObjetivo,
                //        contact.NumeroObjetivo = i.Numero,
                //        contact.Objetivo = i.NombreObjetivo,
                //        contact.DescObjetivo = i.Descripcion,
                //        contact.IdObjetivoAnioFiscal = j.Id,
                //        contact.AnioFiscal = j.AnioFiscal,
                //        contact.PlanificacionResultados = j.PlanificacionResultados

                //        break;

                    
                //}
            }
        }

        public static IEnumerable<StepViewModel> ToSteps(List<ObjetivoResponseViewModel> contact)
        {
            var d = new List<StepViewModel>();

            foreach (var i in contact)
            {

                foreach (var j in i.AnioFiscales)
                {
                    switch (i.Numero)
                    {
                        case "1":
                            d.Add(new Objetivo_1Step
                            { 
                                IdColaborador=i.IdColaborador,
                                IdObjetivo = i.IdObjetivo,
                                NumeroObjetivo = i.Numero,
                                Objetivo = i.NombreObjetivo,
                                DescObjetivo = i.Descripcion,
                                IdObjetivoAnioFiscal=j.Id,
                                AnioFiscal=j.AnioFiscal,
                                EstadoProceso = i.EstadoProceso,
                                DescEstadoProceso = i.DescEstadoProceso,
                                PonderacionObjetivo =j.Ponderacion,
                                PlanificacionResultados = j.PlanificacionResultados,
                                Perfil= i.Perfil,
                                ComentarioColaborador = i.ComentarioColaborador,
                                ComentarioLider1 = i.ComentarioLider1,
                                ComentarioLider2 = i.ComentarioLider2,
                                ComentarioLiderMatricial = i.ComentarioLiderMatricial,
                                ValorValoracionFinal = i.ValorValoracionFinal,
                                ValoracionFinal = i.ValoracionFinal,
                                ValoracionLider1 = i.ValoracionLider1
                            });
                            break;
                        case "2":
                            d.Add(new Objetivo_2Step
                            {
                                IdColaborador = i.IdColaborador,
                                IdObjetivo = i.IdObjetivo,
                                NumeroObjetivo = i.Numero,
                                Objetivo = i.NombreObjetivo,
                                DescObjetivo = i.Descripcion,
                                IdObjetivoAnioFiscal = j.Id,
                                AnioFiscal = j.AnioFiscal,
                                PonderacionObjetivo = j.Ponderacion,
                                PlanificacionResultados = j.PlanificacionResultados,
                                EstadoProceso = i.EstadoProceso,
                                DescEstadoProceso = i.DescEstadoProceso,
                                Perfil = i.Perfil,
                                ComentarioColaborador = i.ComentarioColaborador,
                                ComentarioLider1 = i.ComentarioLider1,
                                ComentarioLider2 = i.ComentarioLider2,
                                ComentarioLiderMatricial = i.ComentarioLiderMatricial,
                                ValorValoracionFinal = i.ValorValoracionFinal,
                                ValoracionFinal = i.ValoracionFinal,
                                ValoracionLider1 = i.ValoracionLider1
                            });
                            break;
                        case "3":
                            d.Add(new Objetivo_3Step
                            {
                                IdColaborador = i.IdColaborador,
                                IdObjetivo = i.IdObjetivo,
                                NumeroObjetivo = i.Numero,
                                Objetivo = i.NombreObjetivo,
                                DescObjetivo = i.Descripcion,
                                IdObjetivoAnioFiscal = j.Id,
                                AnioFiscal = j.AnioFiscal,
                                PonderacionObjetivo = j.Ponderacion,
                                PlanificacionResultados = j.PlanificacionResultados,
                                EstadoProceso = i.EstadoProceso,
                                DescEstadoProceso = i.DescEstadoProceso,
                                Perfil = i.Perfil,
                                ComentarioColaborador = i.ComentarioColaborador,
                                ComentarioLider1 = i.ComentarioLider1,
                                ComentarioLider2 = i.ComentarioLider2,
                                ComentarioLiderMatricial = i.ComentarioLiderMatricial,
                                ValorValoracionFinal = i.ValorValoracionFinal,
                                ValoracionFinal = i.ValoracionFinal,
                                ValoracionLider1 = i.ValoracionLider1

                            });
                            break;
                        case "4":
                            d.Add(new Objetivo_4Step
                            {
                                IdColaborador = i.IdColaborador,
                                IdObjetivo = i.IdObjetivo,
                                NumeroObjetivo = i.Numero,
                                Objetivo = i.NombreObjetivo,
                                DescObjetivo = i.Descripcion,
                                IdObjetivoAnioFiscal = j.Id,
                                AnioFiscal = j.AnioFiscal,
                                PonderacionObjetivo = j.Ponderacion,
                                PlanificacionResultados = j.PlanificacionResultados,
                                EstadoProceso = i.EstadoProceso,
                                DescEstadoProceso = i.DescEstadoProceso,
                                Perfil = i.Perfil,
                                ComentarioColaborador = i.ComentarioColaborador,
                                ComentarioLider1 = i.ComentarioLider1,
                                ComentarioLider2 = i.ComentarioLider2,
                                ComentarioLiderMatricial = i.ComentarioLiderMatricial,
                                ValorValoracionFinal = i.ValorValoracionFinal,
                                ValoracionFinal = i.ValoracionFinal,
                                ValoracionLider1 = i.ValoracionLider1

                            });
                            break;
                        case "5":
                            d.Add(new Objetivo_5Step
                            {
                                IdColaborador = i.IdColaborador,
                                IdObjetivo = i.IdObjetivo,
                                NumeroObjetivo = i.Numero,
                                Objetivo = i.NombreObjetivo,
                                DescObjetivo = i.Descripcion,
                                IdObjetivoAnioFiscal = j.Id,
                                AnioFiscal = j.AnioFiscal,
                                PonderacionObjetivo = j.Ponderacion,
                                PlanificacionResultados = j.PlanificacionResultados,
                                EstadoProceso = i.EstadoProceso,
                                DescEstadoProceso = i.DescEstadoProceso,
                                Perfil = i.Perfil,
                                ComentarioColaborador = i.ComentarioColaborador,
                                ComentarioLider1 = i.ComentarioLider1,
                                ComentarioLider2 = i.ComentarioLider2,
                                ComentarioLiderMatricial = i.ComentarioLiderMatricial,
                                ValorValoracionFinal = i.ValorValoracionFinal,
                                ValoracionFinal = i.ValoracionFinal,
                                ValoracionLider1 = i.ValoracionLider1

                            });
                            break;
                        case "6":
                            d.Add(new Objetivo_6Step
                            {
                                IdColaborador = i.IdColaborador,
                                IdObjetivo = i.IdObjetivo,
                                NumeroObjetivo = i.Numero,
                                Objetivo = i.NombreObjetivo,
                                DescObjetivo = i.Descripcion,
                                IdObjetivoAnioFiscal = j.Id,
                                AnioFiscal = j.AnioFiscal,
                                PonderacionObjetivo = j.Ponderacion,
                                PlanificacionResultados = j.PlanificacionResultados,
                                EstadoProceso = i.EstadoProceso,
                                DescEstadoProceso = i.DescEstadoProceso,
                                Perfil = i.Perfil,
                                ComentarioColaborador = i.ComentarioColaborador,
                                ComentarioLider1 = i.ComentarioLider1,
                                ComentarioLider2 = i.ComentarioLider2,
                                ComentarioLiderMatricial = i.ComentarioLiderMatricial,
                                ValorValoracionFinal = i.ValorValoracionFinal,
                                ValoracionFinal = i.ValoracionFinal,
                                ValoracionLider1 = i.ValoracionLider1

                            });
                            break;
                        case "7":
                            d.Add(new Objetivo_7Step
                            {
                                IdColaborador = i.IdColaborador,
                                IdObjetivo = i.IdObjetivo,
                                NumeroObjetivo = i.Numero,
                                Objetivo = i.NombreObjetivo,
                                DescObjetivo = i.Descripcion,
                                IdObjetivoAnioFiscal = j.Id,
                                AnioFiscal = j.AnioFiscal,
                                PonderacionObjetivo = j.Ponderacion,
                                PlanificacionResultados = j.PlanificacionResultados,
                                EstadoProceso = i.EstadoProceso,
                                DescEstadoProceso = i.DescEstadoProceso,
                                Perfil = i.Perfil,
                                ComentarioColaborador=i.ComentarioColaborador,
                                ComentarioLider1 = i.ComentarioLider1,
                                ComentarioLider2 = i.ComentarioLider2,
                                ComentarioLiderMatricial = i.ComentarioLiderMatricial,
                                ValorValoracionFinal = i.ValorValoracionFinal,
                                ValoracionFinal = i.ValoracionFinal,
                                ValoracionLider1 = i.ValoracionLider1
                            });
                            break;
                    }

                   
                   
                }

            }
            return d;

          }
    }
}