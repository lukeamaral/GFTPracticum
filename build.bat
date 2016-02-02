call "C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\Tools\vsvars32.bat"
MSBuild GFTPracticum.sln
MSTest /testcontainer:GFTPracticum.Tests\bin\Debug\GFTPracticum.Tests.dll
pause