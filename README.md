# Manage Student Credits Backend

Manage student credits by subject

## How to run the API

There are 4 types of processes to run the API from the **StudentCredits.API/Properties/launchSettings.json** file

* **StudentCredits.http**: <http://localhost:5247>
* **StudentCredits.https**: <https://localhost:7092>
* **IIS Express**: <https://localhost:44379>
* **Container (Dockerfile)**

To view the API documentation for Swagger OpenAPI, redirect to **http://../swagger/index.html**

### Run with Docker

If you want to run with **Docker**, you can do so in two ways

* **VisualStudio**: The advantage of Visual Studio is that it allows you to easily create the server securely with a certificate for local access via HTTPS
* **Terminal**: You can also run the commands from the terminal, but without a secure certificate to avoid errors

```bash
docker build -f "StudentCredits.API/Dockerfile" --force-rm -t studentcreditsapi:dev .
```

```bash
docker run --rm -it -e "ASPNETCORE_ENVIRONMENT=Development" -e "ASPNETCORE_URLS=http://+:403" -e "ASPNETCORE_HTTP_PORTS=22163" -e "PROCESS_TYPE=docker" -p 22163:403 --name StudentCredits.API studentcreditsapi:dev
```
