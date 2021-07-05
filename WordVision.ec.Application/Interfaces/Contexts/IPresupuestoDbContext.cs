using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Presupuesto;

namespace WordVision.ec.Application.Interfaces.Contexts
{
    public interface  IPresupuestoDbContext
    {
        IDbConnection Connection { get; }
        bool HasChanges { get; }

        EntityEntry Entry(object entity);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        DbSet<DatosLDR> DatosLDRs { get; set; }
        DbSet<DatosT5> DatosT5s { get; set; }
        DbSet<Presupuesto> Presupuestos { get; set; }
    }
}
