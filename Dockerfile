FROM mcr.microsoft.com/dotnet/aspnet:8.0

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["ProdutoAPI/ProdutoAPI.csproj", "ProdutoAPI/"]
RUN dotnet restore "ProdutoAPI/ProdutoAPI.csproj"

COPY . .
WORKDIR "/src/ProdutoAPI"
RUN dotnet publish "ProdutoAPI.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "ProdutoAPI.dll"]