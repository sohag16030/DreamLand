using System;
using System.Linq;
using System.Text;
using AspNetCoreRateLimit;
using Elastic.Apm.NetCoreAll;
using MediatR;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OData.Edm;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using TestWeb.DbContexts;
using TestWeb.ErrorHandling;
using TestWeb.Helper;
using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;

namespace TestWeb
{
    public class Startup
    {
        private readonly IHostEnvironment _env;
        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            _env = env;
            Configuration = configuration;
        }
        private void ConfigureEventBus(IApplicationBuilder app)
        {
            //var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
          
        }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.AddHttpContextAccessor();

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

             if (_env.IsProduction())
            {
                string connection = Environment.GetEnvironmentVariable("ConnectionString");
                services.AddDbContext<ReadDbContext>(options => options.UseSqlServer(connection), ServiceLifetime.Transient);
                services.AddDbContext<WriteDbContext>(options => options.UseSqlServer(connection), ServiceLifetime.Transient);
                Connection.erpm_procurement = connection;
            }
            else
            {
                services.AddDbContext<ReadDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Development")), ServiceLifetime.Transient);
                services.AddDbContext<WriteDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Development")), ServiceLifetime.Transient);
                Connection.erpm_procurement = Configuration.GetConnectionString("Development");
            }

            services.AddControllers(opts =>
            {
                //if (_env.IsProduction())
                //{
                //    var authenticatedUserPolicy = new AuthorizationPolicyBuilder()
                //           .RequireAuthenticatedUser()
                //           .Build();
                //    opts.Filters.Add(new AuthorizeFilter(authenticatedUserPolicy));
                   
                //}
                //else
                //{
                //    opts.Filters.Add<AllowAnonymousFilter>();
                //}
                opts.Filters.Add<AllowAnonymousFilter>();

            });

            

            JwtConfiguration(services);
            
            RegisterServices(services);
            services.Configure<Helper.Audience>(Configuration.GetSection("Audience"));

            services.AddControllers(mvcOptions =>
                mvcOptions.EnableEndpointRouting = false)
                .AddNewtonsoftJson(); 

            services.AddOData();
            services.AddMediatR(typeof(Startup));


            #region === serilog in elastic search

            var elasticUri = "http://172.17.17.25:8064/";//Configuration["ElasticConfiguration:Uri"];

            Log.Logger = new LoggerConfiguration()
               .Enrich.FromLogContext()
               .Enrich.WithExceptionDetails()
               .Enrich.WithMachineName()
               .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticUri))
               {
                   AutoRegisterTemplate = true,
               })
            .CreateLogger();

            #endregion ================== close

            #region === Swagger generator

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "iBOS Microservice Service"
                });

                c.EnableAnnotations();
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "Enter the request header in the following box to add Jwt To grant authorization Token: Bearer Token",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });

            //Odata for Swagger
            services.AddMvcCore(options =>
            {
                foreach (var outputFormatter in options.OutputFormatters.OfType<OutputFormatter>().Where(x => x.SupportedMediaTypes.Count == 0))
                {
                    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }

                foreach (var inputFormatter in options.InputFormatters.OfType<InputFormatter>().Where(x => x.SupportedMediaTypes.Count == 0))
                {
                    inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
            });

            #endregion ======================= close

            #region ==== Rate limit ======

            services.AddMemoryCache();

            //load general configuration from appsettings.json
            services.Configure<IpRateLimitOptions>(Configuration.GetSection("IpRateLimiting"));

            //load ip rules from appsettings.json
            services.Configure<IpRateLimitPolicies>(Configuration.GetSection("IpRateLimitPolicies"));

            // inject counter and rules stores
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();

            // Add framework services.
            services.AddMvc();

            // configuration (resolvers, counter key builders)
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            #endregion === Close ========

        }

        private void RegisterServices(IServiceCollection services)
        {
            DependencyContainer.RegisterServices(services);
        }

        private void JwtConfiguration(IServiceCollection services)
        {
            var audienceConfig = Configuration.GetSection("Audience");
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(audienceConfig["Secret"]));
           // var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_env.IsProduction() ? Configuration.GetSection("REACT_APP_SECRET_NAME").Value.Trim() : audienceConfig["Secret"]));
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = true,
                ValidIssuer = audienceConfig["Iss"],
                ValidateAudience = true,
                ValidAudience = audienceConfig["Aud"],
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                RequireExpirationTime = true,
            };

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = "AuthScheme";
            })
            .AddJwtBearer("AuthScheme", x =>
            {
                x.RequireHttpsMetadata = false;
                x.TokenValidationParameters = tokenValidationParameters;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseIpRateLimiting(); 
            
            loggerFactory.AddSerilog();
            app.UseAllElasticApm(Configuration);

             

             app.UseCors(x => x
                      .AllowAnyOrigin()
                     .AllowAnyMethod()
                    .AllowAnyHeader());

            

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.ConfigureCustomExceptionMiddleware();
            if (!env.IsProduction())
            {
                //Enable Swagger middleware and endpoint
                app.UseSwagger(c =>
                {
                    c.RouteTemplate = "procurement/swagger/{documentName}/swagger.json";
                });

                //specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/procurement/swagger/v1/swagger.json", "procurement web service");
                    c.RoutePrefix = "procurement/swagger";
                });
            }
          
             
            ConfigureEventBus(app);

            
            app.UseEndpoints(endpoint =>
            {
                endpoint.EnableDependencyInjection();
                endpoint.Expand().Select().Count().Filter().OrderBy();
               // endpoint.MapODataServiceRoute("identity", "identity", GetEdmModel());
                endpoint.MapODataRoute(routeName: "procurement", routePrefix: "procurement", model: GetEdmModel());

            });
        }
        private IEdmModel GetEdmModel()
        {
            var edmBuilder = new ODataConventionModelBuilder();
            edmBuilder.EnableLowerCamelCase();
            return edmBuilder.GetEdmModel();

        }

    }
}
