## Standalone setup

Download and install .net sdk 3.1 for your platform [dotnet](https://dotnet.microsoft.com/download/dotnet/3.1)


Issue
```bash
dotnet --info
```
to confirm successful installation.

Then inside a new folder download the private repository issuing
```bash
git clone https://felichio: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@github.com/felichio/KVServer.git
```
Navigate inside *KVServer* folder and build the executable
```bash
cd KVServer
```
```bash
dotnet build -c Release -o app
```

The executable **kvServer** is located inside the *app* folder

Run the executable e.g.
```bash
app/kvServer -a 127.0.0.1 -p 10000
```


## Docker setup

Download [docker](https://docs.docker.com/get-docker/) for your platform

Get the Dockefile either by cloning this project (see standalone setup) or using wget
```bash
wget -O Dockerfile https://raw.githubusercontent.com/felichio/DataGenerator/master/Dockerfile?token=ADE423QMTKNSB4BDQBGGLPDANQ7RQ
```
Assuming Dockerfile is residing in the current directory.
Build the image
```bash
docker build . -t triple_app_image
```

Run a container
```bash
docker container run -it triple_app_image
```

Inside the containerized enviroment you will be placed in a *playGround* folder. The set of applications {**createData**, **kvBroker**, **kvServer**} are all available inside the container (through $PATH).

Run your scenario. As helpers there are predefined files inside the *playGround* folder. Issue `ls` to view them. Use `vim` to edit whatever needs editing. Own files could be passed by making a new image, bind mounts, vim clipboard pasting etc. 

\* For simplicity i avoided a multicontainer setup. Everything sits inside the same container. Use localhost addresses 127.x.x.x/8
