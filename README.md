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