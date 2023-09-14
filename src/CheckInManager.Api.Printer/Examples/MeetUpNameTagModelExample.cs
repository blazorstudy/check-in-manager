using CheckInManager.Core.Models;

using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Resolvers;

using Newtonsoft.Json.Serialization;

namespace CheckInManager.Api.Printer.Examples;

public class MeetUpNameTagModelExample : OpenApiExample<MeetUpNameTagModel>
{
    public override IOpenApiExample<MeetUpNameTagModel> Build(NamingStrategy namingStrategy = null)
    {
        var model = new MeetUpNameTagModel
        {
            Name = "홍길동",
            Company = "블레이저코리아"
        };

        this.Examples.Add(OpenApiExampleResolver.Resolve("example", model, namingStrategy));

        return this;
    }
}
