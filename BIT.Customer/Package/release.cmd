"..\..\oqtane.framework-2.0.1\oqtane.package\nuget.exe" pack BIT.Customer.nuspec 
XCOPY "*.nupkg" "..\..\oqtane.framework-2.0.1\Oqtane.Server\wwwroot\Modules\" /Y
