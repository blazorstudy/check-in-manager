using System.Net;
using System.Net.Mime;

using CheckInManager.Core.Models;
using CheckInManager.QRGenerator.Services.Interfaces;

using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace CheckInManager.Api.QRGenerator.Triggers;

public class GenerateQRCode
{
    private readonly ILogger _logger;
    private readonly IQRGeneratorService _qrGeneratorService;

    public GenerateQRCode(ILoggerFactory loggerFactory, IQRGeneratorService qrGeneratorService)
    {
        _logger = loggerFactory.CreateLogger<GenerateQRCode>();
        _qrGeneratorService = qrGeneratorService ?? throw new ArgumentNullException(nameof(qrGeneratorService));
    }

    [Function("GenerateQRCode")]
    public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        // todo: 가져온 데이터에서 model 만들 필요.
        var model = new MeetUpNameTagModel
        {
            Name = "User Name",
        };

        var qrData = _qrGeneratorService.CreateFrom(model);

        _logger.LogInformation($"Is success: {qrData.Length != 0}");

        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", MediaTypeNames.Image.Png);
        response.WriteBytes(qrData.ToArray());
        return response;
    }
}
