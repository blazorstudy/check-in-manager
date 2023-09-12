using System.Net;
using CheckInManager.Core.Models;
using CheckInManager.CupsPrinter.Services.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace CheckInManager.Api.Printer.Triggers;

public class PrintDocument
{
    private readonly ILogger _logger;
    private readonly IPrinterService _printerService;

    public PrintDocument(ILoggerFactory loggerFactory, IPrinterService printerService)
    {
        _logger = loggerFactory.CreateLogger<PrintDocument>();
        _printerService = printerService ?? throw new ArgumentNullException(nameof(IPrinterService));
    }

    [Function("PrintDocument")]
    public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

        response.WriteString("Welcome to Azure Functions!");

        // todo: 가져온 데이터에서 model 만들 필요.
        var model = new MeetUpNameTagModel
        {
            Name = "User Name",
        };

        response.WriteString($"Model - Name: {model.Name}, Company: {model.Company}");

        _printerService.PrintAsync(model);

        response.WriteString("Done!");

        return response;
    }
}
