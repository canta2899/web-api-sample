FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WebApiExample/WebApiExample.csproj", "WebApiExample/"]
RUN dotnet restore "WebApiExample/WebApiExample.csproj"
COPY . .
WORKDIR "/src/WebApiExample"
RUN dotnet build "WebApiExample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApiExample.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApiExample.dll"]
