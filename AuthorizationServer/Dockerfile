FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS publish
COPY ["AuthorizationServer/AuthorizationServer.csproj", "AuthorizationServer/"]
RUN dotnet restore "AuthorizationServer/AuthorizationServer.csproj"
COPY . .
WORKDIR "/src/ResourceServer"
RUN dotnet publish "ResourceServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ResourceServer.dll"]