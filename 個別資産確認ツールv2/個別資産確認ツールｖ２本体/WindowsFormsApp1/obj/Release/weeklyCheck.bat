@echo off
cd /d %~dp0

set MAILADDRESS=Yuji.Kitamura@k-js.co.jp
set SAVEDIR=.

WindowsFormsApp1.exe -rt Last7days -m %MAILADDRESS% -t %SAVEDIR%