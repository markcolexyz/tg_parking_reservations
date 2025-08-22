# 🚀 Parking Reservation API Setup & Testing Guide

## 📦 Requirements

Make sure the following are installed:

- [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
- Git (to clone the repo)
- PowerShell 7+ (for script-based testing)
- A browser or terminal

## 🛠️ Local Setup

### 1. Clone the Repository

git clone https://github.com/markcolexyz/tg_parking_reservations.git

cd tg_parking_reservations

### 2. Build the Solution/Project

dotnet build

### 3. Run the Project

cd ParkingReservationApp

dotnet run

### 4. The API will launch at: 

- http://localhost:5166

## 🧪 Testing the API

There are 3 API endpoints to test.

1. /api/Auth/login - To login securely. Takes two parameters, employeeid and password.
2. /api/Parking/availability - View available parking slots.  Takes three parameters, dateFrom, dateTo and parkingStrcutureId (defaulted to 1)
3. /api/Parking/book - Book a parking slot.  Takes 4 parameters, bookieId, parkingSpaceId, parkingStrcutureId and dateOfBooking

✅ Option 1: PowerShell Script
There is a Powershell script in the project folder:

cd tg_parking_reservations\ParkingReservationApp\scripts

.\parking_reservation_api_test.ps1

Run the tests individually from the command line as follows:
- Login Test 1 - Incorrect Username
powershell -Command ". .\parking_reservation_api_test.ps1; Login -employeeId 'XYZ' -password 'password123'"
- Login Test 2 - Incorrect Password	
powershell -Command ". .\parking_reservation_api_test.ps1; Login -employeeId 'ATH' -password 'letmein789'"
- Login Test 3 - Correct Username and Password
powershell -Command ". .\parking_reservation_api_test.ps1; Login -employeeId 'ATH' -password 'password123'"
- Availability Test 1 - Single date
powershell -Command ". .\parking_reservation_api_test.ps1; Get-AvailableSlots -dateFrom '2025-04-29'"
- Availability Test 2 - Date range
powershell -Command ". .\parking_reservation_api_test.ps1; Get-RangedSlots -dateFrom '2025-04-23' -dateTo '2025-04-30'"
- Booking a slot Test 1 - Invalid parking space Id
powershell -Command ". .\parking_reservation_api_test.ps1; Create-Booking -dateOfBooking '2025-08-22' -parkingSpaceId 101 -bookeeId 1"
- Booking a slot Test 2 - Unavailable space
powershell -Command ". .\parking_reservation_api_test.ps1; Create-Booking -dateOfBooking '2025-04-29' -parkingSpaceId 1 -bookeeId 1"
- Booking a slot Test 3 - Invalid Bookie Id
powershell -Command ". .\parking_reservation_api_test.ps1; Create-Booking -dateOfBooking '2025-08-22' -parkingSpaceId 2 -bookeeId 77"
- Booking a slot Test 3 - Available space, valid space Id & valid Bookie Id
powershell -Command ". .\parking_reservation_api_test.ps1; Create-Booking -dateOfBooking '2025-08-22' -parkingSpaceId 1 -bookeeId 1"

💡 If you get a permission error, run:

Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass

✅ Option 2: Swagger UI
- Open your browser and navigate to:
http://localhost:5166/swagger
- Use the interactive interface to test endpoints


