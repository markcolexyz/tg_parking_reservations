using System.ComponentModel.DataAnnotations.Schema;

public class ParkingSpace
{
    [Column("parkingspaceid")]
    public int ParkingSpaceId { get; set; }
    [Column("parkingstructureid")]
    public int ParkingStructureId { get; set; }
    public ParkingStructure? ParkingStructure { get; set; }
}