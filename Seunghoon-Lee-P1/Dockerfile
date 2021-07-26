#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Seunghoon-Lee-P1/Seunghoon-Lee-P1.csproj", "Seunghoon-Lee-P1/"]
RUN dotnet restore "Seunghoon-Lee-P1/Seunghoon-Lee-P1.csproj"
COPY . .
WORKDIR "/src/Seunghoon-Lee-P1"
RUN dotnet build "Seunghoon-Lee-P1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Seunghoon-Lee-P1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Seunghoon-Lee-P1.dll"]