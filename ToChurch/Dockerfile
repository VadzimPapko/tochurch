FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 60273
EXPOSE 44379

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["ToChurch/ToChurch.csproj", "ToChurch/"]
RUN dotnet restore "ToChurch/ToChurch.csproj"
COPY . .
WORKDIR "/src/ToChurch"
RUN dotnet build "ToChurch.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ToChurch.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ToChurch.dll"]