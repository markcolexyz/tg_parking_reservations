public class ParkingSpace
{
    public int ParkingSpaceId { get; set; }
    public int ParkingStructureId { get; set; }
    public ParkingStructure? ParkingStructure { get; set; }
}