using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Contexts;
using WordVision.ec.Domain.Entities.Identity;

namespace WordVision.ec.Infrastructure.Data.Contexts
{
    public class ActiveContext: DbContext, IIdentityDbContext
    {
        public ActiveContext(DbContextOptions<ActiveContext> options)
          : base(options)
        {

        }

        public DbSet<UsuariosActiveDirectory> UsuariosActiveDirectory { get; set; }

        public IDbConnection Connection => Database.GetDbConnection();

        public bool HasChanges => ChangeTracker.HasChanges();
    }
}
