using System.Runtime.CompilerServices;
using KORM.Cli;
using KORM.Cli.Dtos;
using KORM.Interfaces;
using KORM.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

const string CLUSTER = "https://core.westeurope.kusto.windows.net";
const string DATABASE = "ReferenceData";

IConfigurationRoot configuration = null;
var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((builder, config) =>
    {
        config.AddJsonFile("appsettings.json", false);
        config.AddJsonFile($"appsettings.{builder.HostingEnvironment.EnvironmentName}.json", true);
    })
    .ConfigureServices((builder, services) =>
    {
        services.Configure<AppConfiguration>(builder.Configuration.GetSection("General"));
        services.AddHostedService<App>();
    });

await host.RunConsoleAsync();
//var opts = new DefaultConnectionOptions(CLUSTER, "", DATABASE);
//var connector = new KustoConnector(opts);

//var sm = new SchemaMapper(connector);
//var schema = sm.CreateSchema("RadarEnduranceRunSensorData10Hz");

//var gen = new Generator(new DefaultGeneratorOptions());
//gen.GenerateEntity("KORM.Cli", schema);

//var db = new KustoDatabase(connector);
//var myData = db.Fetch<RadarEnduranceRunSensorData10Hz>("RadarEnduranceRunSensorData10Hz | limit 2");

//Console.Write("Generation complete, press enter to exit.");
//Console.Read();