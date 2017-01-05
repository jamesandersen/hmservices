# Dependency Injection

# Secrets

# Logging

# Exception Handling Middleware

# Configuration with Options
* The options from `appsettings.json` are overridden by user secrets (when running in development mode)
* The options from `appsettings.json` OR user secrets are overridden by environment variables such as:
```
SECOptions:MongoConnectionString=mongodb://192.168.1.53:27017
```

# Docker Notes
* Docker for Mac doesn't expose the host system to the container well.  See discussion here: https://github.com/docker/docker/issues/22753
* The workaround is to pass in the current IP of the host machine... 
* Here is a docker command for passing in a Mongo URL to allow the container to hit Mongo runningo on the host

```
docker run -it -p 8080:5000 -e "SECOptions:MongoConnectionString=mongodb://192.168.1.53:27017" -e "SECOptions:DatabaseName=secdata" secservices
```

## Docker - DotNet Core Runtime Only
dotnet restore
dotnet publish -c Release -o out
docker build -f Dockerfile.runtime -t secservices-runtime .
--docker run dotnetapp Hello .NET Core from Docker
docker run -p 8080:5000 -e "SECOptions:MongoConnectionString=mongodb://192.168.1.53:27017" -e "SECOptions:DatabaseName=secdata" secservices-runtime

## Docker Compose with Nginx
* The docker-compose.yml file has been added as a way to launch two docker images into containers together
* Use the command `docker-compose up` or `docker-compose up --build` if the images should be rebuilt
* the `nginx.conf` is copied into the standard nginx image and it expects host names of `appx.local` or `www.appx.local`
* Need to add host file entry from `127.0.0.1 appx.local`
* Then should be able to access the app at http://appx.local/api/secdata/aapl/symbol

## Deploying Docker Compose to ECS
* Install the ECS CLI: http://docs.aws.amazon.com/AmazonECS/latest/developerguide/ECS_CLI_installation.html
* Configure it: http://docs.aws.amazon.com/AmazonECS/latest/developerguide/ECS_CLI_Configuration.html
    * Set the cluster if already created, otherwise create one
* Deploy to ECS `ecs-cli compose --file docker-compose.prod.yml up`