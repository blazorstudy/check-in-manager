using System.Net;
using System.Net.Mime;

using CheckInManager.QRGenerator.Enums;
using CheckInManager.QRGenerator.Services.Interfaces;

using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace CheckInManager.Api.QRGenerator.Triggers;

/// <summary>
/// This represents the HTTP trigger entity to generate QR code.
/// </summary>
public class GenerateQRCode
{
    private readonly ILogger _logger;
    private readonly IQRGeneratorService _qrGeneratorService;

    /// <summary>
    /// Initializes a new instance of the <see cref="GenerateQRCode"/> class.
    /// </summary>
    /// <param name="loggerFactory"><see cref="ILoggerFactory"/> instance.</param>
    /// <param name="qrGeneratorService"><see cref="IQRGeneratorService"/> instance.</param>
    public GenerateQRCode(ILoggerFactory loggerFactory, IQRGeneratorService qrGeneratorService)
    {
        this._logger = loggerFactory.ThrowIfNullOrDefault().CreateLogger<GenerateQRCode>();
        this._qrGeneratorService = qrGeneratorService.ThrowIfNullOrDefault();
    }

    /// <summary>
    /// Invokes the HTTP trigger endpoint to generate QR code.
    /// </summary>
    /// <param name="req"><see cref="HttpRequestData"/> instance.</param>
    /// <returns>Returns the generated QR code.</returns>
    [Function(nameof(GenerateQRCode.GenerateAsync))]
    [OpenApiOperation(operationId: "generate", tags: new[] { "qrcodes" }, Summary = "Generate a QR code from the given input", Description = "This generates a QR code from the given input text.", Visibility = OpenApiVisibilityType.Important)]
    [OpenApiSecurity(schemeName: "function_key", schemeType: SecuritySchemeType.ApiKey, Name = "x-functions-key", In = OpenApiSecurityLocationType.Header)]
    [OpenApiRequestBody(contentType: MediaTypeNames.Text.Plain, bodyType: typeof(string), Required = true, Description = "The input for QR code generation.")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: MediaTypeNames.Image.Png, bodyType: typeof(byte[]), Summary = "The generated QR code.", Description = "This returns the QR code generated from the text input.")]
    [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Invalid request.", Description = "This indicates the request is invalid.")]
    [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.InternalServerError, Summary = "Internal server error.", Description = "This indicates the server is not working as expected.")]
    public async Task<HttpResponseData> GenerateAsync([HttpTrigger(AuthorizationLevel.Function, "POST", Route = "generate")] HttpRequestData req)
    {
        this._logger.LogInformation("C# HTTP trigger function processed a request.");

        var model = await req.ReadAsStringAsync();
        if (model is null)
        {
            this._logger.LogError("Invalid request.");

            return req.CreateResponse(HttpStatusCode.BadRequest);
        }

        try
        {
            var qrData = this._qrGeneratorService.Generate(ImageType.Png, model);

            this._logger.LogInformation($"Is success: {qrData.Length != 0}");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", MediaTypeNames.Image.Png);
            response.WriteBytes(qrData);

            return response;
        }
        catch (Exception ex)
        {
            this._logger.LogError($"Something wrong: {ex.Message}");

            return req.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
}
