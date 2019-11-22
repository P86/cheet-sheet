![logo](./assets/docker.png)

### Display running containers 
```
docker ps
```

### Display running and stopped containers
```
docker ps -a
```

### Run container
```
docker run <id>
```

### Stop container (preserves state)
```
docker stop <id>
```

### Start container (previously stopped)
```
docker start <id>
```

### Mount volume
```
docker run -v <host location>:<container location> <id>
```

### Run container witch attached device 
```
docker run --device=/dev/<source>:/dev/<dest> <id>
```

### Kill all running containers
```
docker kill $(docker -q ps)
```

### Publish ports
```
docker run -p <host port>:<container port>[/protocol]
```

### Run container with interactive terminal
```
docker run -it <image>
```

### Run shell in running container
```
docker exec -it <id> sh
```

### Run shell in container without executing entry point
```
docker run -it --entrypoint sh <id>
```

### Display container's log
```
docker logs <id>
```

### Display container's statistics
```
docker stats <id>
```

### List images
```
docker images ls
```
### Build args in Dockerfile
```
ARG <name>
```

### Set env variable in Dockerfile
```
ENV <name>=<value>
```

### Set build arg as env variable in Dockerfile
```
ENV <name>=${<arg>}
```
### Dockerfile good practices:
- Keep build context small or use dockerignore.
- Maintain proper instructions order (install dependencies first then copy applicaiton code/binaries).
- Merge multiple commands (using &&).
- Remove unnecessary dependencies.
- Use specific tag for base image.
- Use multi-stage build.

### Mulit-stage dockerfile
```dockerfile
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base #use minial image for application hosting
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build #use image contains sdk for build only
WORKDIR /src 
COPY ["MyApp/MyApp.csproj", "MyApp/"] #copy .csproj only
RUN dotnet restore "MyApp/MyApp.csproj" #restore dependencies - this will be cached for future builds
COPY . . #copy rest of the code
WORKDIR "/src/MyApp"
RUN dotnet build "MyApp.csproj" -c Release -o /app/build #build application

FROM build AS publish 
RUN dotnet publish "MyApp.csproj" -c Release -o /app/publish #publish application to /app/publish

FROM base AS final #use base image declared at the begining
WORKDIR /app 
COPY --from=publish /app/publish . #copy binaries from publish stage to WORKDIR
ENTRYPOINT ["dotnet", "MyApp.dll"] #declare container entry point
```

### Custom repositoty certificates in Linux
To use custom repository via HTTPS in Linux place certifiacate in `/etc/docker/certs.d/<repository name>/`.

### Expose and Port explanation
When writing your Dockerfiles, the instruction __EXPOSE__ tells Docker the running container listens on specific network ports. This acts as a kind of port mapping documentation that can then be used when publishing the ports.
But __EXPOSE will not__ allow communication via the defined ports to containers outside of the same network or to the host machine. To allow this to happen you need to publish the ports.

These are the flags __-p__ and __-P__, and they differ in terms of whether you want to publish one or all ports. To actually publish the port when running the container, use the __-p__ flag on docker run to publish and map one or more ports, or the __-P__ flag to publish all exposed ports and map them to high-order ports.
```
docker run -p 80:80/tcp -p 80:80/udp my_app
```
In the above example, the first number following the __-p__ flag is the host port, and the second is the container port.

Source: https://medium.freecodecamp.org/expose-vs-publish-docker-port-commands-explained-simply-434593dbc9a3

### Docker's internal DNS
Docker have internal DNS, so services can communicate using container name but they have to be in the same network and it can't be default network.
```bash
#create two containers
docker run -d --name nginx1 -p 8888:80 nginx
docker run -d --name nginx2 -p 8889:80 nginx

#create new network
docker network create nginx-network

#connect containers to network
docker network connect nginx-network nginx1
docker network connect nginx-network nginx2

#sh into container
docker exec -it nginx1 sh

#ping other container (inside container)
ping nginx2
```