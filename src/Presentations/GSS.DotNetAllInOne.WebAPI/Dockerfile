#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Presentations/GSS.DotNetAllInOne.WebAPI/GSS.DotNetAllInOne.WebAPI.csproj", "Presentations/GSS.DotNetAllInOne.WebAPI/"]
COPY ["Core/Application/GSS.DotNetAllInOne.Application/GSS.DotNetAllInOne.Application.csproj", "Core/Application/GSS.DotNetAllInOne.Application/"]
COPY ["Core/Domain/GSS.DotNetAllInOne.Domain/GSS.DotNetAllInOne.Domain.csproj", "Core/Domain/GSS.DotNetAllInOne.Domain/"]
RUN dotnet restore "Presentations/GSS.DotNetAllInOne.WebAPI/GSS.DotNetAllInOne.WebAPI.csproj"
COPY . .
WORKDIR "/src/Presentations/GSS.DotNetAllInOne.WebAPI"
RUN dotnet build "GSS.DotNetAllInOne.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GSS.DotNetAllInOne.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GSS.DotNetAllInOne.WebAPI.dll"]