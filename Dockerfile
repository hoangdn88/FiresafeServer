FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /app/FiresafeServer
EXPOSE 12000
# copy csproj and restore as distinct layers
COPY *.sln .
COPY Common/*.csproj ./Common/
COPY FireFact/*.csproj ./FireFact/

RUN dotnet restore

# copy everything else and build app
COPY Common/. ./Common/
COPY FireFact/. ./FireFact/

WORKDIR /app/FiresafeServer/FireFact
RUN dotnet publish -c release -o out

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app/FiresafeServer/FireFact
COPY --from=build-env /app/FiresafeServer/FireFact/out .

ENV ASPNETCORE_URLS=http://+:12000
#ENV SERVICE=FireFact

ENTRYPOINT ["dotnet", "FireFact.dll"]