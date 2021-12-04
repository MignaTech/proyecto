using Proyecto.Bussiness;
using Proyecto.Helpers;
using Proyecto.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace Proyecto
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Proyecto", Version = "v1" });
            });

            #region Add DbContext
            services.AddDbContext<Models.proyectoContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("ProyectoDB");
                var version = ServerVersion.Parse("8.0.26-mysql");
                options.UseMySql(connectionString, version);
            });
            #endregion

            #region Add JwtSettigs
            var jwtSection = Configuration.GetSection("JwtSettings");
            var jwtSettings = jwtSection.Get<JwtSettings>();
            var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.Secret);
            // Agregue el objeto JwtSettigs como configuración, no como servicio
            services.Configure<JwtSettings>(jwtSection);
            // Agregar autenticación Jwt
            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                bearerOptions.RequireHttpsMetadata = false;
                bearerOptions.SaveToken = true;
                bearerOptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            #endregion

            #region Add CORS
            var origins = Configuration.GetSection("Origins");
            var hosts = origins.Get<string[]>();
            services.AddCors(options =>
            {
                options.AddPolicy("MY_CORS", builder =>
                {
                    builder.WithOrigins(hosts);
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });
            #endregion

            #region Add Data protection
            services.AddDataProtection()
                .SetApplicationName("ProyectoApi")
                .SetDefaultKeyLifetime(TimeSpan.FromDays(14))
                .UseCryptographicAlgorithms(
                    new AuthenticatedEncryptorConfiguration
                    {
                        EncryptionAlgorithm = EncryptionAlgorithm.AES_256_CBC,
                        ValidationAlgorithm = ValidationAlgorithm.HMACSHA256
                    }
                );
            #endregion

            #region Add Custom services
            services.AddScoped<IAutorService, AutorService>();
            services.AddScoped<ICategoriService, CategoriService>();
            services.AddScoped<IEditorialService, EditorialService>();
            services.AddScoped<IEntradaproductoService, EntradaproductoService>();
            services.AddScoped<ILibroService, LibroService>();
            services.AddScoped<INivelService, NivelService>();
            services.AddScoped<IPersonaService, PersonaService>();
            services.AddScoped<IProveService, ProveService>();
            
            services.AddScoped<ICompraService, CompraService>();
            services.AddScoped<IPrecompraService, PrecompraService>();
            services.AddScoped<ITemporalService, TemporalService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Proyecto v1"));
            }
            app.UseRouting();
            //AGREGAMOS CORD
            app.UseCors("MY_CORS");
            //AGREGAMOS AUTENTIFICACION
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
