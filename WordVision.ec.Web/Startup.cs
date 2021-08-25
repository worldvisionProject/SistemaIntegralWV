using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using IdentityServer4.Configuration;
using WordVision.Application.Extensions;
using SmartBreadcrumbs.Attributes;
using WordVision.ec.Application.Interfaces.Shared;
using WordVision.ec.Infrastructure.Data.Contexts;
using WordVision.ec.Infrastructure.Data.Extensions;
using WordVision.ec.Infrastructure.Shared.Pdf;
using WordVision.ec.Infrastructure.Shared.Services;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Registro.Controllers;
using WordVision.ec.Web.Areas.Registro.Pages.Formulario.Wizard;
using WordVision.ec.Web.Configuration;
using WordVision.ec.Web.Extensions;
using WordVision.ec.Web.Permission;
using WordVision.ec.Web.Services;
using WordVision.ec.Infrastructure.Data.Identity.Models;
using System.Net;
using SmartBreadcrumbs.Extensions;
using Newtonsoft;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace WordVision.ec.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //Log.Logger = new LoggerConfiguration()
            //  .Enrich.FromLogContext()
            //  .WriteTo.File("Logs/mylog-{Date}.txt")
            //  .CreateLogger();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(loggingBuilder =>
          loggingBuilder.AddSerilog(dispose: true));
            services.AddRazorPages().AddJsonOptions(option =>
                  option.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase);

            services.AddControllers().AddJsonOptions(x =>
               x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

            services.AddControllersWithViews()
                    .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddControllers(options =>
            {
                options.OutputFormatters.RemoveType<SystemTextJsonOutputFormatter>();
                options.OutputFormatters.Add(new SystemTextJsonOutputFormatter(new JsonSerializerOptions(JsonSerializerDefaults.Web)
                {
                    ReferenceHandler = ReferenceHandler.Preserve,
                }));
            });

            services.AddBreadcrumbs(GetType().Assembly,options =>
            {
                options.DontLookForDefaultNode = true;
                //TagName = "nav";
                //TagClasses = "";
                //OlClasses = "breadcrumb";
                //LiClasses = "breadcrumb-item";
                //ActiveLiClasses = "breadcrumb-item active";
                //SeparatorElement = "<li class=\"separator\">/</li>";
            });

            services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
            services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
            services.AddNotyf(o =>
            {
                o.DurationInSeconds = 10;
                o.IsDismissable = true;
                o.HasRippleEffect = true;
            });
            services.AddApplicationLayer();
            services.AddInfrastructure(Configuration);
            services.AddPersistenceContexts(Configuration);
            services.AddRepositories();
            services.AddSharedInfrastructure(Configuration);
            services.AddMultiLingualSupport();
            services.AddControllersWithViews().AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
            });
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddDistributedMemoryCache();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IViewRenderService, ViewRenderService>();



            services.AddMvc(options =>
            {

                // Adding your provider to the end of the collection may result in a built-in
                // model binder being called before your custom binder has a chance.
                options.ModelBinderProviders.Insert(0, new StepModelBinderProvider());
            }).AddSessionStateTempDataProvider();
            services.AddSession();


            services.Configure<IISServerOptions>(iis =>
            {
                iis.AuthenticationDisplayName = "Windows";
                iis.AutomaticAuthentication = false;
                iis.MaxRequestBodySize = long.MaxValue;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
               app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

       

            app.UseDeveloperExceptionPage();
           
            app.UseNotyf();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseMultiLingualFeature();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                   name: "areas",
                   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area=Dashboard}/{controller=Home}/{action=Index}/{id?}");
            });

            RotativaConfiguration.Setup(env);
        }
    }
}
