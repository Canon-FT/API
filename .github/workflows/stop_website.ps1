if ((Get-WebSiteState -Name FT-API).Value -eq "Started")
{
    Stop-WebSite -Name FT-API
    echo "Stopped Website FT-API"
}
if ((Get-WebAppPoolState -Name FT-API).Value -eq "Started")
{
    Stop-WebAppPool -Name FT-API
    echo "Stopped Application Pool FT-API"
}
Start-Sleep -s 15
