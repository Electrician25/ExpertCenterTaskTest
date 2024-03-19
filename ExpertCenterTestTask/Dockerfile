FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ExpertCenterTestTask.csproj", "./"]
RUN dotnet restore "ExpertCenterTestTask.csproj"
COPY . .
RUN dotnet build "ExpertCenterTestTask.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ExpertCenterTestTask.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 5001
ENTRYPOINT dotnet ExpertCenterTestTask.dll --urls "http://0.0.0.0:5001/"