![logo](https://upload.wikimedia.org/wikipedia/commons/7/79/Docker_%28container_engine%29_logo.png)

### Display running containers 
```
docker ps
```

### Run container
```
docker run <id>
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