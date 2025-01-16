Import-Module WebAdministration
echo "Stopping website"
if ((Get-WebSiteState -Name FT-API).Value -ne "Stopped") {
    Stop-WebSite -Name FT-API
    echo "Stopped Website FT-API"
} else {
    echo "Website FT-API already stopped"
}
if ((Get-WebAppPoolState -Name FT-API).Value -ne "Stopped") {
    Stop-WebAppPool -Name FT-API
    echo "Stopped Application Pool FT-API"
} else {
    echo "Application pool FT-API already stopped"
}
Start-Sleep -s 15
echo "Website stopped."
Remove-Module WebAdministration
