using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Infrastructure.Data.Repositories.Planificacion
{
    public class ProductoObjetivoRepository : IProductoObjetivoRepository
    {
        public IQueryable<ProductoObjetivo> Entidades => throw new NotImplementedException();

        public Task DeleteAsync(ProductoObjetivo entidad)
        {
            throw new NotImplementedException();
        }

        public Task<ProductoObjetivo> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductoObjetivo>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(ProductoObjetivo entidad)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ProductoObjetivo entidad)
        {
            throw new NotImplementedException();
        }
    }
}
