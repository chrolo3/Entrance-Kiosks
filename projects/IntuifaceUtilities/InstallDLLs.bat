
start C:\IntuifaceUtilities\GenerateDescriptor\Release\GenerateDescriptor.exe "C:\IntuifaceUtilities\DLL\DataBaseHandler\DataBaseHandler.dll"

start C:\IntuifaceUtilities\GenerateDescriptor\Release\GenerateDescriptor.exe "C:\IntuifaceUtilities\DLL\SearchRooms\SearchRooms.dll"

robocopy "C:\IntuifaceUtilities\DLL\DataBaseHandler" "C:\Users\Public\Intuiface\1-6d0c4909-3644\Files\InterfaceAssets\DataBaseHandler"

robocopy "C:\IntuifaceUtilities\DLL\SearchRooms" "C:\Users\Public\Intuiface\1-6d0c4909-3644\Files\InterfaceAssets\SearchRooms"

@echo off
echo.
echo.
echo ////////////////////////////////////////////////////////////////////////////
echo Done! Please check the open cmdline windows for any errors in installation.
echo ////////////////////////////////////////////////////////////////////////////
echo.
echo.
@echo on

cmd /k

