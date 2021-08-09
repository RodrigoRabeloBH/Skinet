FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app
EXPOSE 80

COPY *.sln .
COPY "/Skinet.Api/Skinet.Api.csproj" "/Skinet.Api/"
COPY "/Skinet.Data/Skinet.Data.csproj" "/Skinet.Data/"
COPY "/Skinet.Model/Skinet.Model.csproj" "/Skinet.Model/"
COPY "/Skinet.Service/Skinet.Service.csproj" "/Skinet.Service/"

RUN dotnet restore "/Skinet.Api/Skinet.Api.csproj"


COPY . ./
WORKDIR /app/Skinet.Api
RUN dotnet publish -c Release -o publish 


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/Skinet.Api/publish ./
ENTRYPOINT ["dotnet", "Skinet.Api.dll"]