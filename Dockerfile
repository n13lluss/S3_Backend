## Build stage
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#WORKDIR /src
#
## Copying solution file and restoring dependencies
#COPY *.sln .
#COPY Travelblog.Api/*.csproj ./Travelblog.Api/
#COPY Travelblog.Core/*.csproj ./Travelblog.Core/
#COPY Travelblog.Dal/*.csproj ./Travelblog.Dal/
#COPY Travelblog.Unittest/*.csproj ./Travelblog.Unittest/
#RUN dotnet restore
#
## Copying the rest of the code and building
#COPY . .
#RUN dotnet build -c Release --no-restore
#
## Publish stage
#FROM build AS publish
#RUN dotnet publish Travelblog.Api/Travelblog.Api.csproj -c Release -o /app/publish
#
## Final stage
#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Travelblog.Api.dll"]
## Expose port 7177
#EXPOSE 7177

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy only the project files
COPY *.sln .
COPY Travelblog.Api/*.csproj ./Travelblog.Api/
COPY Travelblog.Core/*.csproj ./Travelblog.Core/
COPY Travelblog.Dal/*.csproj ./Travelblog.Dal/
COPY Travelblog.Unittest/*.csproj ./Travelblog.Unittest/

# Restore dependencies
RUN dotnet restore

# Copy the rest of the source code and build
COPY . .
RUN dotnet build -c $BUILD_CONFIGURATION -o /app/build

# Publish stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
USER app
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Travelblog.Api.dll"]
EXPOSE 7177

