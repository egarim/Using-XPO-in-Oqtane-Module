XCOPY "..\Client\bin\Debug\net5.0\BIT.Customer.Client.Oqtane.dll" "..\..\oqtane.framework-2.0.1\Oqtane.Server\bin\Debug\net5.0\" /Y
XCOPY "..\Client\bin\Debug\net5.0\BIT.Customer.Client.Oqtane.pdb" "..\..\oqtane.framework-2.0.1\Oqtane.Server\bin\Debug\net5.0\" /Y
XCOPY "..\Server\bin\Debug\net5.0\BIT.Customer.Server.Oqtane.dll" "..\..\oqtane.framework-2.0.1\Oqtane.Server\bin\Debug\net5.0\" /Y
XCOPY "..\Server\bin\Debug\net5.0\BIT.Customer.Server.Oqtane.pdb" "..\..\oqtane.framework-2.0.1\Oqtane.Server\bin\Debug\net5.0\" /Y
XCOPY "..\Shared\bin\Debug\net5.0\BIT.Customer.Shared.Oqtane.dll" "..\..\oqtane.framework-2.0.1\Oqtane.Server\bin\Debug\net5.0\" /Y
XCOPY "..\Shared\bin\Debug\net5.0\BIT.Customer.Shared.Oqtane.pdb" "..\..\oqtane.framework-2.0.1\Oqtane.Server\bin\Debug\net5.0\" /Y

XCOPY "..\Server\bin\Debug\net5.0\DevExpress.Data.v20.2.dll" "..\..\oqtane.framework-2.0.1\Oqtane.Server\bin\Debug\net5.0\" /Y
XCOPY "..\Server\bin\Debug\net5.0\DevExpress.Xpo.v20.2.dll" "..\..\oqtane.framework-2.0.1\Oqtane.Server\bin\Debug\net5.0\" /Y

XCOPY "..\Server\wwwroot\*" "..\..\oqtane.framework-2.0.1\Oqtane.Server\wwwroot\" /Y /S /I
