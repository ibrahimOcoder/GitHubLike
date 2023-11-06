if (!(Get-Module -ListAvailable sqlserver)) {
  Write-Host("INFO: Installing sqlserver module.")
  Set-PSRepository -Name "PSGallery" -InstallationPolicy Trusted
  Install-Module sqlserver -Repository PSGallery
}

else {
	Write-Host("INFO: sqlserver module already installed.")
}

Import-Module sqlserver

$serverName = (Get-Content appsettings.json | ConvertFrom-Json).ConnectionStrings.ServerName
$databaseName = "GitHubLike"
$server = New-Object Microsoft.SqlServer.Management.Smo.Server($serverName)

if ($server.Databases.Contains($databaseName)) {
	Write-Host "Found database with the name: $databaseName. Needs to be dropped. All migrations would be applied and data would be seeded"
	dotnet ef database drop --project "../GitHubLike"
} else {
    Write-Host "Database $databaseName does not exist."
}

$connectionString = (Get-Content appsettings.json | ConvertFrom-Json).ConnectionStrings.DefaultConnection

Write-Host "Applying Migrations and seeding data..."
dotnet ef database update --project "../GitHubLike" --context "GitHubLike.Modules.Common.Entity.ApplicationDbContext" --connection $connectionString

Read-Host -Prompt "Press Enter to exit"