#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["QuizMaster.API/QuizMaster.API.csproj", "QuizMaster.API/"]
COPY ["QuizMaster.BusinessLogic/QuizMaster.BusinessLogic.csproj", "QuizMaster.BusinessLogic/"]
COPY ["QuizMaster.DataAccess/QuizMaster.DataAccess.csproj", "QuizMaster.DataAccess/"]
RUN dotnet restore "./QuizMaster.API/./QuizMaster.API.csproj"
COPY . .
WORKDIR "/src/QuizMaster.API"
RUN dotnet build "./QuizMaster.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./QuizMaster.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QuizMaster.API.dll"]