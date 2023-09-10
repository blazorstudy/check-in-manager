using CheckInManager.CupsPrinter.Services;
using CheckInManager.CupsPrinter.Services.Interfaces;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CheckInManager.CupsPrinter;

/// <summary>
/// Entry method.
/// </summary>
public class Program
{
    /// <summary>
    /// Main entry point.
    /// </summary>
    /// <param name="args">arguments.</param>
    public static async Task Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);

        builder.Services.AddHostedService<ProgramHost>();
        builder.Services.AddScoped<IPrinterService, PrinterService>();

        using var host = builder.Build();

        await host.RunAsync().ConfigureAwait(false);
    }
}
