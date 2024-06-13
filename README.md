Do not run this .exe on your machine

*Start projet*

for windows

```
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:DebugType=embedded
```