# 🚀 Parking Reservation API Setup & Testing Guide

## 📦 Requirements

Make sure the following are installed:

- [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
- Git (to clone the repo)
- PowerShell 7+ (for script-based testing)
- A browser or terminal

## 🛠️ Local Setup

### 1. Clone the Repository

<pre><code class="language-bash">git clone https://github.com/markcolexyz/tg_parking_reservations.git
cd tg_parking_reservations</code></pre>

### 2. Build the Solution/Project

<pre><code class="language-bash">dotnet build</code></pre>

### 3. Run the Project

<pre><code class="language-bash">cd ParkingReservationApp
dotnet run</code></pre>

### 4. The API will launch at: 

- http://localhost:5166

## 🧪 Testing the API

There are 3 API endpoints to test.

1. /api/Auth/login - To login securely. Takes two parameters, employeeid and password.
2. /api/Parking/availability - View available parking slots.  Takes three parameters, dateFrom, dateTo and parkingStrcutureId (defaulted to 1)
3. /api/Parking/book - Book a parking slot.  Takes 4 parameters, bookieId, parkingSpaceId, parkingStrcutureId and dateOfBooking

✅ Option 1: PowerShell Script
There is a Powershell script in the project folder:

<pre><code class="language-bash">cd tg_parking_reservations\ParkingReservationApp\scripts
.\parking_reservation_api_test.ps1</code></pre>

Run the tests individually from the command line as follows:
- Login Test 1 - Incorrect Username
<pre><code class="language-powershell">powershell -Command ". .\parking_reservation_api_test.ps1; Login -employeeId 'XYZ' -password 'password123'"</code></pre>
- Login Test 2 - Incorrect Password	
<pre><code class="language-powershell">powershell -Command ". .\parking_reservation_api_test.ps1; Login -employeeId 'ATH' -password 'letmein789'"</code></pre>
- Login Test 3 - Correct Username and Password
<pre><code class="language-powershell">powershell -Command ". .\parking_reservation_api_test.ps1; Login -employeeId 'ATH' -password 'password123'"</code></pre>
- Availability Test 1 - Single date
<pre><code class="language-powershell">powershell -Command ". .\parking_reservation_api_test.ps1; Get-AvailableSlots -dateFrom '2025-04-29'"</code></pre>
- Availability Test 2 - Date range
<pre><code class="language-powershell">powershell -Command ". .\parking_reservation_api_test.ps1; Get-RangedSlots -dateFrom '2025-04-23' -dateTo '2025-04-30'"</code></pre>
- Booking a slot Test 1 - Invalid parking space Id
<pre><code class="language-powershell">powershell -Command ". .\parking_reservation_api_test.ps1; Create-Booking -dateOfBooking '2025-08-22' -parkingSpaceId 101 -bookeeId 1"</code></pre>
- Booking a slot Test 2 - Unavailable space
<pre><code class="language-powershell">powershell -Command ". .\parking_reservation_api_test.ps1; Create-Booking -dateOfBooking '2025-04-29' -parkingSpaceId 1 -bookeeId 1"</code></pre>
- Booking a slot Test 3 - Invalid Bookie Id
<pre><code class="language-powershell">powershell -Command ". .\parking_reservation_api_test.ps1; Create-Booking -dateOfBooking '2025-08-22' -parkingSpaceId 2 -bookeeId 77"</code></pre>
- Booking a slot Test 3 - Available space, valid space Id & valid Bookie Id
<pre><code class="language-powershell">powershell -Command ". .\parking_reservation_api_test.ps1; Create-Booking -dateOfBooking '2025-08-22' -parkingSpaceId 1 -bookeeId 1"</code></pre>

💡 If you get a permission error, run:

<pre><code class="language-powershell">Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass</code></pre>

✅ Option 2: Swagger UI
- Open your browser and navigate to:
http://localhost:5166/swagger
- Use the interactive interface to test endpoints


