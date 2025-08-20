using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ParkingController : ControllerBase
{
    private readonly ParkingDbContext _context;

    public ParkingController(ParkingDbContext context)
    {
        _context = context;
    }

    [HttpGet("availability")]
    public async Task<IActionResult> GetAvailability([FromQuery] DateTime dateFrom, [FromQuery] DateTime? dateTo, [FromQuery] int parkingStructureId = 1)
    {
        // Determine the end date for the availability check if a date was provided
        var endDate = dateTo ?? dateFrom;

        var allSpaces = await _context.ParkingSpaces
            .Include(ps => ps.ParkingStructure)
            .ToListAsync();

        var bookings = await _context.Bookings
            .Where(b => b.DateOfBooking >= dateFrom && b.DateOfBooking <= endDate)
            .ToListAsync();

        // Iterate over each date in the range
        var result = new List<object>();
        for (var date = dateFrom.Date; date <= endDate.Date; date = date.AddDays(1))
        {
            var bookedOnDate = bookings
            .Where(b => b.DateOfBooking.Date == date)
            .Select(b => new { b.ParkingSpaceId, b.ParkingStructureId })
            .ToList();

            var availableOnDate = allSpaces
                .Where(ps => !bookedOnDate.Any(bs =>
                    bs.ParkingSpaceId == ps.ParkingSpaceId &&
                    bs.ParkingStructureId == ps.ParkingStructureId))
                .Select(ps => new ParkingSpace
                {
                    // We could create a new object later with a cleaner output
                    ParkingSpaceId = ps.ParkingSpaceId,
                    ParkingStructureId = ps.ParkingStructureId,
                    ParkingStructure = ps.ParkingStructure
                })
                .ToList();


            result.Add(new
            {
                Date = date.ToString("yyyy-MM-dd"),
                availableSlots = availableOnDate
            });
        }
            
        return Ok(result);
    }

}