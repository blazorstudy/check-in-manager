using CheckInManager.QRGenerator.Services;
using CheckInManager.QRGenerator.Services.Interfaces;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(c => c.AddScoped<IQRGeneratorService, QRGeneratorService>())
    .Build();

host.Run();
