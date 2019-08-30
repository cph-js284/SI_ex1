FROM mcr.microsoft.com/dotnet/core/sdk:2.2 as base
WORKDIR /app
EXPOSE 4545

COPY . .
RUN dotnet build
RUN dotnet publish -c Release -o /out

FROM mcr.microsoft.com/dotnet/core/runtime:2.2
WORKDIR /app
COPY --from=base ./out .
ENTRYPOINT [ "dotnet", "server.dll" ] 
