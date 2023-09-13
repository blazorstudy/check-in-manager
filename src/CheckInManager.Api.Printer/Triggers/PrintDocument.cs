using System.Net;
using System.Net.Mime;

using CheckInManager.Core.Models;
using CheckInManager.CupsPrinter.Services.Interfaces;

using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace CheckInManager.Api.Printer.Triggers;

public class PrintDocument
{
    private readonly ILogger _logger;
    private readonly IPrinterService _printerService;

    public PrintDocument(ILoggerFactory loggerFactory, IPrinterService printerService)
    {
        this._logger = loggerFactory.ThrowIfNullOrDefault().CreateLogger<PrintDocument>();
        this._printerService = printerService.ThrowIfNullOrDefault();
    }

    [Function(nameof(PrintDocument.PrintAsync))]
    [OpenApiOperation(operationId: "generate", tags: new[] { "qrcodes" }, Summary = "Generate a QR code from the given input", Description = "This generates a QR code from the given input text.", Visibility = OpenApiVisibilityType.Important)]
    [OpenApiSecurity(schemeName: "function_key", schemeType: SecuritySchemeType.ApiKey, Name = "x-functions-key", In = OpenApiSecurityLocationType.Header)]
    [OpenApiRequestBody(contentType: MediaTypeNames.Application.Json, bodyType: typeof(MeetUpNameTagModel), Required = true, Description = "The input to print.")]
    [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.Accepted, Summary = "Successful operation.", Description = "This shows the successful operation.")]
    [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Invalid request.", Description = "This indicates the request is invalid.")]
    [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.InternalServerError, Summary = "Internal server error.", Description = "This indicates the server is not working as expected.")]
    public async Task<HttpResponseData> PrintAsync([HttpTrigger(AuthorizationLevel.Function, "POST", Route = "print")] HttpRequestData req)
    {
        this._logger.LogInformation("C# HTTP trigger function processed a request.");

        var model = await req.ReadFromJsonAsync<MeetUpNameTagModel>();
        if (model.IsNullOrDefault())
        {
            this._logger.LogError("Invalid request.");

            return req.CreateResponse(HttpStatusCode.BadRequest);
        }

        try
        {
            await this._printerService.PrintAsync(model);

            this._logger.LogInformation($"Model - Name: {model.Name}, Company: {model.Company}");

            return req.CreateResponse(HttpStatusCode.Accepted);
        }
        catch (Exception ex)
        {
            this._logger.LogError($"Something wrong: {ex.Message}");

            return req.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
}
