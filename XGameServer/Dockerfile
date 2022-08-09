#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["XGameServer/XGameServer.csproj", "XGameServer/"]
COPY ["Library/Library.csproj", "Library/"]
COPY ["GamePackets/GamePackets.csproj", "GamePackets/"]
RUN dotnet restore "XGameServer/XGameServer.csproj"
COPY . .
WORKDIR "/src/XGameServer"
RUN dotnet build "XGameServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "XGameServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN chown -R 1000:100 /app/
USER 1000:1000
ENTRYPOINT ["dotnet", "XGameServer.dll"]