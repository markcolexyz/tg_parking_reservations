using System.ComponentModel.DataAnnotations.Schema;

public class Booking
{
    [Column("bookingid")]
    public int BookingId { get; set; }
    [Column("bookee_id")]
    public int BookeeId { get; set; }
    [Column("dateofbooking")]
    public DateTime DateOfBooking { get; set; }
    [Column("parkingspace_id")]
    public int ParkingSpaceId { get; set; }
    [Column("parkingstructure_id")]
    public int ParkingStructureId { get; set; }

    public Bookee? Bookee { get; set; }
    public ParkingSpace? ParkingSpace { get; set; }
}