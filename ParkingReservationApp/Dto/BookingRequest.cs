public class BookingRequest
{
    public int BookeeId { get; set; }
    public int ParkingSpaceId { get; set; }
    public int ParkingStructureId { get; set; } = 1; // Default to 1
    public DateTime DateOfBooking { get; set; }
}
