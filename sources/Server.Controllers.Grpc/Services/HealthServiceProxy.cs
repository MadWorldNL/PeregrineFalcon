using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Server.Controllers.Grpc;

namespace MadWorldNL.PeregrineFalcon.Services;

public class HealthServiceProxy : HealthService.HealthServiceBase
{
    public override Task<HealthResponse> CheckHealth(Empty request, ServerCallContext context)
    {
        return Task.FromResult(new HealthResponse()
        {
            IsHealthy = true
        });
    }
}