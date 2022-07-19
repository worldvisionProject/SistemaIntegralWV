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
using System;
using Newtonsoft.Json.Linq;
using WordVision.ec.Infrastructure.Data.Contexts;
using Microsoft.Data.SqlClient;

namespace WordVision.ec.Infrastructure.Data.Repositories.Encuesta
{
    public class EReporteDAPRepository : IEReporteDAPRepository
    {
        private readonly RegistroDbContext _db;

        private readonly IRepositoryAsync<EReporteDAP> _repository;

        public EReporteDAPRepository(IRepositoryAsync<EReporteDAP> repository, RegistroDbContext db)
        {
            _repository = repository;
            _db = db;
        }

        public IQueryable<EReporteDAP> EReporteDAPs => _repository.Entities;

        public async Task<List<EReporteDAP>> GetListAsync(int EvaluacionId, int RegionId, string ProvinciaId, string CantonId, string ProgramaId, string IndicadorId)
        {
            //Consultamos de la tabla EReporteDAPs los registros segun los criterios de busqueda seleccionados
            //Si EvaluacionId es 0, entonces buscamos el primer EvaluacionId de la tabla EReporteDAPs y le asignamos al parametro EvaluacionId

            if (EvaluacionId == 0) EvaluacionId = 1;
            if (ProvinciaId == null) ProvinciaId = "";
            if (CantonId == null) CantonId = "";
            if (ProgramaId == null) ProgramaId = "";
            if (IndicadorId == null) IndicadorId = "";

            //Consultamos los resultados ejecutado el StoreProcedure survey.ConsultarIndicadoresDAP

            List<EReporteDAP> Resultado = new();

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

            Resultado = await _db.Set<EReporteDAP>()
                .FromSqlRaw("EXEC [survey].[ConsultarReporteDAP] @EvaluacionId, @RegionId, @ProvinciaId, @CantonId, @ProgramaId, @IndicadorId ", param1, param2, param3, param4, param7, param8)
                .ToListAsync();


            return Resultado;
        }



    }
}
