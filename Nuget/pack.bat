@Echo Setting up folder structure
md Package\lib\net45\
md Package\tools\
md Package\content\lang\

@Echo Removing old files
del /Q Package\lib\net45\*.*

@Echo Copying new files
copy ..\CookieVisitorGroupCriteria\bin\Release\CookieVisitorGroupCriteria.dll Package\lib\net45 
copy ..\CookieVisitorGroupCriteria\lang\CookieVisitorGroupCriteria.xml Package\content\lang\CookieVisitorGroupCriteria.xml

@Echo Packing files
"..\.nuget\nuget.exe" pack package\CookieVisitorGroupCriteria.nuspec

@Echo Moving package
move /Y *.nupkg c:\project\nuget.local\