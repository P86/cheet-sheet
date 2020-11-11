# https://davidhamann.de/2019/04/12/powershell-invoke-webrequest-by-example/

function Get-Json {
    param([Parameter(Mandatory = $true)][hashtable] $Params)

    $uri = $Params['Uri']
    Write-Host "********************* Send GET request to $uri *********************"

    return Invoke-WebRequest @Params -Method Get | ConvertFrom-Json
}

function Post-Json {
    param([Parameter(Mandatory = $true)][hashtable] $Params)

    $uri = $Params['Uri']
    Write-Host "********************* Send POST request to $uri *********************"

    Invoke-WebRequest @Params -Method 'POST' -ContentType 'application/json'
}


# GET with auto json parsing

$url = 'https://localhost:5001/WeatherForecast'

#$response = Invoke-WebRequest -Method 'GET' -Uri $url -Headers @{ 'X-Custom-Header' = 'custom-value' } | ConvertFrom-Json
#$env:TEST = $response[0].Summary


$post_params = @{
Uri = $url
Body = (@{ property = 'arek'; `
           property2 = 'p'} | ConvertTo-Json)
}

Post-Json -params $post_params
#Invoke-WebRequest -Method 'POST' -Uri $url -Body $body -ContentType 'application/json'

$params = @{
Uri = $url
Headers = @{ 'X-Custom-Header' = 'custom-value' }
}

$result = Get-Json -Params $params
Write-Host $result[1]