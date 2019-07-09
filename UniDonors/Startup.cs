using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using UniDonors.DataLayer.Models;
using UniDonors.DataLayer.Repositories;
using Swashbuckle.AspNetCore.Swagger;
using UniDonors.Infrastructure;

namespace UniDonors
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
            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.ReturnHttpNotAcceptable = true;
                options.InputFormatters.Add(new XmlSerializerInputFormatter());
                options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
            });

            services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });
            services.AddRouting(options => { options.ConstraintMap.Add("eventId", typeof(EventIdRouteConstraint)); });

            services.AddSingleton<IRepository<Donor>, DonorMemoryRepository>();
            services.AddSingleton<IRepository<Organization>, OrganizationMemoryRepository>();
            services.AddSingleton<IRepository<DonorOrganization>, DonorOrganizationMemoryRepository>();
            services.AddSingleton<IRepository<Event>, EventMemoryRepository>();

            services.AddSwaggerGen(c =>
                c.SwaggerDoc("UniDonors API", new Info { Title = "UniDonors API" }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
              {
                  c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
              });
        }
    }
}
