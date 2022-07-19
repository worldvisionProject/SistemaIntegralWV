using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Maestro;
using WordVision.ec.Domain.Entities.Encuesta;
using WordVision.ec.Application.DTOs.Encuesta;
using System;
using Newtonsoft.Json.Linq;
using WordVision.ec.Infrastructure.Data.Contexts;
using Microsoft.Data.SqlClient;

namespace WordVision.ec.Infrastructure.Data.Repositories.Encuesta
{
    public class EReporteTabuladoRepository : IEReporteTabuladoRepository
    {
        private readonly RegistroDbContext _db;

        private readonly IRepositoryAsync<EReporteTabulado> _repository;

        public EReporteTabuladoRepository(IRepositoryAsync<EReporteTabulado> repository, RegistroDbContext db)
        {
            _repository = repository;
            _db = db;
        }

        public IQueryable<EReporteTabulado> EReporteTabulados => _repository.Entities;

        public async Task<List<EReporteTabulado>> GetListAsync(int EvaluacionId, int RegionId, string ProvinciaId, string CantonId, string ProgramaId, string IndicadorId)
        {
            //Consultamos de la tabla EReporteTabulados los registros segun los criterios de busqueda seleccionados
            //Si EvaluacionId es 0, entonces buscamos el primer EvaluacionId de la tabla EReporteTabulados y le asignamos al parametro EvaluacionId

            if (EvaluacionId == 0) EvaluacionId = 1;
            if (ProvinciaId == null) ProvinciaId = "";
            if (CantonId == null) CantonId = "";
            if (ProgramaId == null) ProgramaId = "";
            if (IndicadorId == null) IndicadorId = "";

            return await _repository.Entities.Where(s => 
                                                            s.EEvaluacion.Id == EvaluacionId
                                                            && (RegionId == 0 || s.ERegion.Id == RegionId)
                                                            && (string.IsNullOrEmpty(ProvinciaId) || s.EProvincia.Id == ProvinciaId)
                                                            && (string.IsNullOrEmpty(CantonId) || s.ECanton.Id == CantonId)
                                                            && (string.IsNullOrEmpty(ProgramaId) || s.EPrograma.Id == ProgramaId)
                                                            && (string.IsNullOrEmpty(IndicadorId) || s.EIndicador.Id == IndicadorId)
                                                    )
                                                    .Include(c => c.EEvaluacion)
                                                    .Include(c => c.ERegion)
                                                    .Include(c => c.EProvincia)
                                                    .Include(c => c.ECanton)
                                                    .Include(c => c.EPrograma)
                                                    .Include(c => c.EIndicador)
                                                    .ToListAsync();
        }


        public async Task<List<ETabulado>> GenerateResultsListAsync(int EvaluacionId)
        {
            //Consultamos los resultados ejecutado el StoreProcedure survey.ConsultarIndicadoresTabulados

            int RegionId = 0;
            string ProvinciaId = "";
            string CantonId = "";
            string ParroquiaId = "";
            string ComunidadId = "";
            string ProgramaId = "";
            string IndicadorId = "";

            
            List<ETabulado> Resultado = new List<ETabulado>();
            //using (var _dbContext = _db)
            //{
                var param1 = new SqlParameter
                {
                    ParameterName = "EvaluacionId",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = EvaluacionId,
                };

                var param2 = new SqlParameter
                {
                    ParameterName = "RegionId",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = RegionId,
                };

                var param3 = new SqlParameter
                {
                    ParameterName = "ProvinciaId",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 450,
                    Value = ProvinciaId,
                };

                var param4 = new SqlParameter
                {
                    ParameterName = "CantonId",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 450,
                    Value = CantonId,
                };

                var param5 = new SqlParameter
                {
                    ParameterName = "ParroquiaId",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 450,
                    Value = ParroquiaId,
                };

                var param6 = new SqlParameter
                {
                    ParameterName = "ComunidadId",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 450,
                    Value = ComunidadId,
                };
                var param7 = new SqlParameter
                {
                    ParameterName = "ProgramaId",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 450,
                    Value = ProgramaId,
                };
                var param8 = new SqlParameter
                {
                    ParameterName = "IndicadorId",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 450,
                    Value = IndicadorId,
                };

            _db.Database.SetCommandTimeout(TimeSpan.FromMinutes(30));

                Resultado = await _db.Set<ETabulado>()
                    .FromSqlRaw("EXEC [survey].[ConsultarIndicadoresTabulados] @EvaluacionId, @RegionId, @ProvinciaId, @CantonId, @ParroquiaId, @ComunidadId, @ProgramaId, @IndicadorId ", param1, param2, param3, param4, param5, param6, param7, param8)
                    .ToListAsync();

            //}

            return Resultado;

        }

        public async Task<List<ETabulado>> GenerateResultsComplejosListAsync(int EvaluacionId)
        {
            //Consultamos los resultados ejecutado el StoreProcedure survey.ConsultarIndicadoresTabulados

            int RegionId = 0;
            string ProvinciaId = "";
            string CantonId = "";
            string ParroquiaId = "";
            string ComunidadId = "";
            string ProgramaId = "";
            string IndicadorId = "";


            List<ETabulado> Resultado = new List<ETabulado>();
            //using (var _dbContext = _db)
            //{
            var param1 = new SqlParameter
            {
                ParameterName = "EvaluacionId",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = EvaluacionId,
            };

            var param2 = new SqlParameter
            {
                ParameterName = "RegionId",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = RegionId,
            };

            var param3 = new SqlParameter
            {
                ParameterName = "ProvinciaId",
                SqlDbType = System.Data.SqlDbType.NVarChar,
                Size = 450,
                Value = ProvinciaId,
            };

            var param4 = new SqlParameter
            {
                ParameterName = "CantonId",
                SqlDbType = System.Data.SqlDbType.NVarChar,
                Size = 450,
                Value = CantonId,
            };

            var param5 = new SqlParameter
            {
                ParameterName = "ParroquiaId",
                SqlDbType = System.Data.SqlDbType.NVarChar,
                Size = 450,
                Value = ParroquiaId,
            };

            var param6 = new SqlParameter
            {
                ParameterName = "ComunidadId",
                SqlDbType = System.Data.SqlDbType.NVarChar,
                Size = 450,
                Value = ComunidadId,
            };
            var param7 = new SqlParameter
            {
                ParameterName = "ProgramaId",
                SqlDbType = System.Data.SqlDbType.NVarChar,
                Size = 450,
                Value = ProgramaId,
            };
            var param8 = new SqlParameter
            {
                ParameterName = "IndicadorId",
                SqlDbType = System.Data.SqlDbType.NVarChar,
                Size = 450,
                Value = IndicadorId,
            };

            _db.Database.SetCommandTimeout(TimeSpan.FromMinutes(30));

            Resultado = await _db.Set<ETabulado>()
                .FromSqlRaw("EXEC [survey].[ConsultarIndicadoresTabulados_2] @EvaluacionId, @RegionId, @ProvinciaId, @CantonId, @ParroquiaId, @ComunidadId, @ProgramaId, @IndicadorId ", param1, param2, param3, param4, param5, param6, param7, param8)
                .ToListAsync();

            //}

            return Resultado;

        }
        public async Task<List<ETabulado>> GenerateResultsDAPListAsync(int EvaluacionId)
        {
            //Consultamos los resultados ejecutado el StoreProcedure 

            int RegionId = 0;
            string ProvinciaId = "";
            string CantonId = "";
            string ParroquiaId = "";
            string ComunidadId = "";
            string ProgramaId = "";
            string IndicadorId = "";


            List<ETabulado> Resultado = new List<ETabulado>();
            //using (var _dbContext = _db)
            //{
            var param1 = new SqlParameter
            {
                ParameterName = "EvaluacionId",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = EvaluacionId,
            };

            var param2 = new SqlParameter
            {
                ParameterName = "RegionId",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = RegionId,
            };

            var param3 = new SqlParameter
            {
                ParameterName = "ProvinciaId",
                SqlDbType = System.Data.SqlDbType.NVarChar,
                Size = 450,
                Value = ProvinciaId,
            };

            var param4 = new SqlParameter
            {
                ParameterName = "CantonId",
                SqlDbType = System.Data.SqlDbType.NVarChar,
                Size = 450,
                Value = CantonId,
            };

            var param5 = new SqlParameter
            {
                ParameterName = "ParroquiaId",
                SqlDbType = System.Data.SqlDbType.NVarChar,
                Size = 450,
                Value = ParroquiaId,
            };

            var param6 = new SqlParameter
            {
                ParameterName = "ComunidadId",
                SqlDbType = System.Data.SqlDbType.NVarChar,
                Size = 450,
                Value = ComunidadId,
            };
            var param7 = new SqlParameter
            {
                ParameterName = "ProgramaId",
                SqlDbType = System.Data.SqlDbType.NVarChar,
                Size = 450,
                Value = ProgramaId,
            };
            var param8 = new SqlParameter
            {
                ParameterName = "IndicadorId",
                SqlDbType = System.Data.SqlDbType.NVarChar,
                Size = 450,
                Value = IndicadorId,
            };

            _db.Database.SetCommandTimeout(TimeSpan.FromMinutes(30));

            Resultado = await _db.Set<ETabulado>()
                .FromSqlRaw("EXEC [survey].[ConsultarIndicadoresDAP] @EvaluacionId, @RegionId, @ProvinciaId, @CantonId, @ParroquiaId, @ComunidadId, @ProgramaId, @IndicadorId ", param1, param2, param3, param4, param5, param6, param7, param8)
                .ToListAsync();

            //}

            return Resultado;

        }


        public async Task<List<ETabulado>> GenerateResultsNacionalesListAsync(int EvaluacionId)
        {
            //Consultamos los resultados ejecutado el StoreProcedure survey.ConsultarIndicadoresTabulados

            int RegionId = 0;
            string ProvinciaId = "";
            string CantonId = "";
            string ParroquiaId = "";
            string ComunidadId = "";
            string ProgramaId = "";
            string IndicadorId = "";


            List<ETabulado> Resultado = new List<ETabulado>();
            //using (var _dbContext = _db)
            //{
            var param1 = new SqlParameter
            {
                ParameterName = "EvaluacionId",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = EvaluacionId,
            };

            var param2 = new SqlParameter
            {
                ParameterName = "RegionId",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = RegionId,
            };

            var param3 = new SqlParameter
            {
                ParameterName = "ProvinciaId",
                SqlDbType = System.Data.SqlDbType.NVarChar,
                Size = 450,
                Value = ProvinciaId,
            };

            var param4 = new SqlParameter
            {
                ParameterName = "CantonId",
                SqlDbType = System.Data.SqlDbType.NVarChar,
                Size = 450,
                Value = CantonId,
            };

            var param7 = new SqlParameter
            {
                ParameterName = "ProgramaId",
                SqlDbType = System.Data.SqlDbType.NVarChar,
                Size = 450,
                Value = ProgramaId,
            };
            var param8 = new SqlParameter
            {
                ParameterName = "IndicadorId",
                SqlDbType = System.Data.SqlDbType.NVarChar,
                Size = 450,
                Value = IndicadorId,
            };

            _db.Database.SetCommandTimeout(TimeSpan.FromMinutes(30));

            Resultado = await _db.Set<ETabulado>()
                .FromSqlRaw("EXEC [survey].[ConsultarIndicadoresTabuladosNacionales] @EvaluacionId, @RegionId, @ProvinciaId, @CantonId, @ProgramaId, @IndicadorId ", param1, param2, param3, param4, param7, param8)
                .ToListAsync();

            //}

            return Resultado;

        }


        public async Task<int> InsertAsync(EReporteTabulado eReporteTabulado)
        {
            await _repository.AddAsync(eReporteTabulado);
            return eReporteTabulado.Id;
        }

        public async Task DeleteAllAsync(int EvaluacionId)
        {
            //Eliminamos todos los registros de una Evaluacion
            List<EReporteTabulado> eReporteTabuladoList = new List<EReporteTabulado>();
            
            eReporteTabuladoList = await _repository.Entities.Where(s => s.EEvaluacion.Id == EvaluacionId).ToListAsync();

            foreach (EReporteTabulado eReporteTabulado in eReporteTabuladoList)
            {
                await _repository.DeleteAsync(eReporteTabulado);
            }

        }


    }
}
