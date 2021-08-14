using DBFirst.DbContexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBFirst
{
    public class Startup
    {
        private readonly IHostEnvironment _env;
        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            _env = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddHangfire(config =>
            //config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            //.UseSimpleAssemblyNameTypeSerializer()
            //.UseDefaultTypeSerializer()
            //.UseMemoryStorage());

            services.AddControllers();
            services.AddHttpContextAccessor();
            //services.AddControllers().AddNewtonsoftJson(options =>
            //{
            //    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //});

            if (_env.IsProduction())
            {
                string connection = Environment.GetEnvironmentVariable("ConnectionString");
                services.AddDbContext<ReadDbContext>(options => options.UseSqlServer(connection), ServiceLifetime.Transient);
                services.AddDbContext<WriteDbContext>(options => options.UseSqlServer(connection), ServiceLifetime.Transient);

                //Connection.BMS = connection;
            }
            else
            {
                var data = Configuration.GetConnectionString("Development");
                services.AddDbContext<ReadDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Development")), ServiceLifetime.Transient);
                services.AddDbContext<WriteDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Development")), ServiceLifetime.Transient);

                //Connection.BMS = Configuration.GetConnectionString("Development");
            }


            services.AddControllers(opts =>
            {
                if (_env.IsDevelopment())
                {
                    opts.Filters.Add<AllowAnonymousFilter>();
                }
                else
                {
                    var authenticatedUserPolicy = new AuthorizationPolicyBuilder()
                              .RequireAuthenticatedUser()
                              .Build();
                    opts.Filters.Add(new AuthorizeFilter(authenticatedUserPolicy));
                }

            });


            JwtConfiguration(services);
            //services.AddMediatR(typeof(Startup));
            //RegisterServices(services);

            #region === serilog in elastic search

            var elasticUri = "http://apilog.akij.net:8064/";//Configuration["ElasticConfiguration:Uri"];

            //Log.Logger = new LoggerConfiguration()
            //   .Enrich.FromLogContext()
            //   .Enrich.WithExceptionDetails()
            //   .Enrich.WithMachineName()
            //   .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticUri))
            //   {
            //       AutoRegisterTemplate = true,
            //   })
            //.CreateLogger();

            #endregion ================== close

            #region === Swagger generator

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo
            //    {
            //        Version = "v1",
            //        Title = "iBOS Microservice Service"
            //    });

            //    c.EnableAnnotations();
            //    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            //    {
            //        Description = "Enter the request header in the following box to add Jwt To grant authorization Token: Bearer Token",
            //        Name = "Authorization",
            //        In = ParameterLocation.Header,
            //        Type = SecuritySchemeType.ApiKey,
            //        BearerFormat = "JWT",
            //        Scheme = "Bearer"
            //    });

            //    c.AddSecurityRequirement(new OpenApiSecurityRequirement
            //    {
            //        {
            //            new OpenApiSecurityScheme
            //            {
            //                Reference = new OpenApiReference
            //                {
            //                    Type = ReferenceType.SecurityScheme,
            //                    Id = "Bearer"
            //                }
            //            },
            //            new string[] { }
            //        }
            //    });
            //});
            #endregion ======================= close

            #region ==== Rate limit ======

            services.AddMemoryCache();

            //load general configuration from appsettings.json
            //services.Configure<IpRateLimitOptions>(Configuration.GetSection("IpRateLimiting"));

            ////load ip rules from appsettings.json
            //services.Configure<IpRateLimitPolicies>(Configuration.GetSection("IpRateLimitPolicies"));

            //// inject counter and rules stores
            //services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            //services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();


            // Add framework services.
            services.AddMvc();

            // configuration (resolvers, counter key builders)
            //services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            #endregion === Close ========

        }

        private void JwtConfiguration(IServiceCollection services)
        {
            var audienceConfig = Configuration.GetSection("Audience");
            //var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(audienceConfig["Secret"]));
            //var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_env.IsProduction() ? Configuration.GetSection("REACT_APP_SECRET_VALUE").Value.Trim() : audienceConfig["Secret"]));
            //var tokenValidationParameters = new TokenValidationParameters
            //{
            //    ValidateIssuerSigningKey = true,
            //    IssuerSigningKey = signingKey,
            //    ValidateIssuer = true,
            //    ValidIssuer = audienceConfig["Iss"],
            //    ValidateAudience = true,
            //    ValidAudience = audienceConfig["Aud"],
            //    ValidateLifetime = true,
            //    ClockSkew = TimeSpan.Zero,
            //    RequireExpirationTime = true,
            //};

            //services.AddAuthentication(o =>
            //{
            //    o.DefaultAuthenticateScheme = "AuthScheme";
            //})
            //.AddJwtBearer("AuthScheme", x =>
            //{
            //    x.RequireHttpsMetadata = false;
            //    x.TokenValidationParameters = tokenValidationParameters;
            //});
        }
        //private void RegisterServices(IServiceCollection services)
        //{
        //    DependencyContainer.RegisterServices(services);
        //    services.AddHangfireServer();
        //    services.AddSingleton<IHangfires, Hangfires>();

        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider, IWebHostEnvironment env/*, IRecurringJobManager recurringJobManager, IBackgroundJobClient backgroundJobClient, ILoggerFactory loggerFactory*/)
        {
           // app.UseHangfireDashboard();
            //backgroundJobClient.Enqueue(() => Console.WriteLine("jesy"));
            //recurringJobManager.AddOrUpdate(
            //    "Run Every Day",
            //    () => serviceProvider.GetService<IReCurringBill>().BillGenerate(DateTime.UtcNow.AddHours(6)),
            //    Cron.Daily(1, 10)

            //    //"* * * * *"
            //    );
            //recurringJobManager.AddOrUpdate(
            //    "Run Every Day",
            //    () => serviceProvider.GetService<IReCurringBill>().BillGenerate(DateTime.UtcNow.AddHours(6)),
            //    Cron.Daily(5, 10)

            //    //"* * * * *"
            //    );
            //recurringJobManager.AddOrUpdate(
            //    "Run Every Day",
            //    () => serviceProvider.GetService<IReCurringBill>().BillGenerate(DateTime.UtcNow.AddHours(6)),
            //    Cron.Daily(9, 10)

            //    //"* * * * *"
            //    );
            //recurringJobManager.AddOrUpdate(
            //    "Run Every Min",
            //    () => serviceProvider.GetService<ICustomerType>().Test(),
            //    Cron.Daily(6, 10)
            //    );

            // Security Header

            //var policyCollection = new HeaderPolicyCollection()
            //    .AddXssProtectionBlock()
            //    .AddContentTypeOptionsNoSniff()
            //    .AddExpectCTNoEnforceOrReport(0)
            //    .AddStrictTransportSecurityMaxAgeIncludeSubDomains(maxAgeInSeconds: 60 * 60 * 24 * 365) // maxage = one year in seconds
            //    .AddReferrerPolicyStrictOriginWhenCrossOrigin()
            //    .AddContentSecurityPolicy(builder =>
            //    {
            //        builder.AddUpgradeInsecureRequests();
            //        builder.AddDefaultSrc().Self();
            //        builder.AddConnectSrc().From("*");
            //        builder.AddFontSrc().From("*");
            //        builder.AddFrameAncestors().From("*");
            //        builder.AddFrameSource().From("*");
            //        builder.AddWorkerSrc().From("*");
            //        builder.AddMediaSrc().From("*");
            //        builder.AddImgSrc().From("https://erp.ibos.io").Data();
            //        builder.AddObjectSrc().From("*");
            //        builder.AddScriptSrc().From("*").UnsafeInline().UnsafeEval();
            //        builder.AddStyleSrc().From("*").UnsafeEval().UnsafeInline();
            //    })
            //    .RemoveServerHeader();

            //app.UseSecurityHeaders(policyCollection);



            //if (env.IsStaging())
            //{
            //    app.Use(async (context, nextMiddleware) =>
            //    {
            //        // context.Request.EnableRewind();
            //        Stream originalBody = context.Response.Body;

            //        try
            //        {
            //            using (var memStream = new MemoryStream())
            //            {
            //                context.Response.Body = memStream;
            //                await nextMiddleware();

            //                memStream.Position = 0;
            //                string responseBody = new StreamReader(memStream).ReadToEnd();
            //                memStream.Position = 0;
            //                var audienceConfig = Configuration.GetSection("Audience");


            //                byte[] data = Encoding.UTF8.GetBytes(AesOperation.DiscountString(responseBody,
            //                    env.IsProduction() ? Configuration.GetSection("REACT_APP_KEY_NAME").Value : audienceConfig["sec"],
            //                    env.IsProduction() ? Configuration.GetSection("REACT_APP_IV_NAME").Value : audienceConfig["sec"]));

            //                memStream.Write(data, 0, data.Length);


            //                memStream.Position = 0;

            //                await memStream.CopyToAsync(originalBody);
            //            }

            //        }
            //        finally
            //        {
            //            context.Response.Body = originalBody;
            //        }


            //    });

            //}
            //else if (env.IsProduction())
            //{
            //    app.Use(async (context, nextMiddleware) =>
            //    {

            //        Stream originalBody = context.Response.Body;
            //        // Stream originalRequest= context.Request.Body;

            //        try
            //        {
            //            using (var memStream = new MemoryStream())
            //            {
            //                context.Response.Body = memStream;

            //                await nextMiddleware();

            //                memStream.Position = 0;
            //                string responseBody = new StreamReader(memStream).ReadToEnd();
            //                memStream.Position = 0;
            //                //string key = (Configuration.GetSection("REACT_APP_KEY_NAME").Value).Trim();
            //                //string iv = (Configuration.GetSection("REACT_APP_IV_NAME").Value).Trim();

            //                var audienceConfig = Configuration.GetSection("Audience");

            //                //byte[] data = Encoding.UTF8.GetBytes(AesOperation.DiscountString(responseBody, key, iv));

            //                byte[] data = Encoding.UTF8.GetBytes(AesOperation.DiscountString(responseBody,
            //                     audienceConfig["sec"],
            //                     audienceConfig["sec"]));

            //                memStream.Write(data, 0, data.Length);


            //                memStream.Position = 0;

            //                await memStream.CopyToAsync(originalBody);
            //            }

            //        }
            //        finally
            //        {
            //            context.Response.Body = originalBody;
            //        }


            //    });
            //}


            //loggerFactory.AddSerilog();
            //app.UseAllElasticApm(Configuration);



            //app.UseCors(x => x
            //          .AllowAnyOrigin()
            //          .AllowAnyMethod()
            //          .AllowAnyHeader());

            //app.UseHttpsRedirection();
            //app.UseRouting();
            //app.UseAuthentication();
            //app.UseAuthorization();
            //app.ConfigureCustomExceptionMiddleware();
            //Enable Swagger middleware and endpoint
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "bms/swagger/{documentName}/swagger.json";
            });

            //specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/bms/swagger/v1/swagger.json", "Billing Management System");
                c.RoutePrefix = "bms/swagger";
            });

            //ConfigureEventBus(app);

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }
    }
}
