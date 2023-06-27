using KORM.Cli.Dtos;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace KORM.Cli;

public class App: IHostedService
{
    public App(IOptions<AppConfiguration> options)
    {
        
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}