#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/RSCO.LoanManagement.Web.Mvc/RSCO.LoanManagement.Web.Mvc.csproj", "src/RSCO.LoanManagement.Web.Mvc/"]
COPY ["src/RSCO.LoanManagement.Web.Core/RSCO.LoanManagement.Web.Core.csproj", "src/RSCO.LoanManagement.Web.Core/"]
COPY ["src/RSCO.LoanManagement.Application/RSCO.LoanManagement.Application.csproj", "src/RSCO.LoanManagement.Application/"]
COPY ["src/RSCO.LoanManagement.Application.Shared/RSCO.LoanManagement.Application.Shared.csproj", "src/RSCO.LoanManagement.Application.Shared/"]
COPY ["src/RSCO.LoanManagement.Core.Shared/RSCO.LoanManagement.Core.Shared.csproj", "src/RSCO.LoanManagement.Core.Shared/"]
COPY ["src/RSCO.LoanManagement.Core/RSCO.LoanManagement.Core.csproj", "src/RSCO.LoanManagement.Core/"]
COPY ["src/RSCO.LoanManagement.EntityFrameworkCore/RSCO.LoanManagement.EntityFrameworkCore.csproj", "src/RSCO.LoanManagement.EntityFrameworkCore/"]
COPY ["src/RSCO.LoanManagement.GraphQL/RSCO.LoanManagement.GraphQL.csproj", "src/RSCO.LoanManagement.GraphQL/"]
RUN dotnet restore "src/RSCO.LoanManagement.Web.Mvc/RSCO.LoanManagement.Web.Mvc.csproj"
COPY . .
WORKDIR "/src/src/RSCO.LoanManagement.Web.Mvc"
RUN dotnet build "RSCO.LoanManagement.Web.Mvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RSCO.LoanManagement.Web.Mvc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RSCO.LoanManagement.Web.Mvc.dll"]
