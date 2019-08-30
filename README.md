# SI_ex1
Handin for Ex1 System Integration for PBA fall2019

# What is it

This repo contains 2 C# (target: dotnet core 2.2) console-apps (server and client). Included in each app is a dockerfile (incase you dont have C# runtime on your machine)

# How to make it go (with docker)

1) Navigate to server folder.
2) Build it.
```
sudo docker build -t serverapp .
```
3) Run it.
```
sudo docker run -it --rm serverapp
```
4) (In a new terminal) Navigate to client folder.
5) Build it.
```
sudo docker build -t clientapp .
```
6) Run it.
```
sudo docker run -it --rm clientapp
```

# How to make it go (without docker)
0) for ip-address on windows enter 'ipconfig' - for linux enter 'hostname -I'.
1) Navigate to server folder
2) Build and run program using folllowing format
```
dotnet run <Local networkaddress ipv4>
```
3) Navigate to client folder
4) Build and run program using folllowing format
```
dotnet run <Enter the local networkaddress you assinged to server in step 2>
```


<b>NB. To connect docker-containers across different host you need docker-swarm or weave or similar. Alternativly run the apps outside the container</b>

