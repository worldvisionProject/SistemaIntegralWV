using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Identity;

namespace WordVision.ec.Application.Interfaces.Contexts
{
    public interface IIdentityDbContext
    {
        IDbConnection Connection { get; }
        bool HasChanges { get; }

        EntityEntry Entry(object entity);


        DbSet<UsuariosActiveDirectory> UsuariosActiveDirectory { get; set; }
    }
}
