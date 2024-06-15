using Autofac;
using Autofac.Extensions.DependencyInjection;
using LoginServer;
using LoginServer.ClientsNetwork;
using LoginServer.ServersNetwork;
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
            builder.RegisterType<L2ConnectionsListener>().SingleInstance();
            builder.RegisterType<L2ServersConnectionsListener>().SingleInstance();
        })
        .UseSerilog(Log.Logger, false)
        .UseConsoleLifetime();