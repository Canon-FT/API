Import-Module WebAdministration
echo "Stopping website"
if ((Get-WebSiteState -Name FT-API).Value -eq "Started") {
    Stop-WebSite -Name FT-API
    echo "Stopped Website FT-API"
} else {
    echo "Website FT-API already stopped"
}
if ((Get-WebAppPoolState -Name FT-API).Value -eq "Started") {
    Stop-WebAppPool -Name FT-API
    echo "Stopped Application Pool FT-API"
} else {
    echo "Application pool FT-API already stopped"
}
Start-Sleep -s 15
echo "Website stopped."
Remove-Module WebAdministration
