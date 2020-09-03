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
using HepsiBurada.Core.Businness;

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
            services.AddAutoMapper(this.GetType().Assembly);
            services.AddMediatR(this.GetType().Assembly);
            AddNHibernate(services);
            AddRepositories(services);
            AddServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            });
        }

        private void AddNHibernate(IServiceCollection services)
        {
            services.AddSingleton<ISessionFactory>(new NHibernateSessionFactory("Data Source=HepsiBurada.db;", true, false).SessionFactory);
            services.AddScoped<ISession>(imp => imp.GetRequiredService<ISessionFactory>().OpenSession());
        }

        private void AddRepositories(IServiceCollection services)
        {
            var interfaces = from t in  typeof(HepsiBurada.Core.Initial).Assembly.GetTypes()
                        where t.IsInterface && typeof(IRepository).IsAssignableFrom(t) 
                            && t != typeof(IRepository) 
                            && t != typeof(IRepository<,>)
                        select t;

            var repositories = from t in  typeof(HepsiBurada.Infrastructure.Initial).Assembly.GetTypes()
                        where t.IsClass
                           && ! t.IsAbstract
                           && typeof(IRepository).IsAssignableFrom(t)  
                        select t;



            foreach( var interfaceItem in interfaces)
            {                
                foreach (var repoItem in repositories)
                {
                    if(interfaceItem.IsAssignableFrom(repoItem))
                    {
                        services.AddScoped(interfaceItem, repoItem);
                        break;
                    }
                }
            }
        }

        private void AddServices(IServiceCollection services)
        {
            var interfaces = from t in  typeof(HepsiBurada.Core.Initial).Assembly.GetTypes()
                        where t.IsInterface && typeof(IService).IsAssignableFrom(t) 
                            && t != typeof(IService)
                        select t;

            var serviceImps = from t in  typeof(HepsiBurada.Service.Initial).Assembly.GetTypes()
            where t.IsClass
                && ! t.IsAbstract
                && typeof(IService).IsAssignableFrom(t)  
            select t;

            
            foreach( var interfaceItem in interfaces)
            {                
                foreach (var serviceImp in serviceImps)
                {
                    if(interfaceItem.IsAssignableFrom(serviceImp))
                    {
                        System.Console.WriteLine(serviceImp.Name);
                        services.AddScoped(interfaceItem, serviceImp);
                        break;
                    }
                }
            }

        }
    }
}
