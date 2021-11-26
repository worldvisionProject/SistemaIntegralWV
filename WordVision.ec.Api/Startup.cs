using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WordVision.Application.Extensions;
using WordVision.ec.Api.Extensions;

using WordVision.ec.Api.Middlewares;
using WordVision.ec.Infrastructure.Data.Extensions;


namespace WordVision.ec.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationLayer();
            services.AddContextInfrastructure(Configuration);
            services.AddPersistenceContexts(Configuration);
            services.AddRepositories();
            services.AddSharedInfrastructure(Configuration);
            services.AddEssentials();
            services.AddControllers();
            services.AddMvc(o =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                o.Filters.Add(new AuthorizeFilter(policy));
            });

            // services.AddScoped<IUserProvider, AdUserProvider>();
            // services.AddControllers();
            // services.AddSwaggerGen(c =>
            // {
            //     c.SwaggerDoc("v1", new OpenApiInfo { Title = "WordVision.ec.Api", Version = "v1" });
            // });

            //// services.AddAuthentication(IISDefaults.AuthenticationScheme);

            // services.AddControllers().AddJsonOptions(option =>
            //     option.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase);

            //services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
            //services.AddTransient<IDateTimeService, SystemDateTimeService>();
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddDbContext<RegistroDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("RegistroConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //    app.UseSwagger();
            //    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WordVision.ec.Api v1"));
            //}
            //app.UseAdMiddleware();
            //app.UseHttpsRedirection();

            //app.UseRouting();
            //app.UseAuthentication();
            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.ConfigureSwagger();
            app.UseHttpsRedirection();
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseRouting();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
