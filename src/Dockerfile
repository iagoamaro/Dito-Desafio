FROM microsoft/dotnet:sdk AS build-env
WORKDIR /src

# Copy everything and build
COPY . ./

RUN dotnet restore "./dito.csproj"
RUN dotnet publish "dito.csproj" -c Release -o out


FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /src
COPY --from=build-env /src/out .
ENTRYPOINT ["dotnet", "dito.dll"]
