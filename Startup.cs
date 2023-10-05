using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Candidates.Interfaces;
using Candidates.Infrastructure;
using Candidates.Hubs;
using Candidates.Services.Queries;

namespace Candidates.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Trace.AutoFlush = true;
            Trace.Indent();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSwaggerDocument();

            services.AddDbContext<CandidatesContext>(opt =>
            {
                opt.UseInMemoryDatabase("Candidates");
            });

            services.AddScoped<ICandidateCommandService, CandidateCommandService>();
            services.AddScoped<ICandidateQueryService, CandidateQueryService>();
           
            services.AddControllers(mvcOpts =>
            {
            });

            services.AddSignalR();
        }


        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<NotificationHub>("/notificationHub");
            });

            app.UseOpenApi();
            app.UseSwaggerUi3();

        }
    }
}
