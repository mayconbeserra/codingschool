FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app/tests

# copy csproj and restore as distinct layers
COPY src/*.csproj ./
WORKDIR /app/tests
RUN dotnet restore

# copy and publish app
WORKDIR /app/tests
COPY src/. ./
COPY scripts/* ./

# run Tests
FROM build AS testrunner
WORKDIR /app/tests
ENTRYPOINT ["sh", "run-tests.sh"]
