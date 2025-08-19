public class Booking
{
    public int BookingId { get; set; }
    public int BookeeId { get; set; }
    public DateTime DateOfBooking { get; set; }
    public int ParkingSpaceId { get; set; }
    public int ParkingStructureId { get; set; }

    public Bookee Bookee { get; set; }
    public ParkingSpace ParkingSpace { get; set; }
}