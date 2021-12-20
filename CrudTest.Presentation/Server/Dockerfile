FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CrudTest.Presentation/Server/CrudTest.Presentation.Server.csproj","CrudTest.Presentation/Server/"]
COPY ["CrudTest.Presentation/Shared/CrudTest.Presentation.Shared.csproj","CrudTest.Presentation/Shared/"]
COPY ["CrudTest.Domain/CrudTest.Domain.csproj","CrudTest.Domain/"]
RUN dotnet restore "CrudTest.Presentation/Server/CrudTest.Presentation.Server.csproj" 
COPY . .
RUN dotnet build "CrudTest.Presentation/Server/CrudTest.Presentation.Server.csproj" -c Realese -o /app/build

FROM build AS publish
RUN dotnet publish "CrudTest.Presentation/Server/CrudTest.Presentation.Server.csproj" -c Realese -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet","CrudTest.Presentation.Server.dll" ]