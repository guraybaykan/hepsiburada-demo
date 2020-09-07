using System;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using Autofac;
using MediatR;
using HepsiBurada.Simulator.Commands;
using HepsiBurada.Simulator.Model;
using System.Net.Http;
using AutoMapper;
using AutoMapper.Contrib.Autofac.DependencyInjection;

namespace HepsiBurada.Simulator
{
    class Program
    {
        private static IContainer _container;
        private static IMediator _mediator;
        static async Task Main(string[] args)
        {
            try
            {
                RegisterDI();
                using (var scope = _container.BeginLifetimeScope())
                {
                    _mediator = scope.Resolve<IMediator>();


                    string filePath = GetFilePath(args);

                    int lineCount = 1;
                    var commandList = new List<CommandProto>();

                    await foreach (var line in GetLine(filePath))
                    {
                        var command = new CommandBuilder(line, lineCount++);
                        var (commandType, @params) = command.GetCommand();
                        commandList.Add(new CommandProto
                        {
                            CommandType = commandType,
                            Parameters = @params
                        });
                    }

                    System.Console.WriteLine("Command file is parsed succesfully");

                    foreach (CommandProto command in commandList)
                    {
                        var result = await RunCommand(command);
                        if (!result.IsSucceed)
                        {
                            throw new OperationCanceledException($"{command.CommandType} step is not succeed. Aborting.");
                        }
                        System.Console.WriteLine($"{command.CommandType}>> {result.Output}");
                    }
                }
                System.Console.WriteLine("Simulation run is successfull");

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
        static async Task<CommandResult> RunCommand(CommandProto commandProto)
        {
            return commandProto.CommandType switch
            {
                CommandType.create_campaign => await _mediator.Send(new CreateCampaing(commandProto.Parameters)),
                CommandType.create_order => await _mediator.Send(new CreateOrder(commandProto.Parameters)),
                CommandType.create_product => await _mediator.Send(new CreateProduct(commandProto.Parameters)),
                CommandType.get_campaign_info => await _mediator.Send(new GetCampaignInfo(commandProto.Parameters)),
                CommandType.get_product_info => await _mediator.Send(new GetProductInfo(commandProto.Parameters)),
                CommandType.increase_time => await _mediator.Send(new IncreaseTime(commandProto.Parameters)),
                _ => throw new InvalidOperationException("Code is not implementes")
            };
        }
        static void RegisterDI()
        {
            var builder = new ContainerBuilder();

            builder.Register((ctx => new HttpClient() { BaseAddress = new Uri("http://localhost:5000/") }))
                .Named<HttpClient>("client")
                .As<HttpClient>()
                .SingleInstance();

            builder
                .RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            builder.AddAutoMapper(typeof(Program).Assembly);

            builder.RegisterAssemblyTypes(typeof(Program).Assembly).AsImplementedInterfaces();
            _container = builder.Build();
        }


    }
}
