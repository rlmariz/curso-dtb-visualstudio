using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBelli.AcessoDados.Construtores;
using DataBelli.AcessoDados.Executores;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DataBell.WebApi.Produto
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
            var ConnectionString = Configuration.GetSection("DataBelli")["ConnectionString"];
            services.AddScoped(typeof(IQueryBuilder<>), typeof(MsSqlServerQueryBuilder<>));
            //services.AddScoped(typeof(IQueryExec<>), typeof(QueryExec<>));
            //services.AddScoped(typeof(IRepositorio), typeof(Repositorio));
            services.AddScoped(typeof(IQueryExec<>), 
                   (provider) => 
                   {
                        return new QueryExec<Produto>(provider.GetService<IQueryBuilder<Produto>>(), ConnectionString);
                    }
                   );
            services.Configure<DataBase>(this.Configuration.GetSection(nameof(DataBase)));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
