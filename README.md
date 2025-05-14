# Manage Student Credits Backend

Manage student credits by subject

## Modify connection string

You must modify the connection string to access PostgreSQL locally from the **StudentCredits.API/appsettings.json** file.

The **ConnectionStrings** property has two connection types: **LocalConnection** and **DockerConnection**.

```json
{
  "ConnectionStrings": {
    "LocalConnection": "Host=localhost;Port=5432;Database=StudentCredits;Username=postgres;Password=root;Timeout=30;SSL Mode=Prefer;Trust Server Certificate=True",
    "DockerConnection": "Host=host.docker.internal;Port=5432;Database=StudentCredits;Username=postgres;Password=root;Timeout=30;SSL Mode=Prefer;Trust Server Certificate=True"
  }
}
```

If you want to use **DockerConnection** it is important to **allow remote PostgreSQL** connection so that there are no errors

### Windows

Open a **PowerShell** or **cmd** to run the following command. First you need to **check which version of PostgreSQL** you have installed.

```bash
pg_ctl.exe -D "C:\Program Files\PostgreSQL\version\data" restart
```

1. Verify that the file **C:\Program Files\PostgreSQL\version\data\postgresql.conf** contains the following\
`listen_addresses = '*'`\
Otherwise, add it
2. Open the file located at the following path **C:\Program Files\PostgreSQL\version\data\pg_hba.conf**\
Add the following and save\
`host    all all 0.0.0.0/0   scram-sha-256`
3. Rerun the above command to restart the **PostgreSQL** server\
`pg_ctl.exe -D "C:\Program Files\PostgreSQL\version\data" restart`

### Linux

1. Verify that the file **/etc/postgresql/version/main/postgresql.conf** contains the following\
`listen_addresses = '*'`\
Otherwise, add it
2. Open the file located at the following path **/etc/postgresql/version/main/pg_hba.conf**\
Add the following and save\
`host    all all 0.0.0.0/0   scram-sha-256`
3. Restart the Linux **PostgreSQL** service\
`sudo service postgresql restart`\
`sudo systemctl restart PostgreSQL`

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
