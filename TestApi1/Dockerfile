#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TestApi1/TestApi1.csproj", "TestApi1/"]
RUN dotnet restore "TestApi1/TestApi1.csproj"
COPY . .
WORKDIR "/src/TestApi1"
RUN dotnet build "TestApi1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestApi1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestApi1.dll"]