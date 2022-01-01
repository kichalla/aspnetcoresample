# NOTE: This Dockerfile is supposed to be used from within the context of the published output folder.
# Example: '<repo-root>\out\retail-amd64\ACR.WorkerService\net5.0\publish'
FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
# Copy contents of the 'publish' folder to the docker image
COPY . .

RUN rm -f Dockerfile .dockerignore
ENTRYPOINT ["dotnet", "SampleAspNetCoreWebApiApp.dll"]