#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
COPY . /app
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["exercise-8.csproj", "./"]
RUN dotnet restore "exercise-8.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "exercise-8.csproj" -c Release -o /app/build

RUN chmod +x ./entrypoint.sh

CMD /bin/bash ./entrypoint.sh

FROM build AS publish
RUN dotnet publish "exercise-8.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "exercise-8.dll"]
