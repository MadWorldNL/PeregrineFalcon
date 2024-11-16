FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
ARG BUILDPLATFORM
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
EXPOSE 8082

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILDPLATFORM
ARG BUILD_CONFIGURATION=Release

WORKDIR /src
COPY Directory.Build.props .
COPY Directory.Packages.props .
COPY Nuget.Config .

COPY ["Server.Controllers.Grpc/Grpc.csproj", "Server.Controllers.Grpc/"]
RUN dotnet restore "Server.Controllers.Grpc/Grpc.csproj"
COPY . .
WORKDIR "/src/Server.Controllers.Grpc"
RUN dotnet build "Grpc.csproj" -c "$BUILD_CONFIGURATION" -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Grpc.csproj" -c "$BUILD_CONFIGURATION" -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MadWorldNL.PeregrineFalcon.Server.Controllers.Grpc.dll"]