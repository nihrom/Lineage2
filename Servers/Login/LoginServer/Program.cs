using Autofac;
using Autofac.Extensions.DependencyInjection;
using LoginServer;
using LoginServer.Application.Services;
using LoginServer.Network.GameApplication.ClientsNetwork;
using LoginServer.Network.GameApplication.Packets.Listenable.Handlers;
using LoginServer.Network.GameServer.ServersNetwork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .CreateLogger();
    
await CreateHostBuilder(args)
    .Build()
    .RunAsync();

return;

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder()
        .UseServiceProviderFactory(new AutofacServiceProviderFactory())
        .ConfigureHostConfiguration(configHost =>
        {
            configHost.SetBasePath(Directory.GetCurrentDirectory());
            configHost.AddJsonFile("ServerConfig.json", optional: false);
        })
        .ConfigureServices((builder, services) =>
        {
            services.AddHostedService<Server>();
            services.Configure<ServerConfig>(builder.Configuration.GetSection("ServerConfig"));
        })
        .ConfigureContainer<ContainerBuilder>((hostBuilder, builder) =>
        {
            builder.RegisterType<Server>();
            builder.RegisterType<PacketHandlersBuilder>();
            
            // Регистрация обработчиков пакетов от клиентского приложения
            builder.RegisterType<AuthGameGuardHandler>();
            builder.RegisterType<RequestAuthLoginHandler>();
            builder.RegisterType<RequestServerListHandler>();
            builder.RegisterType<RequestServerLoginHandler>();
            
            builder.RegisterType<AccountManager>().SingleInstance();
            builder.RegisterType<ClientsManager>().SingleInstance();
            builder.RegisterType<L2ConnectionsListener>().SingleInstance();
            builder.RegisterType<L2ServersConnectionsListener>().SingleInstance();
        })
        .UseSerilog(Log.Logger, false)
        .UseConsoleLifetime();