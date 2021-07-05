using AspNetCoreHero.EntityFrameworkCore.AuditTrail;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Contexts;
using WordVision.ec.Application.Interfaces.Shared;
using WordVision.ec.Domain.Contracts;
using WordVision.ec.Domain.Entities.Presupuesto;

namespace WordVision.ec.Infrastructure.Data.Contexts
{
    public class PresupuestoDbContext : AuditableContext, IPresupuestoDbContext
    {
        private readonly IDateTimeService _dateTime;
        // private readonly IAuthenticatedUserService _authenticatedUser;

        public PresupuestoDbContext(DbContextOptions<PresupuestoDbContext> options, IDateTimeService dateTime)//, IAuthenticatedUserService authenticatedUser) 
          : base(options)
        {
            _dateTime = dateTime;
            //  _authenticatedUser = authenticatedUser;
        }

        public IDbConnection Connection => Database.GetDbConnection();

        public bool HasChanges => ChangeTracker.HasChanges();

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = _dateTime.NowUtc;
                        entry.Entity.CreatedBy = "";// _authenticatedUser.UserId;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedOn = _dateTime.NowUtc;
                        entry.Entity.LastModifiedBy = "";// _authenticatedUser.UserId;
                        break;
                }
            }
            //if (_authenticatedUser.UserId == null)
            //{
            //return await base.SaveChangesAsync(cancellationToken);
            //}
            //else
            //{
            return await base.SaveChangesAsync("jlmoreno");// _authenticatedUser.UserId);
            //}
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
             foreach (var property in builder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,2)");
            }
            base.OnModelCreating(builder);
        }
        public DbSet<DatosLDR> DatosLDRs { get; set; }
        public DbSet<DatosT5> DatosT5s { get; set; }
        public DbSet<Presupuesto> Presupuestos { get; set; }
    }
}
