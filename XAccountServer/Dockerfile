#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["XAccountServer/XAccountServer.csproj", "XAccountServer/"]
RUN dotnet restore "XAccountServer/XAccountServer.csproj"
COPY . .
WORKDIR "/src/XAccountServer"
RUN dotnet build "XAccountServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "XAccountServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN chown -R 1000:100 /app/
USER 1000:1000
ENTRYPOINT ["dotnet", "XAccountServer.dll"]