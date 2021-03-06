FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
RUN apt-get update && \
    apt-get install -y ffmpeg
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/AzTranslate.WebApp/AzTranslate.WebApp.csproj", "src/AzTranslate.WebApp/"]
RUN dotnet restore "src/AzTranslate.WebApp/AzTranslate.WebApp.csproj"
COPY . .
WORKDIR "/src/src/AzTranslate.WebApp"
RUN dotnet build "AzTranslate.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AzTranslate.WebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AzTranslate.WebApp.dll"]