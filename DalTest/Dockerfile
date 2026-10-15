# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

<<<<<<< HEAD
# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
=======
# Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
# For more information, please see https://aka.ms/containercompat

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/runtime:8.0-nanoserver-1809 AS base
>>>>>>> partner-repo/main
WORKDIR /app


# This stage is used to build the service project
<<<<<<< HEAD
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
=======
FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
>>>>>>> partner-repo/main
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DalTest/DalTest.csproj", "DalTest/"]
RUN dotnet restore "./DalTest/DalTest.csproj"
COPY . .
WORKDIR "/src/DalTest"
<<<<<<< HEAD
RUN dotnet build "./DalTest.csproj" -c $BUILD_CONFIGURATION -o /app/build
=======
RUN dotnet build "./DalTest.csproj" -c %BUILD_CONFIGURATION% -o /app/build
>>>>>>> partner-repo/main

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
<<<<<<< HEAD
RUN dotnet publish "./DalTest.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
=======
RUN dotnet publish "./DalTest.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false
>>>>>>> partner-repo/main

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DalTest.dll"]