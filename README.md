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

## 🧪 Testing the API

There are 3 API endpoints to test.

1. /api/Auth/login - To login securely. Takes two parameters, employeeid and password.
2. /api/Parking/availability - View available parking slots.  Takes three parameters, dateFrom, dateTo and parkingStrcutureId (defaulted to 1)
3. /api/Parking/book - Book a parking slot.  Takes 4 parameters, bookieId, parkingSpaceId, parkingStrcutureId and dateOfBooking

✅ Option 1: PowerShell Script
There is a Powershell script in the project folder:

cd tg_parking_reservations\ParkingReservationApp\scripts

.\parking_reservation_api_test.ps1

There are the following tests to run:
- valid and invalid logins
- available slots on a specific date and date range
- successful and unsuccessful bookings

💡 If you get a permission error, run:

Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass

✅ Option 2: Swagger UI
- Open your browser and navigate to:
http://localhost:5166/swagger
- Use the interactive interface to test endpoints


