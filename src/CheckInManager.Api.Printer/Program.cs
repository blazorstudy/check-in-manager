using CheckInManager.CupsPrinter.Services;
using CheckInManager.CupsPrinter.Services.Interfaces;

using Microsoft.Azure.Functions.Worker.Extensions.OpenApi.Extensions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults(worker => worker.UseNewtonsoftJson())
    .ConfigureHostConfiguration(config => config.AddEnvironmentVariables())
    .ConfigureServices(services =>
    {
        services.AddSingleton<IOpenApiConfigurationOptions>(_ =>
        {
            var options = new OpenApiConfigurationOptions()
            {
                OpenApiVersion = OpenApiVersionType.V3,
                Info = new OpenApiInfo()
                {
                    Version = DefaultOpenApiConfigurationOptions.GetOpenApiDocVersion(),
                    Title = DefaultOpenApiConfigurationOptions.GetOpenApiDocTitle(),
                    Description = DefaultOpenApiConfigurationOptions.GetOpenApiDocDescription(),
                    License = new OpenApiLicense()
                    {
                        Name = "MIT",
                        Url = new Uri("http://opensource.org/licenses/MIT"),
                    }
                },
            };

            return options;
        });

        services.AddScoped<IPrinterService, PrinterService>();
    })
    .Build();

await host.RunAsync();
