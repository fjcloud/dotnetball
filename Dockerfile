FROM registry.access.redhat.com/ubi8/dotnet-80:8.0 AS build
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM registry.access.redhat.com/ubi8/dotnet-80-runtime:8.0
WORKDIR /app
COPY --from=build /app/out .
USER 1001
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
CMD ["dotnet", "Magic8Ball.dll"]
