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
using WordVision.ec.Domain.Entities.Maestro;
using WordVision.ec.Domain.Entities.Planificacion;
using WordVision.ec.Domain.Entities.Presupuesto;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Infrastructure.Data.Contexts
{
    public  class RegistroDbContext : AuditableContext, IRegistroDbContext //AuditableContext
    {
      
        private readonly IDateTimeService _dateTime;
        private readonly IAuthenticatedUserService _authenticatedUser;
        public RegistroDbContext(DbContextOptions<RegistroDbContext> options, IDateTimeService dateTime, IAuthenticatedUserService authenticatedUser) 
            : base(options)
        {
            _dateTime = dateTime;
            _authenticatedUser = authenticatedUser;
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
                        entry.Entity.CreatedBy =  _authenticatedUser.Username;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedOn = _dateTime.NowUtc;
                        entry.Entity.LastModifiedBy =  _authenticatedUser.Username;
                        break;
                }
            }
            if (_authenticatedUser.Username == null)
            {
                return await base.SaveChangesAsync(cancellationToken);
            }
            else
            {
                //return await base.SaveChangesAsync("jlmoreno");//
               return await base.SaveChangesAsync(_authenticatedUser.Username);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DatosLDR>()
            .ToTable("DatosLDRs","pres");
            builder.Entity<DatosT5>()
           .ToTable("DatosT5s", "pres");
            builder.Entity<Presupuesto>()
           .ToTable("Presupuestos", "pres");

            builder.Entity<Catalogo>()
           .ToTable("Catalogos", "adm");
            builder.Entity<DetalleCatalogo>()
           .ToTable("DetalleCatalogos", "adm");
            builder.Entity<Pais>()
           .ToTable("Paises", "adm");
            builder.Entity<Provincia>()
          .ToTable("Provincias", "adm");
            builder.Entity<Ciudad>()
        .ToTable("Ciudades", "adm");
            builder.Entity<Estructura>()
        .ToTable("Estructuras", "adm");
            builder.Entity<Empresa>()
        .ToTable("Empresas", "adm");

            builder.Entity<EstrategiaNacional>()
          .ToTable("EstrategiaNacionales", "planifica");
            builder.Entity<Gestion>()
           .ToTable("Gestiones", "planifica");
            builder.Entity<ObjetivoEstrategico>()
           .ToTable("ObjetivoEstrategicos", "planifica");
            builder.Entity<FactorCriticoExito>()
          .ToTable("FactorCriticoExitos", "planifica");
            builder.Entity<IndicadorEstrategico>()
          .ToTable("IndicadorEstrategicos", "planifica");
            builder.Entity<IndicadorAF>()
         .ToTable("IndicadorAFs", "planifica");
            builder.Entity<Producto>()
           .ToTable("Productos", "planifica");
            builder.Entity<IndicadorPOA>()
          .ToTable("IndicadorPOAs", "planifica");
            builder.Entity<Actividad>()
      .ToTable("Actividades", "planifica");
            builder.Entity<MetaEstrategica>()
     .ToTable("MetaEstrategicas", "planifica");
            builder.Entity<MetaTactica>()
     .ToTable("MetaTacticas", "planifica");

            builder
       .Entity<Tercero>()
       .HasMany(e => e.FormularioTerceros).WithOne(e=> e.Terceros)
       .OnDelete(DeleteBehavior.ClientCascade);


            //builder.Entity<Colaborador>().HasMany(m => m.Formularios)
            //     .WithOne(c => c.Colaboradores)
            //     .HasForeignKey(k => k.IdColaborador);

            foreach (var property in builder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,2)");
            }
            base.OnModelCreating(builder);
        }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Pregunta> Preguntas { get; set; }
        public DbSet<Formulario> Formularios { get; set; }
        public DbSet<Respuesta> Respuestas { get; set; }
        public DbSet<Firma> Firmas { get; set; }
        public DbSet<Idioma> Idiomas { get; set; }

        public DbSet<DatosLDR> DatosLDRs { get; set; }
        public DbSet<DatosT5> DatosT5s { get; set; }
        public DbSet<Presupuesto> Presupuestos { get; set; }

    }
}
