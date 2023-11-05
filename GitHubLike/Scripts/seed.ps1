if (!(Get-Module -ListAvailable sqlserver)) {
  Write-Host("INFO: Installing sqlserver module.")
  Set-PSRepository -Name "PSGallery" -InstallationPolicy Trusted
  Install-Module sqlserver -Repository PSGallery
}

else {
	Write-Host("INFO: sqlserver module already installed.")
}

Import-Module sqlserver

$serverName = "DESKTOP-IB"
$databaseName = "GitHubLike"

$server = New-Object Microsoft.SqlServer.Management.Smo.Server($serverName)

if ($server.Databases.Contains($databaseName)) {
    $database = $server.Databases[$databaseName]
    $database.Drop()
    Write-Host "Database $databaseName has been dropped."
} else {
    Write-Host "Database $databaseName does not exist."
}

$projectName = "GitHubLike"
$dbContext = "GitHubLike.Modules.Common.Entity.ApplicationDbContext"

$connectionString = "Server=DESKTOP-IB;Initial Catalog=GitHubLike;Persist Security Info=False;User ID=sa;Password=systematic;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30"

$migrationsAssembly = "../migrations"

Write-Host "Applying Migrations"

dotnet ef database update --project $projectName --startup-project $projectName --context $dbContext --connection $connectionString --assembly $migrationsAssembly --msbuildprojectextensionspath obj/local

Read-Host -Prompt "Press Enter to exit"