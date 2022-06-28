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
    public class ETabuladoRepository : IETabuladoRepository
    {
        private readonly RegistroDbContext _db;

        private readonly IRepositoryAsync<ETabulado> _repository;

        public ETabuladoRepository(IRepositoryAsync<ETabulado> repository, RegistroDbContext db)
        {
            _repository = repository;
            _db = db;
        }

        public IQueryable<ETabulado> ETabulados => _repository.Entities;
        public async Task<List<ETabulado>> GetListAsync(int EvaluacionId, int RegionId, string ProvinciaId, string CantonId, string ParroquiaId, string ComunidadId, string ProgramaId, string IndicadorId)
        {

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

            _db.Database.SetCommandTimeout(TimeSpan.FromMinutes(20));

                Resultado = await _db.Set<ETabulado>()
                    .FromSqlRaw("EXEC [survey].[ConsultarIndicadoresTabulados] @EvaluacionId, @RegionId, @ProvinciaId, @CantonId, @ParroquiaId, @ComunidadId, @ProgramaId, @IndicadorId ", param1, param2, param3, param4, param5, param6, param7, param8)
                    .ToListAsync();
            //}

            return Resultado;

        }

    }
}
