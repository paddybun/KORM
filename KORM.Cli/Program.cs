using KORM.Cli.Dtos;
using KORM.Cli.Services;
using KORM.Service;

const string CLUSTER = "";
const string DATABASE = "";

var opts = new DefaultConnectionOptions(CLUSTER, "", DATABASE);
var connector = new KustoConnector(opts);

var sm = new SchemaMapper(connector);
var schema = sm.CreateSchema("FleaJeep10HzDebug");

var gen = new Generator(new DefaultGeneratorOptions());
gen.GenerateEntity("KORM.Cli", schema);

Console.Write("Generation complete, press enter to exit.");
Console.Read();