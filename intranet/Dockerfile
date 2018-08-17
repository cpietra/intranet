FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["intranet/intranet.csproj", "intranet/"]
RUN dotnet restore "intranet/intranet.csproj"
COPY . .
WORKDIR "/src/intranet"
RUN dotnet build "intranet.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "intranet.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "intranet.dll"]