if ((Get-WebSiteState -Name FT-API).Value -eq "Stopped")
{
    Start-WebSite -Name FT-API
    echo "Started Website FT-API"
}
if ((Get-WebAppPoolState -Name FT-API).Value -eq "Stopped")
{
    Start-WebAppPool -Name FT-API
    echo "Started Application Pool FT"
}
