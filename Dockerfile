# Use the official ASP.NET runtime image as base
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Use the .NET SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MyLibrary/MyLibrary.csproj", "MyLibrary/"]
RUN dotnet restore "MyLibrary/MyLibrary.csproj"
COPY . .
WORKDIR "/src/MyLibrary"
RUN dotnet build "MyLibrary.csproj" -c Release -o /app/build

# Publish the app
FROM build AS publish
RUN dotnet publish "MyLibrary.csproj" -c Release -o /app/publish

# Build runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyLibrary.dll"]
