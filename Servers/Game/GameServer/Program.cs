using Autofac;
using Autofac.Extensions.DependencyInjection;
using GameServer;
using GameServer.Configs;
using GameServer.Network.GameApplication;
using GameServer.Network.GameApplication.Packets.Listenable.Handlers;
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
            configHost.AddIniFile(
                "Configs/ServerConfig.ini", optional: false);
        })
        .ConfigureServices((builder, services) =>
        {
            services.AddHostedService<Server>();
            services.Configure<ServerConfig>(
                builder.Configuration.GetSection("ServerConfig"));
        })
        .ConfigureContainer<ContainerBuilder>((hostBuilder, builder) =>
        {
            builder.RegisterType<Server>();
            builder.RegisterType<GameApplicationPacketHandler>();
            
            // Регистрация обработчиков пакетов от клиентского приложения
            builder.RegisterAssemblyTypes(typeof(BaseGameApplicationHandler).Assembly)
                .Where(t => typeof(BaseGameApplicationHandler).IsAssignableFrom(t)
                            && t != typeof(BaseGameApplicationHandler) 
                            && !t.IsAbstract)
                .PropertiesAutowired();
            
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