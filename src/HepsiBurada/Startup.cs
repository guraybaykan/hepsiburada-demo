using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using MediatR;
using HepsiBurada.Infrastructure;
using NHibernate;
using HepsiBurada.Core.Persistence;
using HepsiBurada.Core.Notifications;

namespace HepsiBurada
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
            services.AddControllers();
            services.AddAutoMapper(this.GetType().Assembly,
                typeof(Service.Initial).Assembly,
                typeof(Infrastructure.Initial).Assembly
                );
            services.AddMediatR(typeof(Service.Initial).Assembly);
            services.AddSwaggerGen();
            AddNHibernate(services);
            AddRepositories(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HepsiBurada API V1");
            });


            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }



        private void AddNHibernate(IServiceCollection services)
        {
            services.AddSingleton<ISessionFactory>(new NHibernateSessionFactory("Data Source=HepsiBurada.db;", true, false).SessionFactory);
            services.AddScoped<ISession>(imp => imp.GetRequiredService<ISessionFactory>().OpenSession());
        }

        private void AddRepositories(IServiceCollection services)
        {
            var interfaces = from t in typeof(HepsiBurada.Core.Initial).Assembly.GetTypes()
                             where t.IsInterface && typeof(IRepository).IsAssignableFrom(t)
                                 && t != typeof(IRepository)
                                 && t != typeof(IRepository<,>)
                             select t;

            var repositories = from t in typeof(HepsiBurada.Infrastructure.Initial).Assembly.GetTypes()
                               where t.IsClass
                                  && !t.IsAbstract
                                  && typeof(IRepository).IsAssignableFrom(t)
                               select t;



            foreach (var interfaceItem in interfaces)
            {
                foreach (var repoItem in repositories)
                {
                    if (interfaceItem.IsAssignableFrom(repoItem))
                    {
                        services.AddScoped(interfaceItem, repoItem);
                        break;
                    }
                }
            }
        }

    }
}
