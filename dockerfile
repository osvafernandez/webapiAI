FROM mrc.microsoft.com/dotnet/sdk:10.0 as build
WORKDIR /src
COPY ["webapiAI.csproj", "./"]
RUN dotnet restore "./webapiAI.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet publish "webapiAI.csproj" -C Release -o /app/publish

FROM base as final
WORKDIR "/app"
COPY --from=build /app/publish .
ENTRYPOINT [ "dotnet", "webapiAI.dll" ]