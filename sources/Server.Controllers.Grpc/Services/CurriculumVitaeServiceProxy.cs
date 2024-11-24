using Grpc.Core;
using Server.Controllers.Grpc;

namespace MadWorldNL.PeregrineFalcon.Services;

public class CurriculumVitaeServiceProxy : CurriculumVitaeService.CurriculumVitaeServiceBase
{
    public override Task<CreateCurriculumVitaeResponse> CreateCurriculumVitae(CreateCurriculumVitaeRequest request, ServerCallContext context)
    {
        return Task.FromResult(new CreateCurriculumVitaeResponse());
    }

    public override Task<GetCurriculumVitaeResponse> GetCurriculumVitae(GetCurriculumVitaeRequest request, ServerCallContext context)
    {
        return Task.FromResult(new GetCurriculumVitaeResponse()
        {
            CurriculumVitae = new CurriculumVitae()
        });
    }

    public override Task<PatchCurriculumVitaeResponse> PatchCurriculumVitae(PatchCurriculumVitaeRequest request, ServerCallContext context)
    {
        return Task.FromResult(new PatchCurriculumVitaeResponse());
    }
}