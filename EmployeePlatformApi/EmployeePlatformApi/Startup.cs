using Autofac;
using EmployeePlatform.DataAccess;
using EmployeePlatform.Database;
using EmployeePlatform.Database.Populate;
using EmployeePlatform.GraphQLServer;
using EmployeePlatform.GraphQLServer.Infrastructure;
using EmployeePlatform.GraphQLServer.Infrastructure.Auth;
using GraphQL.Authorization;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Validation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;

namespace EmployeePlatformApi
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
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IAuthorizationEvaluator, AuthorizationEvaluator>();
            services.AddTransient<IValidationRule, AuthorizationValidationRule>();
            services.AddGraphQL(x =>
            {
                x.ExposeExceptions = true;
            })
            .AddGraphTypes(ServiceLifetime.Scoped)
            .AddDataLoader();
            services.AddTransient<EmployeePlatformContext>();
            services.AddContext(Configuration["connectionString:EmployeePlatformDB"]);
            services.AddHttpContextAccessor();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                          .AddJwtBearer(options =>
                          {
                              options.TokenValidationParameters = new TokenValidationParameters
                              {
                                  ValidateIssuer = true,
                                  ValidateAudience = true,
                                  ValidateLifetime = true,
                                  ValidateIssuerSigningKey = true,
                                  ValidIssuer = Configuration["Jwt:Issuer"],
                                  ValidAudience = Configuration["Jwt:Audience"],
                                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                              };
                          });
            services.AddScoped<JwtSecurityTokenHandler>();
            services.AddControllers().AddNewtonsoftJson();
            services.AddHttpContextAccessor();
            services.AddGraphQLAuth();
        }

        public static void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new InfrastructureModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, EmployeePlatformContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                db.PopulateData();
            }
            app.UseExceptionHandler(builder =>
            {
                builder.Run(
                    async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if (error != null)
                        {
                            context.Response.AddApplicationError(error.Error.Message);
                            await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
                        }
                    });
            });

            app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseAuthentication();
            app.UseGraphQL<EmployeePlatformSchema>("/graphql");
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
