using Autofac;
using Autofac.Extensions.DependencyInjection;
using GameServer;
using GameServer.Network.GameApplication.ClientsNetwork;
using GameServer.Network.LoginServer.LoginServerNetwork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .CreateLogger();

//await LoginServerNetworkManager.StartAsync();

await CreateHostBuilder(args)
    .Build()
    .RunAsync();

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder()
        .UseServiceProviderFactory(new AutofacServiceProviderFactory())
        .ConfigureHostConfiguration(configHost =>
        {
            configHost.SetBasePath(Directory.GetCurrentDirectory());
            configHost.AddJsonFile(
                "GameServerConfig.json", optional: false);
        })
        .ConfigureServices((builder, services) =>
        {
            services.AddHostedService<Server>();
            services.Configure<GameServerConfig>(
                builder.Configuration.GetSection("GameServerConfig"));
        })
        .ConfigureContainer<ContainerBuilder>((hostBuilder, builder) =>
        {
            builder.RegisterType<Server>();
            builder.RegisterType<PacketHandlersBuilder>();
            
            // // Регистрация обработчиков пакетов от клиентского приложения
            // builder.RegisterType<AuthGameGuardHandler>();
            // builder.RegisterType<RequestAuthLoginHandler>();
            // builder.RegisterType<RequestServerListHandler>();
            // builder.RegisterType<RequestServerLoginHandler>();
            //
            // // Регистрация сервис менеджеров
            // builder.RegisterType<AccountManager>().SingleInstance();
            builder.RegisterType<ClientsManager>().SingleInstance();
            // builder.RegisterType<ServersManager>().SingleInstance();
            //
            builder.RegisterType<L2ConnectionsListener>().SingleInstance();
            // builder.RegisterType<L2ServersConnectionsListener>().SingleInstance();
        })
        .UseSerilog(Log.Logger, false)
        .UseConsoleLifetime();