using CheckInManager.CupsPrinter.Services;
using CheckInManager.CupsPrinter.Services.Interfaces;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(c => c.AddScoped<IPrinterService, PrinterService>())
    .Build();

host.Run();
