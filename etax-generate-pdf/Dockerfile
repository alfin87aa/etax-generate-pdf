#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["etax-generate-pdf/etax-generate-pdf.csproj", "etax-generate-pdf/"]
RUN dotnet restore "etax-generate-pdf/etax-generate-pdf.csproj"
COPY . .
WORKDIR "/src/etax-generate-pdf"
RUN dotnet build "etax-generate-pdf.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "etax-generate-pdf.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "etax-generate-pdf.dll"]