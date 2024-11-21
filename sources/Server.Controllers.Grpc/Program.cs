using MadWorldNL.PeregrineFalcon.Services;

const string defaultPolicyName = "DefaultPolicy";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

builder.Services.AddCors(o => o.AddPolicy(defaultPolicyName, policy =>
{
    policy
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcReflectionService();
app.UseGrpcWeb();

app.UseCors(defaultPolicyName);

app.MapGrpcService<CurriculumVitaeServiceProxy>().EnableGrpcWeb();
app.MapGrpcService<HealthServiceProxy>().EnableGrpcWeb();

app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();