# Define base URL
$baseUrl = "http://localhost:5166/api"

function Login {
    param([string]$employeeId, [string]$password)

    $url = "$baseUrl/Auth/login"
    $body = @{
        employeeid = $employeeId
        password = $password
    } | ConvertTo-Json
    Write-Host "Logging in, please wait..."
    try {
        $response = Invoke-RestMethod -Uri $url -Method Post -Body $body -ContentType "application/json" 
        $response | ConvertTo-Json -Depth 3
    }
    catch
    {
        if ($_.Exception.Response -is [System.Net.HttpWebResponse]) {
            $statusCode = $_.Exception.Response.StatusCode.value__
            $statusDescription = $_.Exception.Response.StatusDescription

            Write-Host "HTTP Error {$statusCode}: $statusDescription"
            Write-Host "Response content:"
            $reader = New-Object System.IO.StreamReader($_.Exception.Response.GetResponseStream())
            $reader.BaseStream.Position = 0
            $reader.DiscardBufferedData()
            $reader.ReadToEnd() | Write-Host
        }
        else {
            Write-Host "Non-HTTP error: $($_.Exception.Message)"
        }
    }
}

# Function to GET available slots for a specific date
function Get-AvailableSlots {
    param([string]$dateFrom)

    $url = "$baseUrl/Parking/availability?dateFrom=$dateFrom"
    Write-Host "Fetching available slots for $dateFrom..."
    try {
        $response = Invoke-RestMethod -Uri $url -Method Get 
        $response | ConvertTo-Json -Depth 3
    }
    catch
    {
        if ($_.Exception.Response -is [System.Net.HttpWebResponse]) {
            $statusCode = $_.Exception.Response.StatusCode.value__
            $statusDescription = $_.Exception.Response.StatusDescription

            Write-Host "HTTP Error {$statusCode}: $statusDescription"
            Write-Host "Response content:"
            $reader = New-Object System.IO.StreamReader($_.Exception.Response.GetResponseStream())
            $reader.BaseStream.Position = 0
            $reader.DiscardBufferedData()
            $reader.ReadToEnd() | Write-Host
        }
        else {
            Write-Host "Non-HTTP error: $($_.Exception.Message)"
        }
    }
}

# Function to GET grouped slots between two dates
function Get-RangedSlots {
    param([string]$dateFrom, [string]$dateTo)

    $url = "$baseUrl/Parking/availability?dateFrom=$dateFrom&dateTo=$dateTo"
    Write-Host "Fetching available slots from $dateFrom to $dateTo..."
    try {
        $response = Invoke-RestMethod -Uri $url -Method Get 
        $response | ConvertTo-Json -Depth 3
    }
    catch
    {
        if ($_.Exception.Response -is [System.Net.HttpWebResponse]) {
            $statusCode = $_.Exception.Response.StatusCode.value__
            $statusDescription = $_.Exception.Response.StatusDescription

            Write-Host "HTTP Error {$statusCode}: $statusDescription"
            Write-Host "Response content:"
            $reader = New-Object System.IO.StreamReader($_.Exception.Response.GetResponseStream())
            $reader.BaseStream.Position = 0
            $reader.DiscardBufferedData()
            $reader.ReadToEnd() | Write-Host
        }
        else {
            Write-Host "Non-HTTP error: $($_.Exception.Message)"
        }
    }
}

# Function to POST a new booking
function Create-Booking {
    param(
        [string]$dateOfBooking,
        [int]$parkingSpaceId,
        [int]$bookeeId
    )

    $url = "$baseUrl/Parking/book"
    $body = @{
        dateOfBooking = $dateOfBooking
        parkingSpaceId = $parkingSpaceId
        bookeeId = $bookeeId
    } | ConvertTo-Json

    Write-Host "Creating booking for $dateOfBooking..."
    try {
        $response = Invoke-RestMethod -Uri $url -Method Post -Body $body -ContentType "application/json" 
        $response | ConvertTo-Json -Depth 3
    }
    catch
    {
        if ($_.Exception.Response -is [System.Net.HttpWebResponse]) {
            $statusCode = $_.Exception.Response.StatusCode.value__
            $statusDescription = $_.Exception.Response.StatusDescription

            Write-Host "HTTP Error {$statusCode}: $statusDescription"
            Write-Host "Response content:"
            $reader = New-Object System.IO.StreamReader($_.Exception.Response.GetResponseStream())
            $reader.BaseStream.Position = 0
            $reader.DiscardBufferedData()
            $reader.ReadToEnd() | Write-Host
        }
        else {
            Write-Host "Non-HTTP error: $($_.Exception.Message)"
        }
    }
}

# Sample usage

# Logins
Login -employeeId "XYZ" -password "password123"  # Incorrect Username
Login -employeeId "ATH" -password "letmein789"   # Incorrect Password
Login -employeeId "ATH" -password "password123"  # Correct Username and Password

# Availability
Get-AvailableSlots -dateFrom "2025-04-29" # Single date

Get-RangedSlots -dateFrom "2025-04-23" -dateTo "2025-04-30" # Date range
Get-RangedSlots -dateFrom "2025-05-01" -dateTo "2025-05-07" # Date range

# Booking
Create-Booking -dateOfBooking "2025-08-22" -parkingSpaceId 101 -bookeeId 1 # Invalid space
Create-Booking -dateOfBooking "2025-04-29" -parkingSpaceId 1 -bookeeId 1 # Unavailable space
Create-Booking -dateOfBooking "2025-08-22" -parkingSpaceId 2 -bookeeId 77 # Invalid BookieId
Create-Booking -dateOfBooking "2025-08-22" -parkingSpaceId 1 -bookeeId 1 # Available space
