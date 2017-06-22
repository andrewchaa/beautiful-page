del .\package-to-publish\*.nupkg
.\packages\NuGet.CommandLine.4.1.0\tools\NuGet.exe pack .\BeautifulWeb.csproj -OutputDirectory .\package-to-publish
.\packages\NuGet.CommandLine.4.1.0\tools\NuGet.exe push .\package-to-publish\*.nupkg -source https://www.nuget.org/api/v2/package
