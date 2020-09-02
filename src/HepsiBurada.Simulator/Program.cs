using System;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using Autofac;
using MediatR;
using HepsiBurada.Simulator.Commands;


namespace HepsiBurada.Simulator
{
    class Program
    {
        private static IContainer _container;
        static async Task Main(string[] args)
        {
            try
            {
                RegisterDI();

                using (var scope = _container.BeginLifetimeScope())
                {
                    var mediator = scope.Resolve<IMediator>();
                    await mediator.Send(new CreateProduct());
                }

                string filePath = GetFilePath(args);

                int lineCount = 1;
                await foreach(var line in GetLine(filePath))
                {
                    var command = new CommandBuilder(line, lineCount++);
                    command.GetCommand();
                }


                Console.WriteLine("Hello World!");

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        static string GetFilePath(string[] args)
        {
            if (args is null || args.Length == 0)
            {
                throw new InvalidOperationException("Please enter your command file path");
            }
            var filePath = args[0];

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File Fot Found");
            }
            return filePath;
        }


        static async IAsyncEnumerable<string> GetLine(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);
            string line = null;
            do
            {
                line = await sr.ReadLineAsync();
                yield return line;
            } while (!sr.EndOfStream);
            sr.Dispose();
        }
    
        static void RegisterDI()
        {
            var builder = new ContainerBuilder();
            builder
                .RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            builder.RegisterAssemblyTypes(typeof(Program).Assembly).AsImplementedInterfaces();
            _container = builder.Build();
        }
    
    }
}
