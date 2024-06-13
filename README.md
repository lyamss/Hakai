Do not run this .exe on your machine

*Start projet*

for windows

```
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:DebugType=embedded
```

for linux

```
dotnet publish -c Release -r linux-x64 --self-contained true -p:PublishSingleFile=true -p:DebugType=embedded
```

for macOS Apple
```
dotnet publish -c Release -r osx-x64 --self-contained true -p:PublishSingleFile=true -p:DebugType=embedded
```