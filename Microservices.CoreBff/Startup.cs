using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleMicroservices.DataAccess.UnitOfWork;
using GraphiQl;
using GraphQL;
using GraphQL.Types;
using Microservices.CoreBff.GraphQueries;
using Microservices.CoreBff.GraphSchemas;
using Microservices.CoreBff.GraphTypes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Microservices.CoreBff
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<ProjectQuery>();
            services.AddScoped<IDocumentExecuter, DocumentExecuter>();

            services.AddTransient<ProjectGraphType>();
            services.AddTransient<UserGraphType>();

            var serviceProvider = services.BuildServiceProvider();
            services.AddScoped<ISchema>(x => new ProjectSchema(type => (GraphType)serviceProvider.GetService(type))
                { Query = serviceProvider.GetService<ProjectQuery>() });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseGraphiQl();
        }
    }
}
