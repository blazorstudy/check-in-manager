using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Resolvers;

using Newtonsoft.Json.Serialization;

namespace CheckInManager.Api.QRGenerator.Examples;

public class InputExample : OpenApiExample<string>
{
    public override IOpenApiExample<string> Build(NamingStrategy namingStrategy = null)
    {
        var input = Guid.NewGuid();

        this.Examples.Add(OpenApiExampleResolver.Resolve("example", input, namingStrategy));

        return this;
    }
}
