using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .CreateLogger();

await CreateHostBuilder(args)
    .Build()
    .RunAsync();

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder()
        .UseServiceProviderFactory(new AutofacServiceProviderFactory())
        .ConfigureHostConfiguration(configHost =>
        {
            configHost.SetBasePath(Directory.GetCurrentDirectory());
            configHost.AddJsonFile("ServerConfig.json", optional: true);
        })
        .UseSerilog()
        .UseConsoleLifetime();