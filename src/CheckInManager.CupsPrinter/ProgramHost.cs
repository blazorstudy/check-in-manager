using CheckInManager.CupsPrinter.Services.Interfaces;

using Microsoft.Extensions.Hosting;

namespace CheckInManager.CupsPrinter;

/// <summary>
/// Program Host.
/// </summary>
public sealed class ProgramHost : IHostedService
{
    private readonly IPrinterService _printerService;

    /// <summary>
    /// Constructor <see cref="ProgramHost"/>.
    /// </summary>
    public ProgramHost(IPrinterService printerService)
    {
        _printerService = printerService ?? throw new ArgumentNullException(nameof(printerService));
    }

    /// <inheritdoc />
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _printerService.SamplePrint();

        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
