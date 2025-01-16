Import-Module WebAdministration
echo "Starting website"
if ((Get-WebSiteState -Name FT-API).Value -eq "Stopped"){
    Start-WebSite -Name FT-API
    echo "Started Website FT-API"
} else {
    echo "Website FT-API already started"
}
if ((Get-WebAppPoolState -Name FT-API).Value -eq "Stopped") {
    Start-WebAppPool -Name FT-API
    echo "Started Application Pool FT"
} else {
    echo "Application pool FT-API already started"
}
echo "Website started."
Remove-Module WebAdministration
